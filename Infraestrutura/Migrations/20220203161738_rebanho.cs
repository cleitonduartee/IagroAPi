using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infraestrutura.Migrations
{
    public partial class rebanho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_inscricao_estadual");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_tb_propriedade_InscricaoEstadual",
                table: "tb_propriedade");

            migrationBuilder.CreateTable(
                name: "tb_rebanho",
                columns: table => new
                {
                    RebanhoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropriedadeId = table.Column<int>(type: "integer", nullable: false),
                    SaldoSemVacinaBovino = table.Column<int>(type: "integer", nullable: false),
                    SaldoComVacinaBovino = table.Column<int>(type: "integer", nullable: false),
                    SaldoSemVacinaBubalino = table.Column<int>(type: "integer", nullable: false),
                    SaldoComVacinaBubalino = table.Column<int>(type: "integer", nullable: false),
                    DataVacina = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_rebanho", x => x.RebanhoId);
                    table.ForeignKey(
                        name: "FK_tb_rebanho_tb_propriedade_PropriedadeId",
                        column: x => x.PropriedadeId,
                        principalTable: "tb_propriedade",
                        principalColumn: "PropriedadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_rebanho_PropriedadeId",
                table: "tb_rebanho",
                column: "PropriedadeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_rebanho");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tb_propriedade_InscricaoEstadual",
                table: "tb_propriedade",
                column: "InscricaoEstadual");

            migrationBuilder.CreateTable(
                name: "tb_inscricao_estadual",
                columns: table => new
                {
                    IEGerada = table.Column<int>(type: "integer", maxLength: 285999999, nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'285000000', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_inscricao_estadual", x => x.IEGerada);
                });
        }
    }
}
