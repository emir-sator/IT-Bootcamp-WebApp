using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class UploadProjekta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projekat",
                schema: "Identity",
                columns: table => new
                {
                    ProjekatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    TipFajla = table.Column<string>(nullable: true),
                    DatumUploada = table.Column<DateTime>(nullable: false),
                    KursID = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    fajl = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekat", x => x.ProjekatID);
                    table.ForeignKey(
                        name: "FK_Projekat_User_KorisnikId",
                        column: x => x.KorisnikId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projekat_Kursevi_KursID",
                        column: x => x.KursID,
                        principalSchema: "Identity",
                        principalTable: "Kursevi",
                        principalColumn: "KursID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projekat_KorisnikId",
                schema: "Identity",
                table: "Projekat",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekat_KursID",
                schema: "Identity",
                table: "Projekat",
                column: "KursID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projekat",
                schema: "Identity");
        }
    }
}
