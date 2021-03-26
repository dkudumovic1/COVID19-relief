using Microsoft.EntityFrameworkCore.Migrations;

namespace HackAtHome.Migrations
{
    public partial class Inicijalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    BrojTelefona = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Grad = table.Column<string>(nullable: true),
                    OsobaSaPoteskocamaSluha = table.Column<bool>(nullable: false),
                    OsobaUIzolaciji = table.Column<bool>(nullable: false),
                    StarijaOsoba = table.Column<bool>(nullable: false),
                    Dijete = table.Column<bool>(nullable: false),
                    GeografskaSirina = table.Column<string>(nullable: true),
                    GeografskaDuzina = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Volonter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    BrojTelefona = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Grad = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    MedicinskiRadnik = table.Column<bool>(nullable: false),
                    Dostava = table.Column<bool>(nullable: false),
                    Tutor = table.Column<bool>(nullable: false),
                    ZnakovniJezik = table.Column<bool>(nullable: false),
                    Vakcinisan = table.Column<bool>(nullable: false),
                    GeografskaSirina = table.Column<string>(nullable: true),
                    GeografskaDuzina = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volonter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaPomoci = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Volonter");

            migrationBuilder.DropTable(
                name: "Zahtjev");
        }
    }
}
