using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class rebanho6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_rebanho_tb_propriedade_PropriedadeId1",
                table: "tb_rebanho");

            migrationBuilder.DropIndex(
                name: "IX_tb_rebanho_PropriedadeId1",
                table: "tb_rebanho");

            migrationBuilder.DropColumn(
                name: "PropriedadeId1",
                table: "tb_rebanho");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropriedadeId1",
                table: "tb_rebanho",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_rebanho_PropriedadeId1",
                table: "tb_rebanho",
                column: "PropriedadeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_rebanho_tb_propriedade_PropriedadeId1",
                table: "tb_rebanho",
                column: "PropriedadeId1",
                principalTable: "tb_propriedade",
                principalColumn: "PropriedadeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
