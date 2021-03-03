using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class crudTabeleEmir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumPrijave",
                schema: "Identity",
                table: "KorisnikKurs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DrzavaID",
                schema: "Identity",
                table: "Grad",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ciklus",
                schema: "Identity",
                columns: table => new
                {
                    CiklusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciklus", x => x.CiklusID);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                schema: "Identity",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Grupa",
                schema: "Identity",
                columns: table => new
                {
                    GrupaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupa", x => x.GrupaID);
                });

            migrationBuilder.CreateTable(
                name: "Predavac",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    KorisnikId = table.Column<string>(nullable: true),
                    mjestoRodjenja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predavac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predavac_User_KorisnikId",
                        column: x => x.KorisnikId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Drzava",
                columns: new[] { "DrzavaID", "Naziv" },
                values: new object[] { 1, "BiH" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Grad",
                keyColumn: "GradID",
                keyValue: 1,
                column: "DrzavaID",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                schema: "Identity",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Predavac_KorisnikId",
                schema: "Identity",
                table: "Predavac",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grad_Drzava_DrzavaID",
                schema: "Identity",
                table: "Grad",
                column: "DrzavaID",
                principalSchema: "Identity",
                principalTable: "Drzava",
                principalColumn: "DrzavaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grad_Drzava_DrzavaID",
                schema: "Identity",
                table: "Grad");

            migrationBuilder.DropTable(
                name: "Ciklus",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Drzava",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Grupa",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Predavac",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_Grad_DrzavaID",
                schema: "Identity",
                table: "Grad");

            migrationBuilder.DropColumn(
                name: "DatumPrijave",
                schema: "Identity",
                table: "KorisnikKurs");

            migrationBuilder.DropColumn(
                name: "DrzavaID",
                schema: "Identity",
                table: "Grad");
        }
    }
}
