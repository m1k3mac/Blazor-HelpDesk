using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_HelpDesk.Data.Migrations
{
    public partial class InitialCreate18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltContactNumber",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltContactNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Tickets");
        }
    }
}
