using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class addProductTypeToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                schema: "Identity",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductTypeId",
                schema: "Identity",
                table: "Categories",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ProductType_ProductTypeId",
                schema: "Identity",
                table: "Categories",
                column: "ProductTypeId",
                principalSchema: "Identity",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ProductType_ProductTypeId",
                schema: "Identity",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProductTypeId",
                schema: "Identity",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                schema: "Identity",
                table: "Categories");
        }
    }
}
