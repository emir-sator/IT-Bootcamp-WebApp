using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class prijadaModifikacija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikKurs_User_UserID",
                schema: "Identity",
                table: "KorisnikKurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KorisnikKurs",
                schema: "Identity",
                table: "KorisnikKurs");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "Identity",
                table: "KorisnikKurs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "PrijavaID",
                schema: "Identity",
                table: "KorisnikKurs",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "KorisnikId",
                schema: "Identity",
                table: "KorisnikKurs",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KorisnikKurs",
                schema: "Identity",
                table: "KorisnikKurs",
                column: "PrijavaID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikKurs_KorisnikId",
                schema: "Identity",
                table: "KorisnikKurs",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikKurs_User_KorisnikId",
                schema: "Identity",
                table: "KorisnikKurs",
                column: "KorisnikId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikKurs_User_KorisnikId",
                schema: "Identity",
                table: "KorisnikKurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KorisnikKurs",
                schema: "Identity",
                table: "KorisnikKurs");

            migrationBuilder.DropIndex(
                name: "IX_KorisnikKurs_KorisnikId",
                schema: "Identity",
                table: "KorisnikKurs");

            migrationBuilder.DropColumn(
                name: "PrijavaID",
                schema: "Identity",
                table: "KorisnikKurs");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                schema: "Identity",
                table: "KorisnikKurs");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "Identity",
                table: "KorisnikKurs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KorisnikKurs",
                schema: "Identity",
                table: "KorisnikKurs",
                columns: new[] { "UserID", "KursID" });

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikKurs_User_UserID",
                schema: "Identity",
                table: "KorisnikKurs",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
