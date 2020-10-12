using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentMicroService.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentPrice = table.Column<int>(nullable: false),
                    PaymentStatus = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Createtime = table.Column<DateTime>(nullable: false),
                    Updatetime = table.Column<DateTime>(nullable: false),
                    PaymentRemark = table.Column<string>(nullable: true),
                    PaymentUrl = table.Column<string>(nullable: true),
                    PaymentReturnUrl = table.Column<string>(nullable: true),
                    PaymentCode = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    PaymentErrorNo = table.Column<string>(nullable: true),
                    PaymentErrorInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
