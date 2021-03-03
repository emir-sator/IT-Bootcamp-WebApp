using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class dodavanjeKursa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kursevi",
                schema: "Identity",
                columns: table => new
                {
                    KursID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Oznaka = table.Column<string>(nullable: true),
                    Cijena = table.Column<int>(nullable: false),
                    DatumPocetka = table.Column<DateTime>(nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Aktivan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursevi", x => x.KursID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kursevi",
                schema: "Identity");
        }
    }
}
