using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTrackerBusinessLayer.Data.Migrations
{
    public partial class MemberMissionRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamMemberID",
                table: "Missions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Missions_TeamMemberID",
                table: "Missions",
                column: "TeamMemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_AspNetUsers_TeamMemberID",
                table: "Missions",
                column: "TeamMemberID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_AspNetUsers_TeamMemberID",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_TeamMemberID",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "TeamMemberID",
                table: "Missions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
