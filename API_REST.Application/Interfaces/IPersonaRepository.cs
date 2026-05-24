using API_REST.Domain.Entities;

namespace API_REST.Application.Interfaces
{
    public interface IPersonaRepository
    {
        //Guarda una lista de personas en la bse de datos
        Task AddRangeAsync(List<Persona> personas);

        // Retorna todos los registros de personas
        Task<List<Persona>> GetAllAsync();

        // Retorna un registro de persona por su id
        Task<Persona?> GetPersonaAsync(int id);

    }
}