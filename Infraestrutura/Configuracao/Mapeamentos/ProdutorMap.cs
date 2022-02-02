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
    public class ProdutorMap : IEntityTypeConfiguration<Produtor>
    {
        public void Configure(EntityTypeBuilder<Produtor> builder)
        {
            builder.ToTable("tb_produtor");
            builder.HasKey(x => x.ProdutorId);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
            builder.HasOne(x=> x.Endereco).WithMany().HasForeignKey(x => x.EnderecoId);               
            
        }
    }
}
