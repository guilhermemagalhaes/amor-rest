using Microsoft.EntityFrameworkCore.Migrations;

namespace Amor.Infrastructure.Migrations
{
    public partial class baseGetSearchOnMyLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchOnMyLocation",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: true),
                    HomelessId = table.Column<int>(type: "int", nullable: true),
                    OngId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchOnMyLocation");
        }
    }
}
