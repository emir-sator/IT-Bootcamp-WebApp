using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1SeminarskiRad2020.Migrations
{
    public partial class dokumentPrepravljen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fajl",
                schema: "Identity",
                table: "Dokument");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                schema: "Identity",
                table: "Dokument",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ekstenzija",
                schema: "Identity",
                table: "Dokument",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                schema: "Identity",
                table: "Dokument");

            migrationBuilder.DropColumn(
                name: "Ekstenzija",
                schema: "Identity",
                table: "Dokument");

            migrationBuilder.AddColumn<byte[]>(
                name: "Fajl",
                schema: "Identity",
                table: "Dokument",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
