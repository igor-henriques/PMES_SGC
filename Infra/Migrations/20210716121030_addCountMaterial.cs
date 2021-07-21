using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class addCountMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classification",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Material",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Material");

            migrationBuilder.AddColumn<int>(
                name: "Classification",
                table: "Usuario",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
