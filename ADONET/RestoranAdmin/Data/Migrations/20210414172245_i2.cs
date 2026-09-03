using Microsoft.EntityFrameworkCore.Migrations;

namespace RestoranAdmin.Data.Migrations
{
    public partial class i2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientTableWaiters_ClientTables_ClientTableId",
                table: "ClientTableWaiters");

            migrationBuilder.DropIndex(
                name: "IX_ClientTableWaiters_ClientTableId",
                table: "ClientTableWaiters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
