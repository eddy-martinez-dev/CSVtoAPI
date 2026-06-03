using API_REST.Application.Interfaces;
using API_REST.Domain.Entities;
using API_REST.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using API_REST.Application.DTOs;

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
        public async Task AddRangeAsync(List<PersonaCreateDTo> personas)
        {
            var entidades = personas.Select(p => new Persona
            {
                Name = p.Name,
                LastName = p.LastName,
                Age = p.Age,
                Birthate = p.Birthate
            }).ToList();

            await _context.Personas.AddRangeAsync(entidades);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PersonaResponseDto>> GetAllAsync()
        {
            return await _context.Personas.Select(p => new PersonaResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                LastName = p.LastName,
                Age = p.Age,
                DateTime = p.Birthate
            }).ToListAsync();
        }

        // Obtiene una persona por su ID
        public async Task<PersonaResponseDto?> GetPersonaAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null) return null;

            return new PersonaResponseDto
            {
                Id = persona.Id,
                Name = persona.Name,
                LastName = persona.LastName,
                Age = persona.Age,
                DateTime = persona.Birthate
            };
        }
    }
}