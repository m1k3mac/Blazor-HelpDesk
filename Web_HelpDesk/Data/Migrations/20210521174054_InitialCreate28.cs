using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_HelpDesk.Data.Migrations
{
    public partial class InitialCreate28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Department", "Location" },
                values: new object[] { "Accounts", "Durban" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Department", "Location", "PriorityId" },
                values: new object[] { "Maintenance", "Capetown", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Department", "Location" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Department", "Location", "PriorityId" },
                values: new object[] { null, null, 2 });
        }
    }
}
