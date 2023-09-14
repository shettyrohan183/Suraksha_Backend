using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_youtube.Migrations
{
    public partial class updatedcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "MediaAttachments");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "MediaAttachments");

            migrationBuilder.RenameColumn(
                name: "MediaType",
                table: "MediaAttachments",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ReportedName",
                table: "Incidents",
                newName: "Reportedby");

            migrationBuilder.AddColumn<string>(
                name: "IncidentTitle",
                table: "Incidents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncidentTitle",
                table: "Incidents");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "MediaAttachments",
                newName: "MediaType");

            migrationBuilder.RenameColumn(
                name: "Reportedby",
                table: "Incidents",
                newName: "ReportedName");

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "MediaAttachments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "MediaAttachments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
