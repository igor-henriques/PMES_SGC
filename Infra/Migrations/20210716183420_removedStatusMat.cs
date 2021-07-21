using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class removedStatusMat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Material");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Material",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
