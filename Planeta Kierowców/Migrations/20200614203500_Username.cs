using Microsoft.EntityFrameworkCore.Migrations;

namespace Planeta_Kierowców.Migrations
{
    public partial class Username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Przedzials",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Przedzials");
        }
    }
}
