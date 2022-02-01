using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Configuracao
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        public DbSet<Municipio> Municipios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ObterStringConexaoBanco());
                base.OnConfiguring(optionsBuilder);
            }
        }
        public static string ObterStringConexaoBanco()
        {
            return "Host=localhost;Port=5432;Pooling=true;Database=IagroDB;User Id=postgres;Password=123;";
        }
    }
}
