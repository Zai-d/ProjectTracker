using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTrackerBusinessLayer.Data.Migrations
{
    public partial class RemovingWorksMissionsSprintsrelationWithMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_AspNetUsers_TeamLeaderID",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_Missions_AspNetUsers_TeamMemberID",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_AspNetUsers_TeamLeaderID",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_AspNetUsers_TeamMemberID",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_TeamMemberID",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Sprints_TeamLeaderID",
                table: "Sprints");

            migrationBuilder.DropIndex(
                name: "IX_Missions_TeamLeaderID",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_TeamMemberID",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "TeamMemberID",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "TeamLeaderID",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "TeamLeaderID",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "TeamMemberID",
                table: "Missions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamMemberID",
                table: "Works",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamLeaderID",
                table: "Sprints",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamLeaderID",
                table: "Missions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamMemberID",
                table: "Missions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_TeamMemberID",
                table: "Works",
                column: "TeamMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_TeamLeaderID",
                table: "Sprints",
                column: "TeamLeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_TeamLeaderID",
                table: "Missions",
                column: "TeamLeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_TeamMemberID",
                table: "Missions",
                column: "TeamMemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_AspNetUsers_TeamLeaderID",
                table: "Missions",
                column: "TeamLeaderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_AspNetUsers_TeamMemberID",
                table: "Missions",
                column: "TeamMemberID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_AspNetUsers_TeamLeaderID",
                table: "Sprints",
                column: "TeamLeaderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_AspNetUsers_TeamMemberID",
                table: "Works",
                column: "TeamMemberID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
