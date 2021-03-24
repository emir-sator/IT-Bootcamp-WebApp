using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class novaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Predavac",
                schema: "Identity");

            migrationBuilder.AddColumn<int>(
                name: "GradID",
                schema: "Identity",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Grad",
                schema: "Identity",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Grad",
                columns: new[] { "GradID", "Naziv" },
                values: new object[] { 1, "Konjic" });

            migrationBuilder.CreateIndex(
                name: "IX_User_GradID",
                schema: "Identity",
                table: "User",
                column: "GradID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Grad_GradID",
                schema: "Identity",
                table: "User",
                column: "GradID",
                principalSchema: "Identity",
                principalTable: "Grad",
                principalColumn: "GradID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Grad_GradID",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropTable(
                name: "Grad",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_User_GradID",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GradID",
                schema: "Identity",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Predavac",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KorisnikId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    mjestoRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Predavac_KorisnikId",
                schema: "Identity",
                table: "Predavac",
                column: "KorisnikId");
        }
    }
}
