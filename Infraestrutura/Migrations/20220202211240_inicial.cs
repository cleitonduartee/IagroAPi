using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infraestrutura.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_inscricao_estadual",
                columns: table => new
                {
                    IE = table.Column<int>(type: "integer", maxLength: 285999999, nullable: false, defaultValue: 285000000)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_inscricao_estadual", x => x.IE);
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
                    ProdutorId = table.Column<int>(type: "integer", nullable: false),
                    PropriedadeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InscricaoEstadual = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Saldo = table.Column<int>(type: "integer", nullable: false),
                    SaldoVacinado = table.Column<int>(type: "integer", nullable: false),
                    MunicipioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_propriedade", x => x.ProdutorId);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_inscricao_estadual");

            migrationBuilder.DropTable(
                name: "tb_propriedade");

            migrationBuilder.DropTable(
                name: "tb_produtor");

            migrationBuilder.DropTable(
                name: "tb_endereco");

            migrationBuilder.DropTable(
                name: "tb_municipio");
        }
    }
}
