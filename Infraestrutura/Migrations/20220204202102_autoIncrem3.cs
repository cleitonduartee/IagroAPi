using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class autoIncrem3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_historico_movimentacao_tb_propriedade_PropriedadeId",
                table: "tb_historico_movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_tb_historico_movimentacao_PropriedadeId",
                table: "tb_historico_movimentacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_historico_movimentacao_PropriedadeId",
                table: "tb_historico_movimentacao",
                column: "PropriedadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_historico_movimentacao_tb_propriedade_PropriedadeId",
                table: "tb_historico_movimentacao",
                column: "PropriedadeId",
                principalTable: "tb_propriedade",
                principalColumn: "PropriedadeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
