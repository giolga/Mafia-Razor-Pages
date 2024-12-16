using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mafia_Razor_Pages.Migrations
{
    public partial class init7_GameAction_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Character = table.Column<string>(type: "TEXT", nullable: false),
                    TargetSeatNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameActions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameActions");
        }
    }
}
