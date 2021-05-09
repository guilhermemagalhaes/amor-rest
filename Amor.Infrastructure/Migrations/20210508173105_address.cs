using Microsoft.EntityFrameworkCore.Migrations;

namespace Amor.Infrastructure.Migrations
{
    public partial class address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressDesc",
                table: "Address",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Address",
                newName: "AddressDesc");
        }
    }
}
