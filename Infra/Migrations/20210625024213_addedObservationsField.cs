using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class addedObservationsField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observations",
                table: "Cautela",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observations",
                table: "Cautela");
        }
    }
}
