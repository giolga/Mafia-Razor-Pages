using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mafia_Razor_Pages.Migrations
{
    public partial class init3_Player_First_Lose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFirstLose",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstLose",
                table: "Players");
        }
    }
}
