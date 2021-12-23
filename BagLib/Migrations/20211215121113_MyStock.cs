using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BagLib.Migrations
{
    public partial class MyStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BagUsers",
                columns: table => new
                {
                    BagUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagUsers", x => x.BagUserId);
                });

            migrationBuilder.CreateTable(
                name: "MyStocks",
                columns: table => new
                {
                    MyStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    BagUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyStocks", x => x.MyStockId);
                    table.ForeignKey(
                        name: "FK_MyStocks_BagUsers_BagUserId",
                        column: x => x.BagUserId,
                        principalTable: "BagUsers",
                        principalColumn: "BagUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyStocks_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyStocks_BagUserId",
                table: "MyStocks",
                column: "BagUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MyStocks_StockId",
                table: "MyStocks",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyStocks");

            migrationBuilder.DropTable(
                name: "BagUsers");
        }
    }
}
