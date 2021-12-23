using Microsoft.EntityFrameworkCore.Migrations;

namespace BagLib.Migrations
{
    public partial class _02Api : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stocks_MarketId",
                table: "Stocks",
                column: "MarketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Markets_MarketId",
                table: "Stocks",
                column: "MarketId",
                principalTable: "Markets",
                principalColumn: "MarketId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Markets_MarketId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_MarketId",
                table: "Stocks");
        }
    }
}
