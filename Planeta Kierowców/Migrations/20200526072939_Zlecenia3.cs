using Microsoft.EntityFrameworkCore.Migrations;

namespace Planeta_Kierowców.Migrations
{
    public partial class Zlecenia3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_zlecenie",
                table: "zlecenie");

            migrationBuilder.RenameTable(
                name: "zlecenie",
                newName: "Zlecenia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zlecenia",
                table: "Zlecenia",
                column: "ID_Zlecenie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Zlecenia",
                table: "Zlecenia");

            migrationBuilder.RenameTable(
                name: "Zlecenia",
                newName: "zlecenie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_zlecenie",
                table: "zlecenie",
                column: "ID_Zlecenie");
        }
    }
}
