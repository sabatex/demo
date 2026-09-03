using Microsoft.EntityFrameworkCore.Migrations;

namespace RestoranAdmin.Data.Migrations
{
    public partial class i5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientTableWaiters_ClientTables_ClientTableId",
                table: "ClientTableWaiters");

            migrationBuilder.AlterColumn<int>(
                name: "ClientTableId",
                table: "ClientTableWaiters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

            migrationBuilder.AlterColumn<int>(
                name: "ClientTableId",
                table: "ClientTableWaiters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTableWaiters_ClientTables_ClientTableId",
                table: "ClientTableWaiters",
                column: "ClientTableId",
                principalTable: "ClientTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
