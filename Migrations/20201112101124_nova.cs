using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gradovi_GradID",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Gradovi",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GradID",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GradID",
                schema: "Identity",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradID",
                schema: "Identity",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gradovi",
                schema: "Identity",
                columns: table => new
                {
                    GradID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovi", x => x.GradID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GradID",
                schema: "Identity",
                table: "AspNetUsers",
                column: "GradID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gradovi_GradID",
                schema: "Identity",
                table: "AspNetUsers",
                column: "GradID",
                principalSchema: "Identity",
                principalTable: "Gradovi",
                principalColumn: "GradID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
