using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class DodanKabinet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predavanje_Kabinet_KabinetID",
                schema: "Identity",
                table: "Predavanje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kabinet",
                schema: "Identity",
                table: "Kabinet");

            migrationBuilder.RenameTable(
                name: "Kabinet",
                schema: "Identity",
                newName: "Kabineti",
                newSchema: "Identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kabineti",
                schema: "Identity",
                table: "Kabineti",
                column: "KabinetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Predavanje_Kabineti_KabinetID",
                schema: "Identity",
                table: "Predavanje",
                column: "KabinetID",
                principalSchema: "Identity",
                principalTable: "Kabineti",
                principalColumn: "KabinetID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predavanje_Kabineti_KabinetID",
                schema: "Identity",
                table: "Predavanje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kabineti",
                schema: "Identity",
                table: "Kabineti");

            migrationBuilder.RenameTable(
                name: "Kabineti",
                schema: "Identity",
                newName: "Kabinet",
                newSchema: "Identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kabinet",
                schema: "Identity",
                table: "Kabinet",
                column: "KabinetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Predavanje_Kabinet_KabinetID",
                schema: "Identity",
                table: "Predavanje",
                column: "KabinetID",
                principalSchema: "Identity",
                principalTable: "Kabinet",
                principalColumn: "KabinetID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
