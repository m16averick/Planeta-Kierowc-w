using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planeta_Kierowców.Migrations
{
    public partial class Zlecenia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.CreateTable(
                name: "zlecenie",
                columns: table => new
                {
                    ID_Zlecenie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miejsce_odbioru = table.Column<string>(nullable: false),
                    Czas_odbioru = table.Column<DateTime>(nullable: false),
                    Miejsce_zdania = table.Column<string>(nullable: false),
                    Czas_zdania = table.Column<DateTime>(nullable: false),
                    Status_zlecenia = table.Column<string>(nullable: true),
                    Kierowca_ID = table.Column<string>(nullable: true),
                    Koordynator_ID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zlecenie", x => x.ID_Zlecenie);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "zlecenie");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kierowca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rodzaj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.Id);
                });
        }
    }
}
