using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class grupePolaznika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolaznikGrupa",
                schema: "Identity",
                columns: table => new
                {
                    GrupaID = table.Column<int>(nullable: false),
                    KursID = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolaznikGrupa", x => new { x.GrupaID, x.KursID, x.KorisnikId });
                    table.ForeignKey(
                        name: "FK_PolaznikGrupa_Grupa_GrupaID",
                        column: x => x.GrupaID,
                        principalSchema: "Identity",
                        principalTable: "Grupa",
                        principalColumn: "GrupaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolaznikGrupa_User_KorisnikId",
                        column: x => x.KorisnikId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolaznikGrupa_Kursevi_KursID",
                        column: x => x.KursID,
                        principalSchema: "Identity",
                        principalTable: "Kursevi",
                        principalColumn: "KursID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Grad",
                keyColumn: "GradID",
                keyValue: 1,
                column: "PTT",
                value: "88400");

            migrationBuilder.CreateIndex(
                name: "IX_PolaznikGrupa_KorisnikId",
                schema: "Identity",
                table: "PolaznikGrupa",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_PolaznikGrupa_KursID",
                schema: "Identity",
                table: "PolaznikGrupa",
                column: "KursID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolaznikGrupa",
                schema: "Identity");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Grad",
                keyColumn: "GradID",
                keyValue: 1,
                column: "PTT",
                value: null);
        }
    }
}
