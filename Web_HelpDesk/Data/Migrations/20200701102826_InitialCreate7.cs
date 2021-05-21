using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_HelpDesk.Data.Migrations
{
    public partial class InitialCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Assignees_AssigneeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AssigneeId",
                table: "Tickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssigneeId",
                table: "Tickets",
                column: "AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Assignees_AssigneeId",
                table: "Tickets",
                column: "AssigneeId",
                principalTable: "Assignees",
                principalColumn: "AssigneeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
