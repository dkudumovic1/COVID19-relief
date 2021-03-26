using Microsoft.EntityFrameworkCore.Migrations;

namespace HackAtHome.Data.Migrations
{
    public partial class Migracijaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrojTelefona",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojTelefona",
                table: "AspNetUsers");
        }
    }
}
