using API_REST.Domain.Entities;

namespace API_REST.Application.Interfaces
{
    public interface IPersonaRepository
    {
        Task AddRangeAsync(List<Persona> personas);
        Task<List<Persona>> GetAllAsync();
        Task<Persona?> GetPersonaAsync(int id);

    }
}