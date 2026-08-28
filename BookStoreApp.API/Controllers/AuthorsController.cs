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
    private readonly ILogger<AuthorsController> _logger;
    public AuthorsController(BookStoreDbContext context, IMapper mapper, ILogger<AuthorsController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    // GET: api/Author
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorReadOnlyDTO>>> GetAuthor()
    {
        _logger.LogInformation($"Received GET request at {nameof(GetAuthor)}");

        try
        {
            var authors = await _context.Authors.ToListAsync();
            var authorReadOnlyDTOs = _mapper.Map<List<AuthorReadOnlyDTO>>(authors);
            return Ok(authorReadOnlyDTOs);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error when executing GET request at {nameof(GetAuthor)}");
            return StatusCode(500, "There was an error when completing your request. Come back later");

        }

        
    }

    // GET: api/Author/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorReadOnlyDTO>> GetAuthor(int id)
    {
        try
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                _logger.LogWarning($"Error upon execution of GET request on {nameof(GetAuthor)}for {id}. Found no match.");
                return NotFound();
            }

            var authorDTO = _mapper.Map<AuthorReadOnlyDTO>(author);
            return Ok(authorDTO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error when executing GET request for {nameof(GetAuthor)}");
            return BadRequest("Bad request");
        }


       
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
