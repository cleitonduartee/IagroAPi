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
    public class HistoricoMovimentacaoMap :  IEntityTypeConfiguration<HistoricoMovimentacao>
    {
        public void Configure(EntityTypeBuilder<HistoricoMovimentacao> builder)
        {
            builder.ToTable("tb_historico_movimentacao");
            builder.HasKey(x => x.CodigoHistorico);
        }
    }
}
