using API_REST.Domain.Entities;
using API_REST.Application.DTOs;

namespace API_REST.Application.Interfaces
{
    public interface IPersonaRepository
    {
        //Guarda una lista de personas en la bse de datos
        Task AddRangeAsync(List<PersonaCreateDTo> personas);

        // Retorna todos los registros de personas
        Task<List<PersonaResponseDto>> GetAllAsync();

        // Retorna un registro de persona por su id
        Task<PersonaResponseDto?> GetPersonaAsync(int id);

    }
}