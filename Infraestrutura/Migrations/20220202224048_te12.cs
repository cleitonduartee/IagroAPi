using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infraestrutura.Migrations
{
    public partial class te12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "InscricaoEstadual",
                table: "tb_propriedade",
                type: "integer",
                maxLength: 285999999,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 285999999)
                .Annotation("Npgsql:IdentitySequenceOptions", "'285000000', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "InscricaoEstadual",
                table: "tb_propriedade",
                type: "integer",
                maxLength: 285999999,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 285999999)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'285000000', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
