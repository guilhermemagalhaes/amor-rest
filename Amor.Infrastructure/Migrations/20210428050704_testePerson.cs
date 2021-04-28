using Microsoft.EntityFrameworkCore.Migrations;

namespace Amor.Infrastructure.Migrations
{
    public partial class testePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PhysicalPerson_PersonId",
                table: "PhysicalPerson");

            migrationBuilder.DropIndex(
                name: "IX_LegalPerson_PersonId",
                table: "LegalPerson");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPerson_PersonId",
                table: "PhysicalPerson",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalPerson_PersonId",
                table: "LegalPerson",
                column: "PersonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PhysicalPerson_PersonId",
                table: "PhysicalPerson");

            migrationBuilder.DropIndex(
                name: "IX_LegalPerson_PersonId",
                table: "LegalPerson");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPerson_PersonId",
                table: "PhysicalPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPerson_PersonId",
                table: "LegalPerson",
                column: "PersonId");
        }
    }
}
