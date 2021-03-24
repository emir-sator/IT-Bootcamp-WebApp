using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class predavacDBModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predavac_User_KorisnikId",
                schema: "Identity",
                table: "Predavac");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Predavac",
                schema: "Identity",
                table: "Predavac");

            migrationBuilder.DropIndex(
                name: "IX_Predavac_KorisnikId",
                schema: "Identity",
                table: "Predavac");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Identity",
                table: "Predavac");

            migrationBuilder.DropColumn(
                name: "mjestoRodjenja",
                schema: "Identity",
                table: "Predavac");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId",
                schema: "Identity",
                table: "Predavac",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatumRodjenja",
                schema: "Identity",
                table: "Predavac",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Predavac",
                schema: "Identity",
                table: "Predavac",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Predavac_User_KorisnikId",
                schema: "Identity",
                table: "Predavac",
                column: "KorisnikId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predavac_User_KorisnikId",
                schema: "Identity",
                table: "Predavac");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Predavac",
                schema: "Identity",
                table: "Predavac");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                schema: "Identity",
                table: "Predavac");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId",
                schema: "Identity",
                table: "Predavac",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                schema: "Identity",
                table: "Predavac",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "mjestoRodjenja",
                schema: "Identity",
                table: "Predavac",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Predavac",
                schema: "Identity",
                table: "Predavac",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Predavac_KorisnikId",
                schema: "Identity",
                table: "Predavac",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Predavac_User_KorisnikId",
                schema: "Identity",
                table: "Predavac",
                column: "KorisnikId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
