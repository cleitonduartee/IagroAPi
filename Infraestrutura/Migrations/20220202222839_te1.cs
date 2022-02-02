using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class te1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_propriedade",
                table: "tb_propriedade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_propriedade",
                table: "tb_propriedade",
                column: "PropriedadeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_propriedade_ProdutorId",
                table: "tb_propriedade",
                column: "ProdutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_propriedade",
                table: "tb_propriedade");

            migrationBuilder.DropIndex(
                name: "IX_tb_propriedade_ProdutorId",
                table: "tb_propriedade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_propriedade",
                table: "tb_propriedade",
                column: "ProdutorId");
        }
    }
}
