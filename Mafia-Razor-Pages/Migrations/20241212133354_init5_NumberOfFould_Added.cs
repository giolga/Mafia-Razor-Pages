using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mafia_Razor_Pages.Migrations
{
    public partial class init5_NumberOfFould_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfFouls",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfFouls",
                table: "Players");
        }
    }
}
