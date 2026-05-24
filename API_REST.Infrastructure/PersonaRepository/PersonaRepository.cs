using API_REST.Application.Interfaces;
using API_REST.Domain.Entities;
using API_REST.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor que recibre el contexto de la base de datos a través de inyección de dependencias
        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Guaarda la lista de Personas en La base de datoss
        public async Task AddRangeAsync(List<Persona> personas)
        {
            await _context.Personas.AddRangeAsync(personas);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        // Obtiene una persona por su ID
        public async Task<Persona?> GetPersonaAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }
    }
}