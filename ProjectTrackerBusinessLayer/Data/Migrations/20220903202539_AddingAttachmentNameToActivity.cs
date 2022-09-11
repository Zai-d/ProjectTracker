using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTrackerBusinessLayer.Data.Migrations
{
    public partial class AddingAttachmentNameToActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttachmentName",
                table: "Activities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachmentName",
                table: "Activities");
        }
    }
}
