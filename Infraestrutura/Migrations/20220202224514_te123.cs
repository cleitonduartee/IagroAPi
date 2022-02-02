using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class te123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_tb_propriedade_InscricaoEstadual",
                table: "tb_propriedade",
                column: "InscricaoEstadual");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_tb_propriedade_InscricaoEstadual",
                table: "tb_propriedade");
        }
    }
}
