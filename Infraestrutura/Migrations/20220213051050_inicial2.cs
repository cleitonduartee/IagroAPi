using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infraestrutura.Migrations
{
    public partial class inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "PropriedadeId",
                table: "tb_rebanho",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_rebanho_tb_propriedade_PropriedadeId",
                table: "tb_rebanho",
                column: "PropriedadeId",
                principalTable: "tb_propriedade",
                principalColumn: "PropriedadeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_rebanho_tb_propriedade_PropriedadeId",
                table: "tb_rebanho");

            migrationBuilder.AlterColumn<int>(
                name: "PropriedadeId",
                table: "tb_rebanho",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "RebanhoId",
                table: "tb_propriedade",
                type: "integer",
                nullable: true);

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
                principalColumn: "PropriedadeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
