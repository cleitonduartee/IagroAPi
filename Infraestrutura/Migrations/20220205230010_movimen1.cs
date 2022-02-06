using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class movimen1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RebanhoId",
                table: "tb_historico_movimentacao",
                newName: "RebanhoDestinoId");

            migrationBuilder.RenameColumn(
                name: "PropriedadeId",
                table: "tb_historico_movimentacao",
                newName: "PropriedadeDestinoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataMovimentacao",
                table: "tb_historico_movimentacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoMovimentacaoDaCompra",
                table: "tb_historico_movimentacao",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropriedadeOrigemId",
                table: "tb_historico_movimentacao",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RebanhoOrigemId",
                table: "tb_historico_movimentacao",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoMovimentacaoDaCompra",
                table: "tb_historico_movimentacao");

            migrationBuilder.DropColumn(
                name: "PropriedadeOrigemId",
                table: "tb_historico_movimentacao");

            migrationBuilder.DropColumn(
                name: "RebanhoOrigemId",
                table: "tb_historico_movimentacao");

            migrationBuilder.RenameColumn(
                name: "RebanhoDestinoId",
                table: "tb_historico_movimentacao",
                newName: "RebanhoId");

            migrationBuilder.RenameColumn(
                name: "PropriedadeDestinoId",
                table: "tb_historico_movimentacao",
                newName: "PropriedadeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataMovimentacao",
                table: "tb_historico_movimentacao",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
