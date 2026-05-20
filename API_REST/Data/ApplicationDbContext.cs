using Microsoft.EntityFrameworkCore;
using API_REST.Models;

namespace API_REST.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
    }
}
