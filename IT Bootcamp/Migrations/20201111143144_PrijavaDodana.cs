using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class PrijavaDodana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisniciKurseva_Kursevi_KursID",
                schema: "Identity",
                table: "KorisniciKurseva");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisniciKurseva_AspNetUsers_UserID",
                schema: "Identity",
                table: "KorisniciKurseva");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KorisniciKurseva",
                schema: "Identity",
                table: "KorisniciKurseva");

            migrationBuilder.RenameTable(
                name: "KorisniciKurseva",
                schema: "Identity",
                newName: "KorisnikKurs",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_KorisniciKurseva_KursID",
                schema: "Identity",
                table: "KorisnikKurs",
                newName: "IX_KorisnikKurs_KursID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KorisnikKurs",
                schema: "Identity",
                table: "KorisnikKurs",
                columns: new[] { "UserID", "KursID" });

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikKurs_Kursevi_KursID",
                schema: "Identity",
                table: "KorisnikKurs",
                column: "KursID",
                principalSchema: "Identity",
                principalTable: "Kursevi",
                principalColumn: "KursID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikKurs_AspNetUsers_UserID",
                schema: "Identity",
                table: "KorisnikKurs",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikKurs_Kursevi_KursID",
                schema: "Identity",
                table: "KorisnikKurs");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikKurs_AspNetUsers_UserID",
                schema: "Identity",
                table: "KorisnikKurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KorisnikKurs",
                schema: "Identity",
                table: "KorisnikKurs");

            migrationBuilder.RenameTable(
                name: "KorisnikKurs",
                schema: "Identity",
                newName: "KorisniciKurseva",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_KorisnikKurs_KursID",
                schema: "Identity",
                table: "KorisniciKurseva",
                newName: "IX_KorisniciKurseva_KursID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KorisniciKurseva",
                schema: "Identity",
                table: "KorisniciKurseva",
                columns: new[] { "UserID", "KursID" });

            migrationBuilder.AddForeignKey(
                name: "FK_KorisniciKurseva_Kursevi_KursID",
                schema: "Identity",
                table: "KorisniciKurseva",
                column: "KursID",
                principalSchema: "Identity",
                principalTable: "Kursevi",
                principalColumn: "KursID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisniciKurseva_AspNetUsers_UserID",
                schema: "Identity",
                table: "KorisniciKurseva",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
