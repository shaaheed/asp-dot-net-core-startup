using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingWebHost.Migrations
{
    public partial class M12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StateOrProvince_StateOrProvinceId",
                table: "Address");

            migrationBuilder.AlterColumn<Guid>(
                name: "StateOrProvinceId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StateOrProvince_StateOrProvinceId",
                table: "Address",
                column: "StateOrProvinceId",
                principalTable: "StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StateOrProvince_StateOrProvinceId",
                table: "Address");

            migrationBuilder.AlterColumn<Guid>(
                name: "StateOrProvinceId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StateOrProvince_StateOrProvinceId",
                table: "Address",
                column: "StateOrProvinceId",
                principalTable: "StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
