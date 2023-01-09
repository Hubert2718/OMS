using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMS.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 8, 16, 15, 32, 273, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 1, 8, 16, 15, 32, 273, DateTimeKind.Local).AddTicks(1210));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 1, 8, 16, 15, 32, 273, DateTimeKind.Local).AddTicks(1212));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 7, 17, 17, 28, 77, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 1, 7, 17, 17, 28, 77, DateTimeKind.Local).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 1, 7, 17, 17, 28, 77, DateTimeKind.Local).AddTicks(8362));
        }
    }
}
