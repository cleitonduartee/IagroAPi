using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infraestrutura.Migrations
{
    public partial class rebanho101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_registro_vacina",
                table: "tb_registro_vacina");

            migrationBuilder.DropColumn(
                name: "RegistroVacinaId",
                table: "tb_registro_vacina");

            migrationBuilder.AddColumn<string>(
                name: "CodigoRegistro",
                table: "tb_registro_vacina",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_registro_vacina",
                table: "tb_registro_vacina",
                column: "CodigoRegistro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_registro_vacina",
                table: "tb_registro_vacina");

            migrationBuilder.DropColumn(
                name: "CodigoRegistro",
                table: "tb_registro_vacina");

            migrationBuilder.AddColumn<int>(
                name: "RegistroVacinaId",
                table: "tb_registro_vacina",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_registro_vacina",
                table: "tb_registro_vacina",
                column: "RegistroVacinaId");
        }
    }
}
