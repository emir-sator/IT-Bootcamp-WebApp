using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class kursKorisnik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KorisnikKurs",
                schema: "Identity",
                columns: table => new
                {
                    KursID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    Polozio = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikKurs", x => new { x.UserID, x.KursID });
                    table.ForeignKey(
                        name: "FK_KorisnikKurs_Kursevi_KursID",
                        column: x => x.KursID,
                        principalSchema: "Identity",
                        principalTable: "Kursevi",
                        principalColumn: "KursID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikKurs_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikKurs_KursID",
                schema: "Identity",
                table: "KorisnikKurs",
                column: "KursID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisnikKurs",
                schema: "Identity");
        }
    }
}
