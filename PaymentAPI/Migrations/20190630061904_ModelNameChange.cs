using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentAPI.Migrations
{
    public partial class ModelNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_payentDetails",
                table: "payentDetails");

            migrationBuilder.RenameTable(
                name: "payentDetails",
                newName: "paymentDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_paymentDetails",
                table: "paymentDetails",
                column: "PaymentDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_paymentDetails",
                table: "paymentDetails");

            migrationBuilder.RenameTable(
                name: "paymentDetails",
                newName: "payentDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_payentDetails",
                table: "payentDetails",
                column: "PaymentDetailsId");
        }
    }
}
