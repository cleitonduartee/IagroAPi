using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class renomeColIE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IE",
                table: "tb_inscricao_estadual",
                newName: "IEGerada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IEGerada",
                table: "tb_inscricao_estadual",
                newName: "IE");
        }
    }
}
