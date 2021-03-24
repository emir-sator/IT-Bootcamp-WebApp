using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class PopravkeDorade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Grad_GradID",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropTable(
                name: "Grad",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Drzava",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_User_GradID",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GradID",
                schema: "Identity",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                schema: "Identity",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grad",
                schema: "Identity",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "GradID",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drzava",
                schema: "Identity",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                schema: "Identity",
                columns: table => new
                {
                    GradID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrzavaID = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PTT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalSchema: "Identity",
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Drzava",
                columns: new[] { "DrzavaID", "Naziv" },
                values: new object[] { 1, "BiH" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Grad",
                columns: new[] { "GradID", "DrzavaID", "Naziv", "PTT" },
                values: new object[] { 1, 1, "Konjic", "88400" });

            migrationBuilder.CreateIndex(
                name: "IX_User_GradID",
                schema: "Identity",
                table: "User",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                schema: "Identity",
                table: "Grad",
                column: "DrzavaID");

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
    }
}
