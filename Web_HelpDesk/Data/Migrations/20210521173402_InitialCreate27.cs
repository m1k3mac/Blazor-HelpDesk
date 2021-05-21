using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_HelpDesk.Data.Migrations
{
    public partial class InitialCreate27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ProblemType" },
                values: new object[,]
                {
                    { 1, "Computer Hardware Problem" },
                    { 2, "Printer Problem" },
                    { 3, "Problem with ERP System" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Accounts" },
                    { 2, "Maintenance" },
                    { 3, "Stores" }
                });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Subject",
                value: "Computer not booting. Screen is blank.");

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AltContactNumber", "Assignee", "Category", "Creator", "Department", "EmailAddress", "Location", "Logged", "PriorityId", "StatusId", "Subject" },
                values: new object[] { 2, null, "1", null, "Joe Soap", null, null, null, new DateTime(2020, 6, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Phone not receiving email." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Subject",
                value: "Capture Station not booting. Screen is blank.");
        }
    }
}
