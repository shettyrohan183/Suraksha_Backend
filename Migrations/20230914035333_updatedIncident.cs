using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_youtube.Migrations
{
    public partial class updatedIncident : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReportedName",
                table: "Incidents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportedName",
                table: "Incidents");
        }
    }
}
