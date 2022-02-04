﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class rebanho4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_rebanho_PropriedadeId",
                table: "tb_rebanho");

            migrationBuilder.CreateIndex(
                name: "IX_tb_rebanho_PropriedadeId",
                table: "tb_rebanho",
                column: "PropriedadeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_rebanho_PropriedadeId",
                table: "tb_rebanho");

            migrationBuilder.CreateIndex(
                name: "IX_tb_rebanho_PropriedadeId",
                table: "tb_rebanho",
                column: "PropriedadeId");
        }
    }
}