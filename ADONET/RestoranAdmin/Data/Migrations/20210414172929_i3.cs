using Microsoft.EntityFrameworkCore.Migrations;

namespace RestoranAdmin.Data.Migrations
{
    public partial class i3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientTableWaiters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "ClientTableId",
                table: "ClientTableWaiters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTableWaiters_ClientTableId",
                table: "ClientTableWaiters",
                column: "ClientTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTableWaiters_ClientTables_ClientTableId",
                table: "ClientTableWaiters",
                column: "ClientTableId",
                principalTable: "ClientTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientTableWaiters_ClientTables_ClientTableId",
                table: "ClientTableWaiters");

            migrationBuilder.DropIndex(
                name: "IX_ClientTableWaiters_ClientTableId",
                table: "ClientTableWaiters");

            migrationBuilder.AlterColumn<int>(
                name: "ClientTableId",
                table: "ClientTableWaiters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ClientTableWaiters",
                columns: new[] { "Id", "ClientTableId", "WaiterId" },
                values: new object[] { 1, 1, 1 });
        }
    }
}
