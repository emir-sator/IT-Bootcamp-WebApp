using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class polaznikModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_User_KorisnikId",
                schema: "Identity",
                table: "Studenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studenti",
                schema: "Identity",
                table: "Studenti");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_KorisnikId",
                schema: "Identity",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Identity",
                table: "Studenti");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId",
                schema: "Identity",
                table: "Studenti",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studenti",
                schema: "Identity",
                table: "Studenti",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_User_KorisnikId",
                schema: "Identity",
                table: "Studenti",
                column: "KorisnikId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_User_KorisnikId",
                schema: "Identity",
                table: "Studenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studenti",
                schema: "Identity",
                table: "Studenti");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId",
                schema: "Identity",
                table: "Studenti",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                schema: "Identity",
                table: "Studenti",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studenti",
                schema: "Identity",
                table: "Studenti",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_KorisnikId",
                schema: "Identity",
                table: "Studenti",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_User_KorisnikId",
                schema: "Identity",
                table: "Studenti",
                column: "KorisnikId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
