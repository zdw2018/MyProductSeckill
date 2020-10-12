using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderMicroService.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderType = table.Column<string>(nullable: true),
                    OrderFlag = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    OrderSn = table.Column<string>(nullable: true),
                    OrderTotalPrice = table.Column<decimal>(nullable: false),
                    Createtime = table.Column<DateTime>(nullable: false),
                    Updatetime = table.Column<DateTime>(nullable: false),
                    Paytime = table.Column<DateTime>(nullable: false),
                    Sendtime = table.Column<DateTime>(nullable: false),
                    Successtime = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    OrderName = table.Column<string>(nullable: true),
                    OrderTel = table.Column<string>(nullable: true),
                    OrderAddress = table.Column<string>(nullable: true),
                    OrderRemark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderSn = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(nullable: true),
                    ProductUrl = table.Column<int>(nullable: false),
                    ProductName = table.Column<int>(nullable: false),
                    ItemPrice = table.Column<decimal>(nullable: false),
                    ItemCount = table.Column<int>(nullable: false),
                    ItemTotalPrice = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
