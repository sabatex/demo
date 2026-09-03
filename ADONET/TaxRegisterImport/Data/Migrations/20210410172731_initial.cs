using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxRegisterImport.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyProperty",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    tin = table.Column<string>(type: "TEXT", nullable: true),
                    data_n = table.Column<string>(type: "TEXT", nullable: true),
                    stavka = table.Column<string>(type: "TEXT", nullable: true),
                    grup = table.Column<string>(type: "TEXT", nullable: true),
                    vd = table.Column<string>(type: "TEXT", nullable: true),
                    data_k = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyProperty", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyProperty");
        }
    }
}
