using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingWebHost.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Quote_ConvertedFromQuoteId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSalesTax_Product_ProductId",
                table: "ProductSalesTax");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSalesTax_Tax_TaxId",
                table: "ProductSalesTax");

            migrationBuilder.DropTable(
                name: "ProductPurchaseTax");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSalesTax",
                table: "ProductSalesTax");

            migrationBuilder.RenameTable(
                name: "ProductSalesTax",
                newName: "ProductTax");

            migrationBuilder.RenameColumn(
                name: "ConvertedFromQuoteId",
                table: "Invoice",
                newName: "FromQuoteId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_ConvertedFromQuoteId",
                table: "Invoice",
                newName: "IX_Invoice_FromQuoteId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSalesTax_TaxId",
                table: "ProductTax",
                newName: "IX_ProductTax_TaxId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSalesTax_ProductId",
                table: "ProductTax",
                newName: "IX_ProductTax_ProductId");

            migrationBuilder.AlterColumn<float>(
                name: "StockQuantity",
                table: "Product",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "LowStockQuantity",
                table: "Product",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<float>(
                name: "InitialStockQuantity",
                table: "Product",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<decimal>(
                name: "AdjustmentAmount",
                table: "Invoice",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AdjustmentText",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ProductTax",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTax",
                table: "ProductTax",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Quote_FromQuoteId",
                table: "Invoice",
                column: "FromQuoteId",
                principalTable: "Quote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Contact_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTax_Product_ProductId",
                table: "ProductTax",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTax_Tax_TaxId",
                table: "ProductTax",
                column: "TaxId",
                principalTable: "Tax",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Quote_FromQuoteId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Contact_SupplierId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTax_Product_ProductId",
                table: "ProductTax");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTax_Tax_TaxId",
                table: "ProductTax");

            migrationBuilder.DropIndex(
                name: "IX_Product_SupplierId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTax",
                table: "ProductTax");

            migrationBuilder.DropColumn(
                name: "InitialStockQuantity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AdjustmentAmount",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "AdjustmentText",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ProductTax");

            migrationBuilder.RenameTable(
                name: "ProductTax",
                newName: "ProductSalesTax");

            migrationBuilder.RenameColumn(
                name: "FromQuoteId",
                table: "Invoice",
                newName: "ConvertedFromQuoteId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_FromQuoteId",
                table: "Invoice",
                newName: "IX_Invoice_ConvertedFromQuoteId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTax_TaxId",
                table: "ProductSalesTax",
                newName: "IX_ProductSalesTax_TaxId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTax_ProductId",
                table: "ProductSalesTax",
                newName: "IX_ProductSalesTax_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "StockQuantity",
                table: "Product",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "LowStockQuantity",
                table: "Product",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSalesTax",
                table: "ProductSalesTax",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductPurchaseTax",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPurchaseTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPurchaseTax_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPurchaseTax_Tax_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Tax",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchaseTax_ProductId",
                table: "ProductPurchaseTax",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchaseTax_TaxId",
                table: "ProductPurchaseTax",
                column: "TaxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Quote_ConvertedFromQuoteId",
                table: "Invoice",
                column: "ConvertedFromQuoteId",
                principalTable: "Quote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSalesTax_Product_ProductId",
                table: "ProductSalesTax",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSalesTax_Tax_TaxId",
                table: "ProductSalesTax",
                column: "TaxId",
                principalTable: "Tax",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
