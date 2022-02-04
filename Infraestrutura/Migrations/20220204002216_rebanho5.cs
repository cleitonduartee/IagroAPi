using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class rebanho5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_rebanho_tb_propriedade_PropriedadeId",
                table: "tb_rebanho");

            migrationBuilder.DropIndex(
                name: "IX_tb_rebanho_PropriedadeId",
                table: "tb_rebanho");

            migrationBuilder.AddColumn<int>(
                name: "PropriedadeId1",
                table: "tb_rebanho",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RebanhoId",
                table: "tb_propriedade",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_rebanho_PropriedadeId1",
                table: "tb_rebanho",
                column: "PropriedadeId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_tb_rebanho_tb_propriedade_PropriedadeId1",
                table: "tb_rebanho",
                column: "PropriedadeId1",
                principalTable: "tb_propriedade",
                principalColumn: "PropriedadeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_propriedade_tb_rebanho_RebanhoId",
                table: "tb_propriedade");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_rebanho_tb_propriedade_PropriedadeId1",
                table: "tb_rebanho");

            migrationBuilder.DropIndex(
                name: "IX_tb_rebanho_PropriedadeId1",
                table: "tb_rebanho");

            migrationBuilder.DropIndex(
                name: "IX_tb_propriedade_RebanhoId",
                table: "tb_propriedade");

            migrationBuilder.DropColumn(
                name: "PropriedadeId1",
                table: "tb_rebanho");

            migrationBuilder.DropColumn(
                name: "RebanhoId",
                table: "tb_propriedade");

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
