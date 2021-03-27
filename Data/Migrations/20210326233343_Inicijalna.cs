using Microsoft.EntityFrameworkCore.Migrations;

namespace HackAtHome.Data.Migrations
{
    public partial class Inicijalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VolonterId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VolonterId",
                table: "AspNetUsers");
        }
    }
}
