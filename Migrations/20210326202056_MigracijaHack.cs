using Microsoft.EntityFrameworkCore.Migrations;

namespace HackAtHome.Migrations
{
    public partial class MigracijaHack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Volonter");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Korisnik");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Zahtjev",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Volonter",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Korisnik",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Zahtjev",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Volonter",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Korisnik",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Volonter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
