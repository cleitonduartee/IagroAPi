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
        public DbSet<Propriedade> Propriedades { get; set; }
        public DbSet<Rebanho> Rebanhos { get; set; }
              
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProdutorMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());            
            modelBuilder.ApplyConfiguration(new MunicipioMap());
            modelBuilder.ApplyConfiguration(new PropriedadeMap());
            modelBuilder.ApplyConfiguration(new RebanhoMap());

            

            //modelBuilder.Entity<Produtor>().Navigation(p => p.Endereco).AutoInclude();
            //modelBuilder.Entity<Endereco>().Navigation(e => e.Municipio).AutoInclude();
            //modelBuilder.Entity<Propriedade>().Navigation(e => e.Municipio).AutoInclude();
        }       
    }
}
