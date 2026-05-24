using API_REST.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
    }
}
