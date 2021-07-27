using curso.api.Business.Entities;
using curso.api.Infraestruture.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace curso.api.Infraestruture.Data
{
    public class CursosDbContext : DbContext
    {
        public CursosDbContext(DbContextOptions<CursosDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Curso> Curso { get; set; }
    }
}
