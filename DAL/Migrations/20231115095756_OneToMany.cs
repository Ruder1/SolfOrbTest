using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class OneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersWithItems_OrderItems_OrderItemId",
                table: "OrdersWithItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersWithItems_Orders_OrderId",
                table: "OrdersWithItems");

            migrationBuilder.DropIndex(
                name: "IX_OrdersWithItems_OrderId",
                table: "OrdersWithItems");

            migrationBuilder.DropIndex(
                name: "IX_OrdersWithItems_OrderItemId",
                table: "OrdersWithItems");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 11, 13, 6, 53, 3, 965, DateTimeKind.Utc).AddTicks(828));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 11, 13, 6, 53, 3, 965, DateTimeKind.Utc).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 11, 13, 6, 53, 3, 965, DateTimeKind.Utc).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 11, 13, 6, 53, 3, 965, DateTimeKind.Utc).AddTicks(831));

            migrationBuilder.CreateIndex(
                name: "IX_OrdersWithItems_OrderId",
                table: "OrdersWithItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersWithItems_OrderItemId",
                table: "OrdersWithItems",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersWithItems_OrderItems_OrderItemId",
                table: "OrdersWithItems",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersWithItems_Orders_OrderId",
                table: "OrdersWithItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
