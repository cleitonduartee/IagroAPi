using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class movimen2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RebanhoOrigemId",
                table: "tb_historico_movimentacao",
                newName: "ProdutorOrigemId");

            migrationBuilder.RenameColumn(
                name: "RebanhoDestinoId",
                table: "tb_historico_movimentacao",
                newName: "ProdutorDestinoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProdutorOrigemId",
                table: "tb_historico_movimentacao",
                newName: "RebanhoOrigemId");

            migrationBuilder.RenameColumn(
                name: "ProdutorDestinoId",
                table: "tb_historico_movimentacao",
                newName: "RebanhoDestinoId");
        }
    }
}
