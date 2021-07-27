using curso.api.Infraestruture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace curso.api.Extras
{
    // comando para rodar em tempo de execução
    public class ComandosDbContext : IDesignTimeDbContextFactory<CursosDbContext>
    {
        public CursosDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<CursosDbContext>();

            options.UseSqlServer("Server = localhost; Database = Curso;");

            CursosDbContext contexto = new CursosDbContext(options.Options);

            return contexto;

        }
    }
}
