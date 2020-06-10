using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planeta_Kierowców.Migrations
{
    public partial class Kalendarz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Przedzials",
                columns: table => new
                {
                    ID_Przedzial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kierowca_ID = table.Column<string>(nullable: false),
                    Od = table.Column<DateTime>(nullable: false),
                    Do = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przedzials", x => x.ID_Przedzial);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Przedzials");
        }
    }
}
