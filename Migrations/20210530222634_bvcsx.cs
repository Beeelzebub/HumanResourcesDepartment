using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResourcesDepartment.Migrations
{
    public partial class bvcsx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "AspNetUsers",
                newName: "Surname");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfAction",
                table: "Vacations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HRManagerId",
                table: "Vacations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfAction",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HRManagerId",
                table: "Transfers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfAction",
                table: "TimeSheets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HRManagerId",
                table: "TimeSheets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfAction",
                table: "SickLeaves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HRManagerId",
                table: "SickLeaves",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfAction",
                table: "LaborСontracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HRManagerId",
                table: "LaborСontracts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfAction",
                table: "Dismissals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HRManagerId",
                table: "Dismissals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfAction",
                table: "BusinessTrips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HRManagerId",
                table: "BusinessTrips",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_HRManagerId",
                table: "Vacations",
                column: "HRManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_HRManagerId",
                table: "Transfers",
                column: "HRManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_HRManagerId",
                table: "TimeSheets",
                column: "HRManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_SickLeaves_HRManagerId",
                table: "SickLeaves",
                column: "HRManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborСontracts_HRManagerId",
                table: "LaborСontracts",
                column: "HRManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Dismissals_HRManagerId",
                table: "Dismissals",
                column: "HRManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTrips_HRManagerId",
                table: "BusinessTrips",
                column: "HRManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTrips_AspNetUsers_HRManagerId",
                table: "BusinessTrips",
                column: "HRManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dismissals_AspNetUsers_HRManagerId",
                table: "Dismissals",
                column: "HRManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LaborСontracts_AspNetUsers_HRManagerId",
                table: "LaborСontracts",
                column: "HRManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SickLeaves_AspNetUsers_HRManagerId",
                table: "SickLeaves",
                column: "HRManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_AspNetUsers_HRManagerId",
                table: "TimeSheets",
                column: "HRManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_AspNetUsers_HRManagerId",
                table: "Transfers",
                column: "HRManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_AspNetUsers_HRManagerId",
                table: "Vacations",
                column: "HRManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTrips_AspNetUsers_HRManagerId",
                table: "BusinessTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Dismissals_AspNetUsers_HRManagerId",
                table: "Dismissals");

            migrationBuilder.DropForeignKey(
                name: "FK_LaborСontracts_AspNetUsers_HRManagerId",
                table: "LaborСontracts");

            migrationBuilder.DropForeignKey(
                name: "FK_SickLeaves_AspNetUsers_HRManagerId",
                table: "SickLeaves");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_AspNetUsers_HRManagerId",
                table: "TimeSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_AspNetUsers_HRManagerId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_AspNetUsers_HRManagerId",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_HRManagerId",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_HRManagerId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_TimeSheets_HRManagerId",
                table: "TimeSheets");

            migrationBuilder.DropIndex(
                name: "IX_SickLeaves_HRManagerId",
                table: "SickLeaves");

            migrationBuilder.DropIndex(
                name: "IX_LaborСontracts_HRManagerId",
                table: "LaborСontracts");

            migrationBuilder.DropIndex(
                name: "IX_Dismissals_HRManagerId",
                table: "Dismissals");

            migrationBuilder.DropIndex(
                name: "IX_BusinessTrips_HRManagerId",
                table: "BusinessTrips");

            migrationBuilder.DropColumn(
                name: "DateOfAction",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "HRManagerId",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "DateOfAction",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "HRManagerId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "DateOfAction",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "HRManagerId",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "DateOfAction",
                table: "SickLeaves");

            migrationBuilder.DropColumn(
                name: "HRManagerId",
                table: "SickLeaves");

            migrationBuilder.DropColumn(
                name: "DateOfAction",
                table: "LaborСontracts");

            migrationBuilder.DropColumn(
                name: "HRManagerId",
                table: "LaborСontracts");

            migrationBuilder.DropColumn(
                name: "DateOfAction",
                table: "Dismissals");

            migrationBuilder.DropColumn(
                name: "HRManagerId",
                table: "Dismissals");

            migrationBuilder.DropColumn(
                name: "DateOfAction",
                table: "BusinessTrips");

            migrationBuilder.DropColumn(
                name: "HRManagerId",
                table: "BusinessTrips");

            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AspNetUsers",
                newName: "SecondName");
        }
    }
}
