using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class historico1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_historico_movimentacao",
                columns: table => new
                {
                    CodigoHistorico = table.Column<string>(type: "text", nullable: false),
                    RebanhoId = table.Column<int>(type: "integer", nullable: false),
                    PropriedadeId = table.Column<int>(type: "integer", nullable: false),
                    TipoMovimentacao = table.Column<int>(type: "integer", nullable: false),
                    QtdSemVacinaBovino = table.Column<int>(type: "integer", nullable: false),
                    QtdComVacinaBovino = table.Column<int>(type: "integer", nullable: false),
                    QtdSemVacinaBubalino = table.Column<int>(type: "integer", nullable: false),
                    QtdComVacinaBubalino = table.Column<int>(type: "integer", nullable: false),
                    DataVacina = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_historico_movimentacao", x => x.CodigoHistorico);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_historico_movimentacao");
        }
    }
}
