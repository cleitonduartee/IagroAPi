using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class rebanho13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_rebanho_tb_propriedade_PropriedadeId",
                table: "tb_rebanho");

            migrationBuilder.DropIndex(
                name: "IX_tb_rebanho_PropriedadeId",
                table: "tb_rebanho");

            migrationBuilder.DropColumn(
                name: "PropriedadeId",
                table: "tb_rebanho");

            migrationBuilder.AddColumn<int>(
                name: "RebanhoId",
                table: "tb_propriedade",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_propriedade_RebanhoId",
                table: "tb_propriedade",
                column: "RebanhoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_propriedade_tb_rebanho_RebanhoId",
                table: "tb_propriedade",
                column: "RebanhoId",
                principalTable: "tb_rebanho",
                principalColumn: "RebanhoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_propriedade_tb_rebanho_RebanhoId",
                table: "tb_propriedade");

            migrationBuilder.DropIndex(
                name: "IX_tb_propriedade_RebanhoId",
                table: "tb_propriedade");

            migrationBuilder.DropColumn(
                name: "RebanhoId",
                table: "tb_propriedade");

            migrationBuilder.AddColumn<int>(
                name: "PropriedadeId",
                table: "tb_rebanho",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_rebanho_PropriedadeId",
                table: "tb_rebanho",
                column: "PropriedadeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_rebanho_tb_propriedade_PropriedadeId",
                table: "tb_rebanho",
                column: "PropriedadeId",
                principalTable: "tb_propriedade",
                principalColumn: "PropriedadeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
