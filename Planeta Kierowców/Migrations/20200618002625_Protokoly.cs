using Microsoft.EntityFrameworkCore.Migrations;

namespace Planeta_Kierowców.Migrations
{
    public partial class Protokoly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Przedzials",
                table: "Przedzials");

            migrationBuilder.RenameTable(
                name: "Przedzials",
                newName: "Przedzial");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Przedzial",
                table: "Przedzial",
                column: "ID_Przedzial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Przedzial",
                table: "Przedzial");

            migrationBuilder.RenameTable(
                name: "Przedzial",
                newName: "Przedzials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Przedzials",
                table: "Przedzials",
                column: "ID_Przedzial");
        }
    }
}
