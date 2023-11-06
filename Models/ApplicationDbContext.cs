using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LostArkOffice.Models.DataModels;

namespace LostArkOffice.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClaseDePersonaje> ClasesDePersonaje { get; set; }
        public DbSet<TipoDeRaid> TiposDeRaid { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<PersonajeRaid> PersonajesRaid { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir la clave primaria compuesta para PersonajeRaid
            modelBuilder.Entity<PersonajeRaid>()
                .HasKey(pr => new { pr.PersonajeId, pr.TipoDeRaidId });

            // Configuraciones adicionales...
        }
    }
}
