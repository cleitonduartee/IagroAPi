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
        public DbSet<HistoricoMovimentacao> Movimentacoes { get; set; }
        public DbSet<AutoIncrementoHistorico> AutoIncrementaHistorico { get; set; }
        public DbSet<RegistroVacina> RegistroVacinacao { get; set; }
              
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProdutorMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());            
            modelBuilder.ApplyConfiguration(new MunicipioMap());
            modelBuilder.ApplyConfiguration(new PropriedadeMap());
            modelBuilder.ApplyConfiguration(new RebanhoMap());
            modelBuilder.ApplyConfiguration(new HistoricoMovimentacaoMap());
            modelBuilder.ApplyConfiguration(new AutoIncrementoHistoricoMap());
            modelBuilder.ApplyConfiguration(new RegistroVacinacaoMap());

//             modelBuilder.Entity<Rebanho>().Navigation(r => r.Propriedade).AutoInclude();


        }       
    }
}
