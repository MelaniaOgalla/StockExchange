using Microsoft.EntityFrameworkCore.Migrations;

namespace BagLib.Migrations
{
    public partial class _04_Currencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCurrency_Currencies_CurrenciesId",
                table: "CountryCurrency");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Currencies",
                newName: "CurrencyId");

            migrationBuilder.RenameColumn(
                name: "CurrenciesId",
                table: "CountryCurrency",
                newName: "CurrenciesCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryCurrency_CurrenciesId",
                table: "CountryCurrency",
                newName: "IX_CountryCurrency_CurrenciesCurrencyId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCurrency_Currencies_CurrenciesCurrencyId",
                table: "CountryCurrency",
                column: "CurrenciesCurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCurrency_Currencies_CurrenciesCurrencyId",
                table: "CountryCurrency");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Currencies");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Currencies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CurrenciesCurrencyId",
                table: "CountryCurrency",
                newName: "CurrenciesId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryCurrency_CurrenciesCurrencyId",
                table: "CountryCurrency",
                newName: "IX_CountryCurrency_CurrenciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCurrency_Currencies_CurrenciesId",
                table: "CountryCurrency",
                column: "CurrenciesId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
