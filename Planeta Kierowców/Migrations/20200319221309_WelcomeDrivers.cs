using Microsoft.EntityFrameworkCore.Migrations;

namespace Planeta_Kierowców.Migrations
{
    public partial class WelcomeDrivers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kierowca",
                table: "order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kierowca",
                table: "order");
        }
    }
}
