using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using AutoMapper;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public AuthorsController(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Author
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorReadOnlyDTO>>> GetAuthor()
    {
        var authors = await _context.Authors.ToListAsync();
        var authorReadOnlyDTOs = _mapper.Map<List<AuthorReadOnlyDTO>>(authors);
        return Ok(authorReadOnlyDTOs);
    }

    // GET: api/Author/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorReadOnlyDTO>> GetAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);

        if (author == null)
        {
            return NotFound();
        }

        var authorDTO = _mapper.Map<AuthorReadOnlyDTO>(author);
        return Ok(authorDTO);
    }

    // PUT: api/Author/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAuthor(int? id, AuthorUpdateDTO authorUpdateDto)
    {
        if (id != authorUpdateDto.id)
        {
            return BadRequest();
        }

        var author = await _context.Authors.FindAsync(id);

        if(author == null)
        {
            return NotFound();
        }

        _mapper.Map(authorUpdateDto, author);
        _context.Entry(author).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await AuthorExists(id))
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

    // POST: api/Author
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<AuthorCreateDTO>> PostAuthor(AuthorCreateDTO authorCreateDTO)
    {
        var author = _mapper.Map<Author>(authorCreateDTO);
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
    }

    // DELETE: api/Author/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int? id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null)
        {
            return NotFound();
        }

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private async Task<bool> AuthorExists(int? id)
    {
        return await _context.Authors.AnyAsync(e => e.Id == id);
    }
}
