using Entidades.Entidades;
using Infraestrutura.Configuracao.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Configuracao
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Produtor> Produtors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ObterStringConexaoBanco());
                base.OnConfiguring(optionsBuilder);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProdutorMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());            
            modelBuilder.ApplyConfiguration(new MunicipioMap());

            modelBuilder.Entity<Produtor>().Navigation(p => p.Endereco).AutoInclude();
            modelBuilder.Entity<Endereco>().Navigation(e => e.Municipio).AutoInclude();
        }
        public static string ObterStringConexaoBanco()
        {
            return "Host=localhost;Port=5432;Pooling=true;Database=IagroDB;User Id=postgres;Password=123;";
        }
    }
}
