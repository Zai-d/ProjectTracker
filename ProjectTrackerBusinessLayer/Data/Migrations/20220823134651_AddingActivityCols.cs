using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTrackerBusinessLayer.Data.Migrations
{
    public partial class AddingActivityCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectDescription",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectTitle",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SprintEndDate",
                table: "Activities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SprintName",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SprintStartDate",
                table: "Activities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "missionID",
                table: "Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "projectID",
                table: "Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "workID",
                table: "Activities",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectDescription",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ProjectTitle",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SprintEndDate",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SprintName",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SprintStartDate",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "missionID",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "projectID",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "workID",
                table: "Activities");
        }
    }
}
