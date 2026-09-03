using Microsoft.EntityFrameworkCore.Migrations;

namespace RestoranClient.Data.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    Group = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => new { x.UserId, x.Group });
                    table.ForeignKey(
                        name: "FK_UserGroups_Waiters_UserId",
                        column: x => x.UserId,
                        principalTable: "Waiters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "UserId", "Group" },
                values: new object[] { 1, 0 });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "UserId", "Group" },
                values: new object[] { 2, 0 });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "UserId", "Group" },
                values: new object[] { 3, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGroups");
        }
    }
}
