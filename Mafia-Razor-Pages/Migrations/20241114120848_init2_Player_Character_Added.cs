using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mafia_Razor_Pages.Migrations
{
    public partial class init2_Player_Character_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Character",
                table: "Players",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Character",
                table: "Players");
        }
    }
}
