using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentAPI.Migrations
{
    public partial class PaymentDetailsIdNameCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PayentDetailsId",
                table: "payentDetails",
                newName: "PaymentDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentDetailsId",
                table: "payentDetails",
                newName: "PayentDetailsId");
        }
    }
}
