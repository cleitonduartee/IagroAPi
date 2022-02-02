﻿using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Configuracao.Mapeamentos
{
    public class PropriedadeMap : IEntityTypeConfiguration<Propriedade>
    {
        public void Configure(EntityTypeBuilder<Propriedade> builder)
        {
            builder.ToTable("tb_propriedade");
            builder.HasKey(x => x.ProdutorId);
            builder.HasOne(x => x.Produtor).WithMany().HasForeignKey(x => x.ProdutorId);
            builder.HasOne(x=> x.Municipio).WithMany().HasForeignKey(x => x.MunicipioId);               
            
        }
    }
}