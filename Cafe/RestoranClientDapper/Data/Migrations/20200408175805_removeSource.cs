using Microsoft.EntityFrameworkCore.Migrations;

namespace RestoranClient.Data.Migrations
{
    public partial class removeSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "Order",
                type: "int",
                nullable: true);
        }
    }
}
