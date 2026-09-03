using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPage.Data.Migrations
{
    public partial class school2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { 1, "School #1", null });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { 2, "School #2", null });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { 3, "School #3", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 1, "User1", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 2, "User2", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 3, "User3", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 4, "User4", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 5, "User5", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 6, "User6", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 7, "User7", 3 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 8, "User8", 3 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 9, "User9", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
