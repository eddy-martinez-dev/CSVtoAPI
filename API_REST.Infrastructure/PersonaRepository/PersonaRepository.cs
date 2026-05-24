using API_REST.Application.Interfaces;
using API_REST.Domain.Entities;
using API_REST.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<Persona> personas)
        {
            await _context.Personas.AddRangeAsync(personas);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona?> GetPersonaAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }
    }
}