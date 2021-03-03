using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class uploadProjektaModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projekat_User_KorisnikId",
                schema: "Identity",
                table: "Projekat");

            migrationBuilder.DropForeignKey(
                name: "FK_Projekat_Kursevi_KursID",
                schema: "Identity",
                table: "Projekat");

            migrationBuilder.DropIndex(
                name: "IX_Projekat_KorisnikId",
                schema: "Identity",
                table: "Projekat");

            migrationBuilder.DropIndex(
                name: "IX_Projekat_KursID",
                schema: "Identity",
                table: "Projekat");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                schema: "Identity",
                table: "Projekat");

            migrationBuilder.DropColumn(
                name: "KursID",
                schema: "Identity",
                table: "Projekat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KorisnikId",
                schema: "Identity",
                table: "Projekat",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KursID",
                schema: "Identity",
                table: "Projekat",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Projekat_User_KorisnikId",
                schema: "Identity",
                table: "Projekat",
                column: "KorisnikId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projekat_Kursevi_KursID",
                schema: "Identity",
                table: "Projekat",
                column: "KursID",
                principalSchema: "Identity",
                principalTable: "Kursevi",
                principalColumn: "KursID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
