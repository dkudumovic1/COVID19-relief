using Microsoft.EntityFrameworkCore.Migrations;

namespace HackAtHome.Migrations
{
    public partial class IzmjenaZahtjeva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VrstaPomoci",
                table: "Zahtjev");

            migrationBuilder.AddColumn<bool>(
                name: "Dostava",
                table: "Zahtjev",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MedicinskaPomoc",
                table: "Zahtjev",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Tutor",
                table: "Zahtjev",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Vakcinisan",
                table: "Zahtjev",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Zavrseno",
                table: "Zahtjev",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ZnakovniJezik",
                table: "Zahtjev",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dostava",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "MedicinskaPomoc",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Tutor",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Vakcinisan",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Zavrseno",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "ZnakovniJezik",
                table: "Zahtjev");

            migrationBuilder.AddColumn<string>(
                name: "VrstaPomoci",
                table: "Zahtjev",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
