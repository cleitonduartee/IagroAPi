using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infraestrutura.Migrations
{
    public partial class IERedefine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IEGerada",
                table: "tb_inscricao_estadual",
                type: "integer",
                maxLength: 285999999,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 285999999,
                oldDefaultValue: 285000000)
                .Annotation("Npgsql:IdentitySequenceOptions", "'285000000', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IEGerada",
                table: "tb_inscricao_estadual",
                type: "integer",
                maxLength: 285999999,
                nullable: false,
                defaultValue: 285000000,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 285999999)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'285000000', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
