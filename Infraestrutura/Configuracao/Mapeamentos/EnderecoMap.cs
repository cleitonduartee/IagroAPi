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
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("tb_endereco");
            builder.HasKey(x => x.EnderecoId);
            builder.HasOne(x=> x.Municipio).WithMany().HasForeignKey(x => x.MunicipioId);
        }
    }
}
