using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class testPredavanje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kabinet",
                schema: "Identity",
                columns: table => new
                {
                    KabinetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Kapacitet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kabinet", x => x.KabinetID);
                });

            migrationBuilder.CreateTable(
                name: "TipDokumenta",
                schema: "Identity",
                columns: table => new
                {
                    TipDokumentaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipDokumenta", x => x.TipDokumentaID);
                });

            migrationBuilder.CreateTable(
                name: "Predavanje",
                schema: "Identity",
                columns: table => new
                {
                    PredavanjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    SatnicaPocetka = table.Column<TimeSpan>(nullable: false),
                    SatnicaZavrsetka = table.Column<TimeSpan>(nullable: false),
                    KursID = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<string>(nullable: true),
                    KabinetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predavanje", x => x.PredavanjeID);
                    table.ForeignKey(
                        name: "FK_Predavanje_Kabinet_KabinetID",
                        column: x => x.KabinetID,
                        principalSchema: "Identity",
                        principalTable: "Kabinet",
                        principalColumn: "KabinetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Predavanje_User_KorisnikId",
                        column: x => x.KorisnikId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Predavanje_Kursevi_KursID",
                        column: x => x.KursID,
                        principalSchema: "Identity",
                        principalTable: "Kursevi",
                        principalColumn: "KursID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dokument",
                schema: "Identity",
                columns: table => new
                {
                    DokumentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(nullable: true),
                    Fajl = table.Column<byte[]>(nullable: true),
                    DatumObjavljivanja = table.Column<DateTime>(nullable: false),
                    SatnicaObjavljivanja = table.Column<TimeSpan>(nullable: false),
                    KorisnikId = table.Column<string>(nullable: true),
                    KursID = table.Column<int>(nullable: false),
                    TipDokumentaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.DokumentID);
                    table.ForeignKey(
                        name: "FK_Dokument_User_KorisnikId",
                        column: x => x.KorisnikId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dokument_Kursevi_KursID",
                        column: x => x.KursID,
                        principalSchema: "Identity",
                        principalTable: "Kursevi",
                        principalColumn: "KursID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dokument_TipDokumenta_TipDokumentaID",
                        column: x => x.TipDokumentaID,
                        principalSchema: "Identity",
                        principalTable: "TipDokumenta",
                        principalColumn: "TipDokumentaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_KorisnikId",
                schema: "Identity",
                table: "Dokument",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_KursID",
                schema: "Identity",
                table: "Dokument",
                column: "KursID");

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_TipDokumentaID",
                schema: "Identity",
                table: "Dokument",
                column: "TipDokumentaID");

            migrationBuilder.CreateIndex(
                name: "IX_Predavanje_KabinetID",
                schema: "Identity",
                table: "Predavanje",
                column: "KabinetID");

            migrationBuilder.CreateIndex(
                name: "IX_Predavanje_KorisnikId",
                schema: "Identity",
                table: "Predavanje",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Predavanje_KursID",
                schema: "Identity",
                table: "Predavanje",
                column: "KursID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokument",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Predavanje",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TipDokumenta",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Kabinet",
                schema: "Identity");
        }
    }
}
