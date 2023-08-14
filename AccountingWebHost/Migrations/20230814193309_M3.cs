using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingWebHost.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Location_LocationId",
                table: "SaleDetails");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "SaleDetails",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleDetails_LocationId",
                table: "SaleDetails",
                newName: "IX_SaleDetails_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "PurchaseDetails",
                newName: "Price");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId",
                table: "PurchaseDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UnitValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitValue_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_CurrencyId",
                table: "PurchaseDetails",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitValue_UnitId",
                table: "UnitValue",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Currency_CurrencyId",
                table: "PurchaseDetails",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Currency_CurrencyId",
                table: "SaleDetails",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Currency_CurrencyId",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Currency_CurrencyId",
                table: "SaleDetails");

            migrationBuilder.DropTable(
                name: "UnitValue");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_CurrencyId",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "PurchaseDetails");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "SaleDetails",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleDetails_CurrencyId",
                table: "SaleDetails",
                newName: "IX_SaleDetails_LocationId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "PurchaseDetails",
                newName: "Cost");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Location_LocationId",
                table: "SaleDetails",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");
        }
    }
}
