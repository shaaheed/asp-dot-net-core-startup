using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingWebHost.Migrations
{
    public partial class M6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "LineItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_UnitId",
                table: "LineItem",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItem_Unit_UnitId",
                table: "LineItem",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItem_Unit_UnitId",
                table: "LineItem");

            migrationBuilder.DropIndex(
                name: "IX_LineItem_UnitId",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "LineItem");
        }
    }
}
