﻿// <auto-generated />
using Infraestrutura.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infraestrutura.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20220202224048_te12")]
    partial class te12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Entidades.Entidades.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MunicipioId")
                        .HasColumnType("integer");

                    b.Property<string>("NomeRua")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.HasKey("EnderecoId");

                    b.HasIndex("MunicipioId");

                    b.ToTable("tb_endereco");
                });

            modelBuilder.Entity("Entidades.Entidades.InscricaoEstadual", b =>
                {
                    b.Property<int>("IEGerada")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(285999999)
                        .HasColumnType("integer")
                        .HasIdentityOptions(285000000L, null, null, null, null, null)
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("IEGerada");

                    b.ToTable("tb_inscricao_estadual");
                });

            modelBuilder.Entity("Entidades.Entidades.Municipio", b =>
                {
                    b.Property<int>("MunicipioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("MunicipioId");

                    b.ToTable("tb_municipio");
                });

            modelBuilder.Entity("Entidades.Entidades.Produtor", b =>
                {
                    b.Property<int>("ProdutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("ProdutorId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("tb_produtor");
                });

            modelBuilder.Entity("Entidades.Entidades.Propriedade", b =>
                {
                    b.Property<int>("PropriedadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("InscricaoEstadual")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(285999999)
                        .HasColumnType("integer")
                        .HasIdentityOptions(285000000L, null, null, null, null, null)
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MunicipioId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("ProdutorId")
                        .HasColumnType("integer");

                    b.Property<int>("Saldo")
                        .HasColumnType("integer");

                    b.Property<int>("SaldoVacinado")
                        .HasColumnType("integer");

                    b.HasKey("PropriedadeId");

                    b.HasIndex("MunicipioId");

                    b.HasIndex("ProdutorId");

                    b.ToTable("tb_propriedade");
                });

            modelBuilder.Entity("Entidades.Entidades.Endereco", b =>
                {
                    b.HasOne("Entidades.Entidades.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("Entidades.Entidades.Produtor", b =>
                {
                    b.HasOne("Entidades.Entidades.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Entidades.Entidades.Propriedade", b =>
                {
                    b.HasOne("Entidades.Entidades.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.Produtor", "Produtor")
                        .WithMany()
                        .HasForeignKey("ProdutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipio");

                    b.Navigation("Produtor");
                });
#pragma warning restore 612, 618
        }
    }
}
