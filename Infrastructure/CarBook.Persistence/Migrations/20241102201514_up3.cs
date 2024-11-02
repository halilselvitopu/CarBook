using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class up3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalPrices_Pricings_PricingTypeId",
                table: "RentalPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pricings",
                table: "Pricings");

            migrationBuilder.RenameTable(
                name: "Pricings",
                newName: "PricingTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PricingTypes",
                table: "PricingTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPrices_PricingTypes_PricingTypeId",
                table: "RentalPrices",
                column: "PricingTypeId",
                principalTable: "PricingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalPrices_PricingTypes_PricingTypeId",
                table: "RentalPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PricingTypes",
                table: "PricingTypes");

            migrationBuilder.RenameTable(
                name: "PricingTypes",
                newName: "Pricings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pricings",
                table: "Pricings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPrices_Pricings_PricingTypeId",
                table: "RentalPrices",
                column: "PricingTypeId",
                principalTable: "Pricings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
