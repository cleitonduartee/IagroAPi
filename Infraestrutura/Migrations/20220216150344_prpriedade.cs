using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class prpriedade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "tb_propriedade");

            migrationBuilder.DropColumn(
                name: "SaldoVacinado",
                table: "tb_propriedade");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaVacinacao",
                table: "tb_propriedade",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataUltimaVacinacao",
                table: "tb_propriedade");

            migrationBuilder.AddColumn<int>(
                name: "Saldo",
                table: "tb_propriedade",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaldoVacinado",
                table: "tb_propriedade",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
