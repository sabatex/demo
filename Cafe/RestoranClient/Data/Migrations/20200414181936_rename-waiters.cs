using Microsoft.EntityFrameworkCore.Migrations;

namespace RestoranClient.Data.Migrations
{
    public partial class renamewaiters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Waiters_UserId",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Waiters",
                table: "Waiters");

            migrationBuilder.RenameTable(
                name: "Waiters",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Users_UserId",
                table: "UserGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Users_UserId",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Waiters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Waiters",
                table: "Waiters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Waiters_UserId",
                table: "UserGroups",
                column: "UserId",
                principalTable: "Waiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
