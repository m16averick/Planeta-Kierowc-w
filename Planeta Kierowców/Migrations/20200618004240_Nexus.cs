using Microsoft.EntityFrameworkCore.Migrations;

namespace Planeta_Kierowców.Migrations
{
    public partial class Nexus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Protokoly",
                columns: table => new
                {
                    ID_Protokol = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zlecenie_ID = table.Column<int>(nullable: false),
                    filepath = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protokoly", x => x.ID_Protokol);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Protokoly");

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
    }
}
