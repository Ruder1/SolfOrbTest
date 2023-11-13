using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Indexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_Orders_Number_ProviderId",
                table: "Orders",
                columns: new[] { "Number", "ProviderId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_Number_ProviderId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 11, 13, 6, 19, 51, 882, DateTimeKind.Utc).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 11, 13, 6, 19, 51, 882, DateTimeKind.Utc).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 11, 13, 6, 19, 51, 882, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 11, 13, 6, 19, 51, 882, DateTimeKind.Utc).AddTicks(3100));
        }
    }
}
