using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTrackerBusinessLayer.Data.Migrations
{
    public partial class ActivityStatusRela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusName",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_StatusID",
                table: "Activities",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Statuses_StatusID",
                table: "Activities",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Statuses_StatusID",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_StatusID",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Activities");

            migrationBuilder.AddColumn<string>(
                name: "StatusName",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
