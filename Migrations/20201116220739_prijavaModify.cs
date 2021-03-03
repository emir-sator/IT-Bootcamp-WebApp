using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class prijavaModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Identity",
                table: "KorisnikKurs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Identity",
                table: "KorisnikKurs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
