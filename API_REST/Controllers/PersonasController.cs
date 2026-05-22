using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_REST.Models;
using API_REST.Data;

[Route("api/[controller]")]
[ApiController]
public class PersonasController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public PersonasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Persona
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Persona>>> GetPersona()
    {
        return await _context.Personas.ToListAsync();
    }

    // GET: api/Persona/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Persona>> GetPersona(int id)
    {
        var persona = await _context.Personas.FindAsync(id);

        if (persona == null)
        {
            return NotFound();
        }

        return persona;
    }

    // PUT: api/Persona/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPersona(int? id, Persona persona)
    {
        if (id != persona.Id)
        {
            return BadRequest();
        }

        _context.Entry(persona).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonaExists(id))
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

    // POST: api/Persona
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult> PostPersonas([FromBody] List<Persona> personas)
    {
        if (personas == null || personas.Count == 0)
            return BadRequest("La lista de personas está vacía.");

        foreach (var persona in personas)
        {
            if (string.IsNullOrWhiteSpace(persona.Name))
                return BadRequest("El nombre es requerido.");
            if (string.IsNullOrWhiteSpace(persona.LastName))
                return BadRequest("El apellido es requerido.");
            if (persona.Age <= 0)
                return BadRequest("La edad debe ser mayor que 0.");
            if (persona.Birthate == DateTime.MinValue)
                return BadRequest("La fecha de nacimiento no es válida.");

            _context.Personas.Add(persona);
        }

        await _context.SaveChangesAsync();

        return Ok(new { message = "Records saved successfully" });
    }

    // DELETE: api/Persona/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersona(int? id)
    {
        var persona = await _context.Personas.FindAsync(id);
        if (persona == null)
        {
            return NotFound();
        }

        _context.Personas.Remove(persona);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PersonaExists(int? id)
    {
        return _context.Personas.Any(e => e.Id == id);
    }
}
