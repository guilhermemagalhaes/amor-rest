using Microsoft.EntityFrameworkCore.Migrations;

namespace Amor.Infrastructure.Migrations
{
    public partial class latlong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Address",
                type: "decimal(12,9)",
                precision: 12,
                scale: 9,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Address",
                type: "decimal(12,9)",
                precision: 12,
                scale: 9,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Address",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,9)",
                oldPrecision: 12,
                oldScale: 9);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Address",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,9)",
                oldPrecision: 12,
                oldScale: 9);
        }
    }
}
