using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class up_blogcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategories_BlogCategories_BlogCategoryId",
                table: "BlogCategories");

            migrationBuilder.DropIndex(
                name: "IX_BlogCategories_BlogCategoryId",
                table: "BlogCategories");

            migrationBuilder.DropColumn(
                name: "BlogCategoryId",
                table: "BlogCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogCategoryId",
                table: "BlogCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_BlogCategoryId",
                table: "BlogCategories",
                column: "BlogCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogCategories_BlogCategories_BlogCategoryId",
                table: "BlogCategories",
                column: "BlogCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "Id");
        }
    }
}
