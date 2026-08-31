using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Book;
using AutoMapper;
using AutoMapper.QueryableExtensions;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _imapper;
    public BooksController(BookStoreDbContext context, IMapper imapper)
    {
        _context = context;
        _imapper = imapper;
    }

    // GET: api/Book
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookReadOnlyDTO>>> GetBook()
    {
        var book = await _context.Books.
            Include(q => q.Author).
            ProjectTo<BookReadOnlyDTO>(_imapper.ConfigurationProvider).
            ToListAsync();
        return Ok(book);
    }

    // GET: api/Book/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDetailsDTO>> GetBook(int id)
    {
        var book = await _context.Books.
            Include(q => q.Author).
            ProjectTo<BookDetailsDTO>(_imapper.ConfigurationProvider).
            FirstOrDefaultAsync(q => q.id == id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    // PUT: api/Book/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int? id, BookUpdateDTO bookDTO)
    {
        if (id != bookDTO.id)
        {
            return BadRequest();
        }

        var book = await _context.Books.FindAsync(id);

        if(book == null)
        {
            return NotFound();
        }

        _imapper.Map(bookDTO, book);

        _context.Entry(book).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await BookExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Book
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(BookCreateDTO bookDTO)
    {
        var book = _imapper.Map<Book>(bookDTO); 
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    // DELETE: api/Book/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int? id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private async Task<bool> BookExists(int? id)
    {
        return await _context.Books.AnyAsync(e => e.Id == id);
    }
}
