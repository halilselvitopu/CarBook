using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class up : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalPrices_Pricings_PricingId",
                table: "RentalPrices");

            migrationBuilder.RenameColumn(
                name: "PricingId",
                table: "RentalPrices",
                newName: "PricingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalPrices_PricingId",
                table: "RentalPrices",
                newName: "IX_RentalPrices_PricingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPrices_Pricings_PricingTypeId",
                table: "RentalPrices",
                column: "PricingTypeId",
                principalTable: "Pricings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalPrices_Pricings_PricingTypeId",
                table: "RentalPrices");

            migrationBuilder.RenameColumn(
                name: "PricingTypeId",
                table: "RentalPrices",
                newName: "PricingId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalPrices_PricingTypeId",
                table: "RentalPrices",
                newName: "IX_RentalPrices_PricingId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPrices_Pricings_PricingId",
                table: "RentalPrices",
                column: "PricingId",
                principalTable: "Pricings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
