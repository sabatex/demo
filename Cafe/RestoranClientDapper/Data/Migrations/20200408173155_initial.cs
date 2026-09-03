using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestoranClient.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "abonent",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abonent", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ClientCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "numeric(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Waiters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waiters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    waiter_id = table.Column<int>(nullable: true),
                    abonent_id = table.Column<int>(nullable: true),
                    time_order = table.Column<DateTime>(nullable: false),
                    Bill = table.Column<decimal>(nullable: true),
                    source_id = table.Column<int>(nullable: true),
                    FixedSource = table.Column<string>(nullable: false),
                    end_order = table.Column<DateTime>(nullable: true),
                    Paid = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_abonent_abonent_id",
                        column: x => x.abonent_id,
                        principalTable: "abonent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    items_id = table.Column<int>(nullable: false),
                    order_id = table.Column<int>(nullable: false),
                    bill = table.Column<decimal>(nullable: false),
                    count = table.Column<decimal>(nullable: false),
                    price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Order_order_id",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "abonent",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "table 1" },
                    { 2, "table 2" },
                    { 3, "table 3" },
                    { 4, "table 4" }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "name", "price" },
                values: new object[,]
                {
                    { 14, "Vodka", 300.00m },
                    { 13, "shashlik", 300.00m },
                    { 12, "Salad", 100.00m },
                    { 11, "pizza", 95.00m },
                    { 10, "ketchup", 300.00m },
                    { 9, "IceCream", 50.00m },
                    { 8, "Duck soup", 45.00m },
                    { 6, "Coca Cola", 40.00m },
                    { 15, "water", 40.00m },
                    { 5, "chicken with poatoes", 95.00m },
                    { 4, "Chicken soup", 45.00m },
                    { 3, "bread", 5.00m },
                    { 2, "Borch", 50.00m },
                    { 1, "Bear", 45.00m },
                    { 7, "Cofee", 25.00m },
                    { 16, "Whiskey", 1000.00m }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "abonent_id", "Bill", "end_order", "FixedSource", "Paid", "source_id", "time_order", "waiter_id" },
                values: new object[,]
                {
                    { 1, 1, 290.00m, null, "Kitchen", 0m, null, new DateTime(2020, 2, 24, 16, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 1, 200.00m, null, "Kitchen", 0m, null, new DateTime(2020, 2, 24, 16, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, 1, 100.00m, null, "Kitchen", 0m, null, new DateTime(2020, 4, 8, 15, 16, 5, 357, DateTimeKind.Unspecified), 1 },
                    { 2, 2, 485.00m, null, "Kitchen", 0m, null, new DateTime(2020, 2, 24, 16, 10, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 2, 302.50m, null, "Bar", 0m, null, new DateTime(2020, 2, 24, 16, 10, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 3, 140.00m, null, "Kitchen", 0m, null, new DateTime(2020, 2, 24, 16, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 3, 160.00m, null, "Bar", 0m, null, new DateTime(2020, 2, 24, 16, 50, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, 4, 125.00m, null, "Bar", 0m, null, new DateTime(2020, 2, 24, 16, 5, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, 4, 10350.00m, null, "Bar", 0m, null, new DateTime(2020, 4, 8, 15, 16, 17, 813, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "bill", "count", "items_id", "order_id", "price" },
                values: new object[,]
                {
                    { 1, 100.00m, 2.000m, 2, 1, 50.00m },
                    { 7, 100.00m, 2.000m, 2, 8, 50.00m },
                    { 2, 90.00m, 2.000m, 8, 2, 45.00m },
                    { 3, 150.00m, 0.500m, 14, 3, 300.00m },
                    { 4, 45.00m, 1.000m, 4, 4, 45.00m },
                    { 5, 50.00m, 2.000m, 7, 5, 25.00m },
                    { 6, 75.00m, 3.000m, 7, 5, 25.00m },
                    { 8, 50.00m, 2.000m, 7, 9, 25.00m },
                    { 9, 400.00m, 10.000m, 15, 9, 40.00m },
                    { 10, 3000.00m, 10.000m, 13, 9, 300.00m },
                    { 11, 5000.00m, 5.000m, 16, 9, 1000.00m },
                    { 12, 1900.00m, 20.000m, 11, 9, 95.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_order_id",
                table: "Details",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_abonent_id",
                table: "Order",
                column: "abonent_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCards");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "Waiters");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "abonent");
        }
    }
}
