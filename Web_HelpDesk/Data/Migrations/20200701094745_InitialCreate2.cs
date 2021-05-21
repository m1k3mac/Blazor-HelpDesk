using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_HelpDesk.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssigneesId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssigneesId",
                table: "Tickets",
                column: "AssigneesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Assignees_AssigneesId",
                table: "Tickets",
                column: "AssigneesId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Assignees_AssigneesId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AssigneesId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AssigneesId",
                table: "Tickets");
        }
    }
}
