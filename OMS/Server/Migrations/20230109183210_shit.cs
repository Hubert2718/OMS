using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OMS.Server.Migrations
{
    /// <inheritdoc />
    public partial class shit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 9, 19, 32, 10, 792, DateTimeKind.Local).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 1, 9, 19, 32, 10, 792, DateTimeKind.Local).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 1, 9, 19, 32, 10, 792, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressId", "ClientId", "Date", "Deleted", "OrderValue", "StatusId" },
                values: new object[,]
                {
                    { 4, 1, 2, new DateTime(2023, 1, 9, 19, 32, 10, 792, DateTimeKind.Local).AddTicks(6018), false, 0, 7 },
                    { 18, 1, 1, new DateTime(2023, 1, 9, 19, 32, 10, 792, DateTimeKind.Local).AddTicks(6022), false, 0, 1 },
                    { 77, 2, 2, new DateTime(2023, 1, 9, 19, 32, 10, 792, DateTimeKind.Local).AddTicks(6020), false, 0, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 9, 15, 17, 16, 157, DateTimeKind.Local).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 1, 9, 15, 17, 16, 157, DateTimeKind.Local).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 1, 9, 15, 17, 16, 157, DateTimeKind.Local).AddTicks(79));
        }
    }
}
