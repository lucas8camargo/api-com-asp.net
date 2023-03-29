using Microsoft.EntityFrameworkCore;
using OutraAPI.Models;

namespace OutraAPI.Context
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }

        public DbSet<Persona>? Personas { get; set; }
        public DbSet<Dependente>? Dependentes { get; set; }
    }
}