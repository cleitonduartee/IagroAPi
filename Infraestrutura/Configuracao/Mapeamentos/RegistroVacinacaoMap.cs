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
    internal class RegistroVacinacaoMap : IEntityTypeConfiguration<RegistroVacina>
    {
        public void Configure(EntityTypeBuilder<RegistroVacina> builder)
        {
            builder.ToTable("tb_registro_vacina");
            builder.HasKey(x => x.CodigoRegistro);
            builder.HasOne(x => x.Propriedade).WithMany().HasForeignKey(x => x.PropriedadeId);
            builder.Ignore(x => x.Propriedade);
        }
    
    }
}
