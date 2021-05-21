using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_HelpDesk.Data.Migrations
{
    public partial class InitialCreate25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "AdditionalNotifications");

            migrationBuilder.AddColumn<int>(
                name: "UserDetailId",
                table: "AdditionalNotifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalNotifications_UserDetailId",
                table: "AdditionalNotifications",
                column: "UserDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalNotifications_UserDetails_UserDetailId",
                table: "AdditionalNotifications",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalNotifications_UserDetails_UserDetailId",
                table: "AdditionalNotifications");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalNotifications_UserDetailId",
                table: "AdditionalNotifications");

            migrationBuilder.DropColumn(
                name: "UserDetailId",
                table: "AdditionalNotifications");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "AdditionalNotifications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
