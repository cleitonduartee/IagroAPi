using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infraestrutura.Migrations
{
    public partial class registro3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_registro_vacina",
                columns: table => new
                {
                    RegistroVacinaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropriedadeId = table.Column<int>(type: "integer", nullable: false),
                    TipoVacina = table.Column<int>(type: "integer", nullable: false),
                    QtdBovinoVacinado = table.Column<int>(type: "integer", nullable: false),
                    QtdBubalinoVacinado = table.Column<int>(type: "integer", nullable: false),
                    DataVacinacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_registro_vacina", x => x.RegistroVacinaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_registro_vacina");
        }
    }
}
