using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Configuracao.Mapeamentos
{
    public class AutoIncrementoHistoricoMap : IEntityTypeConfiguration<AutoIncrementoHistorico>
    {
        public void Configure(EntityTypeBuilder<AutoIncrementoHistorico> builder)
        {
            builder.ToTable("tb_auto_incremento_historico");
            builder.HasKey(x => x.IdGerado);
            builder.Property(x => x.IdGerado).HasIdentityOptions(startValue: 00001)
                                                      .HasMaxLength(99999);

        }
    }
}
