using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.UI.Site.Migrations
{
    public partial class RetiraProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Alunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Alunos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
