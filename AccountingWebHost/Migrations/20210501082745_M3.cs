using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingWebHost.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AdjustmentAmount",
                table: "Bill",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AdjustmentText",
                table: "Bill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "Bill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillPayment_PaymentId",
                table: "BillPayment",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillPayment_Payment_PaymentId",
                table: "BillPayment",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillPayment_Payment_PaymentId",
                table: "BillPayment");

            migrationBuilder.DropIndex(
                name: "IX_BillPayment_PaymentId",
                table: "BillPayment");

            migrationBuilder.DropColumn(
                name: "AdjustmentAmount",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "AdjustmentText",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Bill");
        }
    }
}
