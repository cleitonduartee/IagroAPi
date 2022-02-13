using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infraestrutura.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_auto_incremento_historico",
                columns: table => new
                {
                    IdGerado = table.Column<int>(type: "integer", maxLength: 99999, nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_auto_incremento_historico", x => x.IdGerado);
                });

            migrationBuilder.CreateTable(
                name: "tb_historico_movimentacao",
                columns: table => new
                {
                    CodigoHistorico = table.Column<string>(type: "text", nullable: false),
                    CodigoMovimentacaoDaCompra = table.Column<string>(type: "text", nullable: true),
                    PropriedadeOrigemId = table.Column<int>(type: "integer", nullable: true),
                    PropriedadeDestinoId = table.Column<int>(type: "integer", nullable: false),
                    ProdutorOrigemId = table.Column<int>(type: "integer", nullable: true),
                    ProdutorDestinoId = table.Column<int>(type: "integer", nullable: false),
                    TipoMovimentacao = table.Column<int>(type: "integer", nullable: false),
                    QtdSemVacinaBovino = table.Column<int>(type: "integer", nullable: false),
                    QtdComVacinaBovino = table.Column<int>(type: "integer", nullable: false),
                    QtdSemVacinaBubalino = table.Column<int>(type: "integer", nullable: false),
                    QtdComVacinaBubalino = table.Column<int>(type: "integer", nullable: false),
                    DataMovimentacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataCancelamento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Finalidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_historico_movimentacao", x => x.CodigoHistorico);
                });

            migrationBuilder.CreateTable(
                name: "tb_municipio",
                columns: table => new
                {
                    MunicipioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_municipio", x => x.MunicipioId);
                });

            migrationBuilder.CreateTable(
                name: "tb_rebanho",
                columns: table => new
                {
                    PropriedadeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RebanhoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SaldoSemVacinaBovino = table.Column<int>(type: "integer", nullable: false),
                    SaldoComVacinaBovino = table.Column<int>(type: "integer", nullable: false),
                    SaldoSemVacinaBubalino = table.Column<int>(type: "integer", nullable: false),
                    SaldoComVacinaBubalino = table.Column<int>(type: "integer", nullable: false),
                    DataVacina = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataUltimaVenda = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_rebanho", x => x.PropriedadeId);
                });

            migrationBuilder.CreateTable(
                name: "tb_registro_vacina",
                columns: table => new
                {
                    CodigoRegistro = table.Column<string>(type: "text", nullable: false),
                    PropriedadeId = table.Column<int>(type: "integer", nullable: false),
                    TipoVacina = table.Column<int>(type: "integer", nullable: false),
                    QtdBovinoVacinado = table.Column<int>(type: "integer", nullable: false),
                    QtdBubalinoVacinado = table.Column<int>(type: "integer", nullable: false),
                    DataVacinacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataCancelamento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_registro_vacina", x => x.CodigoRegistro);
                });

            migrationBuilder.CreateTable(
                name: "tb_endereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeRua = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    MunicipioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_endereco", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_tb_endereco_tb_municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "tb_municipio",
                        principalColumn: "MunicipioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_produtor",
                columns: table => new
                {
                    ProdutorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    EnderecoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produtor", x => x.ProdutorId);
                    table.ForeignKey(
                        name: "FK_tb_produtor_tb_endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "tb_endereco",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_propriedade",
                columns: table => new
                {
                    PropriedadeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InscricaoEstadual = table.Column<int>(type: "integer", maxLength: 285999999, nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'285000000', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Saldo = table.Column<int>(type: "integer", nullable: false),
                    SaldoVacinado = table.Column<int>(type: "integer", nullable: false),
                    ProdutorId = table.Column<int>(type: "integer", nullable: false),
                    MunicipioId = table.Column<int>(type: "integer", nullable: false),
                    RebanhoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_propriedade", x => x.PropriedadeId);
                    table.ForeignKey(
                        name: "FK_tb_propriedade_tb_municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "tb_municipio",
                        principalColumn: "MunicipioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_propriedade_tb_produtor_ProdutorId",
                        column: x => x.ProdutorId,
                        principalTable: "tb_produtor",
                        principalColumn: "ProdutorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_propriedade_tb_rebanho_RebanhoId",
                        column: x => x.RebanhoId,
                        principalTable: "tb_rebanho",
                        principalColumn: "PropriedadeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_endereco_MunicipioId",
                table: "tb_endereco",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtor_EnderecoId",
                table: "tb_produtor",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_propriedade_MunicipioId",
                table: "tb_propriedade",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_propriedade_ProdutorId",
                table: "tb_propriedade",
                column: "ProdutorId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_propriedade_RebanhoId",
                table: "tb_propriedade",
                column: "RebanhoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_auto_incremento_historico");

            migrationBuilder.DropTable(
                name: "tb_historico_movimentacao");

            migrationBuilder.DropTable(
                name: "tb_propriedade");

            migrationBuilder.DropTable(
                name: "tb_registro_vacina");

            migrationBuilder.DropTable(
                name: "tb_produtor");

            migrationBuilder.DropTable(
                name: "tb_rebanho");

            migrationBuilder.DropTable(
                name: "tb_endereco");

            migrationBuilder.DropTable(
                name: "tb_municipio");
        }
    }
}
