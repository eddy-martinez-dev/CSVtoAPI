using Microsoft.AspNetCore.Mvc;
using API_REST.Application.Interfaces;
using API_REST.Domain.Entities;

[Route("api/[controller]")]
[ApiController]
public class PersonasController : ControllerBase
{
    private readonly IPersonaRepository _repository;
    public PersonasController(IPersonaRepository repository)
    {
        _repository = repository;
    }

    // GET: api/Persona
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Persona>>> GetPersona()
    {
        var personas = await _repository.GetAllAsync();
        return Ok(personas);
    }

    // GET: api/Persona/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Persona>> GetPersona(int id)
    {
        var persona = await _repository.GetPersonaAsync(id);

        if (persona == null)
        {
            return NotFound();
        }

        return Ok(persona);
    }

    // POST: api/Persona
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

        }

        await _repository.AddRangeAsync(personas);

        return Ok(new { message = "Records saved successfully" });
    }
}
