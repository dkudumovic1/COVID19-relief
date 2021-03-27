using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HackAtHome.Migrations
{
    public partial class IzmjenaBaze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Zahtjev",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Zahtjev");
        }
    }
}
