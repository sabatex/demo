using Microsoft.EntityFrameworkCore.Migrations;

namespace RestoranClient.Data.Migrations
{
    public partial class seedWaiters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "source_id",
                table: "Order",
                newName: "SourceId");

            migrationBuilder.InsertData(
                table: "Waiters",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 1, "Andrea", "1111" });

            migrationBuilder.InsertData(
                table: "Waiters",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 2, "Suzane", "2222" });

            migrationBuilder.InsertData(
                table: "Waiters",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 3, "Ivanka", "3333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Waiters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Waiters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Waiters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "SourceId",
                table: "Order",
                newName: "source_id");
        }
    }
}
