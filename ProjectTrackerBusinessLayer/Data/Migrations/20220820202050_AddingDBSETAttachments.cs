using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTrackerBusinessLayer.Data.Migrations
{
    public partial class AddingDBSETAttachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Works_WorkID",
                table: "Attachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment");

            migrationBuilder.RenameTable(
                name: "Attachment",
                newName: "Attachments");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_WorkID",
                table: "Attachments",
                newName: "IX_Attachments_WorkID");

            migrationBuilder.AlterColumn<string>(
                name: "WorkDescription",
                table: "Works",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Works",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Missions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MissionDescription",
                table: "Missions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments",
                column: "AttachmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Works_WorkID",
                table: "Attachments",
                column: "WorkID",
                principalTable: "Works",
                principalColumn: "WorkID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Works_WorkID",
                table: "Attachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments");

            migrationBuilder.RenameTable(
                name: "Attachments",
                newName: "Attachment");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_WorkID",
                table: "Attachment",
                newName: "IX_Attachment_WorkID");

            migrationBuilder.AlterColumn<string>(
                name: "WorkDescription",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Missions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MissionDescription",
                table: "Missions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment",
                column: "AttachmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Works_WorkID",
                table: "Attachment",
                column: "WorkID",
                principalTable: "Works",
                principalColumn: "WorkID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
