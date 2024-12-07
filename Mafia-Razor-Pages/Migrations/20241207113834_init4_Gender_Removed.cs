using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mafia_Razor_Pages.Migrations
{
    public partial class init4_Gender_Removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Players");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
