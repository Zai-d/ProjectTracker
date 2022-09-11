using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTrackerBusinessLayer.Data.Migrations
{
    public partial class AddingNoteForWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamLeaderNote",
                table: "Works",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamLeaderNote",
                table: "Works");
        }
    }
}
