using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMS.Server.Migrations
{
    /// <inheritdoc />
    public partial class OrderProductsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 10, 16, 22, 3, 695, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 1, 10, 16, 22, 3, 695, DateTimeKind.Local).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 1, 10, 16, 22, 3, 695, DateTimeKind.Local).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 1, 10, 16, 22, 3, 695, DateTimeKind.Local).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2023, 1, 10, 16, 22, 3, 695, DateTimeKind.Local).AddTicks(2449));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 77,
                column: "Date",
                value: new DateTime(2023, 1, 10, 16, 22, 3, 695, DateTimeKind.Local).AddTicks(2447));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 10, 12, 3, 9, 447, DateTimeKind.Local).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 1, 10, 12, 3, 9, 447, DateTimeKind.Local).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 1, 10, 12, 3, 9, 447, DateTimeKind.Local).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 1, 10, 12, 3, 9, 447, DateTimeKind.Local).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2023, 1, 10, 12, 3, 9, 447, DateTimeKind.Local).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 77,
                column: "Date",
                value: new DateTime(2023, 1, 10, 12, 3, 9, 447, DateTimeKind.Local).AddTicks(3751));
        }
    }
}
