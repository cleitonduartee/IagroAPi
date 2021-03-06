// <auto-generated />
using System;
using Infraestrutura.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infraestrutura.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Entidades.Entidades.AutoIncrementoHistorico", b =>
                {
                    b.Property<int>("IdGerado")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(99999)
                        .HasColumnType("integer")
                        .HasIdentityOptions(1L, null, null, null, null, null)
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("IdGerado");

                    b.ToTable("tb_auto_incremento_historico");
                });

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

            modelBuilder.Entity("Entidades.Entidades.HistoricoMovimentacao", b =>
                {
                    b.Property<string>("CodigoHistorico")
                        .HasColumnType("text");

                    b.Property<string>("CodigoMovimentacaoDaCompra")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataCancelamento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataMovimentacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Finalidade")
                        .HasColumnType("integer");

                    b.Property<int>("ProdutorDestinoId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProdutorOrigemId")
                        .HasColumnType("integer");

                    b.Property<int>("PropriedadeDestinoId")
                        .HasColumnType("integer");

                    b.Property<int?>("PropriedadeOrigemId")
                        .HasColumnType("integer");

                    b.Property<int>("QtdComVacinaBovino")
                        .HasColumnType("integer");

                    b.Property<int>("QtdComVacinaBubalino")
                        .HasColumnType("integer");

                    b.Property<int>("QtdSemVacinaBovino")
                        .HasColumnType("integer");

                    b.Property<int>("QtdSemVacinaBubalino")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TipoMovimentacao")
                        .HasColumnType("integer");

                    b.HasKey("CodigoHistorico");

                    b.ToTable("tb_historico_movimentacao");
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

                    b.Property<DateTime?>("DataUltimaVacinacao")
                        .HasColumnType("timestamp without time zone");

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

                    b.HasKey("PropriedadeId");

                    b.HasIndex("MunicipioId");

                    b.HasIndex("ProdutorId");

                    b.ToTable("tb_propriedade");
                });

            modelBuilder.Entity("Entidades.Entidades.Rebanho", b =>
                {
                    b.Property<int>("PropriedadeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DataUltimaVenda")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataVacina")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("RebanhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("SaldoComVacinaBovino")
                        .HasColumnType("integer");

                    b.Property<int>("SaldoComVacinaBubalino")
                        .HasColumnType("integer");

                    b.Property<int>("SaldoSemVacinaBovino")
                        .HasColumnType("integer");

                    b.Property<int>("SaldoSemVacinaBubalino")
                        .HasColumnType("integer");

                    b.HasKey("PropriedadeId");

                    b.ToTable("tb_rebanho");
                });

            modelBuilder.Entity("Entidades.Entidades.RegistroVacina", b =>
                {
                    b.Property<string>("CodigoRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DataCancelamento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataVacinacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PropriedadeId")
                        .HasColumnType("integer");

                    b.Property<int>("QtdBovinoVacinado")
                        .HasColumnType("integer");

                    b.Property<int>("QtdBubalinoVacinado")
                        .HasColumnType("integer");

                    b.Property<int>("TipoVacina")
                        .HasColumnType("integer");

                    b.HasKey("CodigoRegistro");

                    b.ToTable("tb_registro_vacina");
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

            modelBuilder.Entity("Entidades.Entidades.Rebanho", b =>
                {
                    b.HasOne("Entidades.Entidades.Propriedade", "Propriedade")
                        .WithOne("Rebanho")
                        .HasForeignKey("Entidades.Entidades.Rebanho", "PropriedadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propriedade");
                });

            modelBuilder.Entity("Entidades.Entidades.Propriedade", b =>
                {
                    b.Navigation("Rebanho");
                });
#pragma warning restore 612, 618
        }
    }
}
