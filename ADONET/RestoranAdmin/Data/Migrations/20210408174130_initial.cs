using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestoranAdmin.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mybase");

            migrationBuilder.EnsureSchema(
                name: "ddd");

            migrationBuilder.CreateTable(
                name: "Офіціант",
                schema: "mybase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Офіціант", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false, defaultValue: 9.9900000000000002),
                    Description = table.Column<string>(type: "TEXT", nullable: true, computedColumnSql: "[Name] +  [Price]")
                },
                constraints: table =>
                {
                    table.PrimaryKey("myPrimaryKey", x => new { x.Name, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "ClientTableWaiters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientTableId = table.Column<int>(type: "INTEGER", nullable: false),
                    WaiterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTableWaiters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientTableWaiters_Офіціант_WaiterId",
                        column: x => x.WaiterId,
                        principalSchema: "mybase",
                        principalTable: "Офіціант",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientTableWaiters_ClientTables_ClientTableId",
                        column: x => x.ClientTableId,
                        principalTable: "ClientTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WaiterId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientTableId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "date", precision: 9, scale: 2, nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_ClientTables_ClientTableId",
                        column: x => x.ClientTableId,
                        principalTable: "ClientTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Замовлення");

            migrationBuilder.CreateTable(
                name: "order_item",
                schema: "ddd",
                columns: table => new
                {
                    PK = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodItemName = table.Column<string>(type: "TEXT", nullable: false),
                    FoodItemId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_item", x => x.PK);
                    table.ForeignKey(
                        name: "FK_order_item_FoodItem_FoodItemName_FoodItemId1",
                        columns: x => new { x.FoodItemName, x.FoodItemId1 },
                        principalTable: "FoodItem",
                        principalColumns: new[] { "Name", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientTables",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Table 1" });

            migrationBuilder.InsertData(
                table: "ClientTables",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Table 2" });

            migrationBuilder.InsertData(
                schema: "mybase",
                table: "Офіціант",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 1, "Іван", "1" });

            migrationBuilder.InsertData(
                schema: "mybase",
                table: "Офіціант",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 2, "Piter", "2" });

            migrationBuilder.InsertData(
                table: "ClientTableWaiters",
                columns: new[] { "Id", "ClientTableId", "WaiterId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ClientTableWaiters_ClientTableId",
                table: "ClientTableWaiters",
                column: "ClientTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTableWaiters_WaiterId",
                table: "ClientTableWaiters",
                column: "WaiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientTableId",
                table: "Order",
                column: "ClientTableId");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_FoodItemName_FoodItemId1",
                schema: "ddd",
                table: "order_item",
                columns: new[] { "FoodItemName", "FoodItemId1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientTableWaiters");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "order_item",
                schema: "ddd");

            migrationBuilder.DropTable(
                name: "Офіціант",
                schema: "mybase");

            migrationBuilder.DropTable(
                name: "ClientTables");

            migrationBuilder.DropTable(
                name: "FoodItem");
        }
    }
}
