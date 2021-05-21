using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_HelpDesk.Data.Migrations
{
    public partial class InitialCreate26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalNotifications_UserDetails_UserDetailId",
                table: "AdditionalNotifications");

            migrationBuilder.AlterColumn<int>(
                name: "UserDetailId",
                table: "AdditionalNotifications",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalNotifications_UserDetails_UserDetailId",
                table: "AdditionalNotifications",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalNotifications_UserDetails_UserDetailId",
                table: "AdditionalNotifications");

            migrationBuilder.AlterColumn<int>(
                name: "UserDetailId",
                table: "AdditionalNotifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalNotifications_UserDetails_UserDetailId",
                table: "AdditionalNotifications",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
