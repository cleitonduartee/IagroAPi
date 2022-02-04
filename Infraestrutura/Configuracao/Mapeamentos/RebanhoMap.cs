using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Configuracao.Mapeamentos
{
    public class RebanhoMap : IEntityTypeConfiguration<Rebanho>
    {
        public void Configure(EntityTypeBuilder<Rebanho> builder)
        {
            builder.ToTable("tb_rebanho");
            builder.HasKey(x => x.RebanhoId);

            builder.HasOne(r => r.Propriedade).WithOne(p => p.Rebanho).HasForeignKey<Rebanho>(r => r.PropriedadeId);

        }
    }
}
