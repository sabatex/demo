using Microsoft.EntityFrameworkCore.Migrations;

namespace RestoranClient.Data.Migrations
{
    public partial class addwaiters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "UserId", "Group" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 4, "Ruslan", "4444" });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "UserId", "Group" },
                values: new object[] { 4, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumns: new[] { "UserId", "Group" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumns: new[] { "UserId", "Group" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
