using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controller.Migrations
{
    public partial class db4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R1",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 30, 51, 253, DateTimeKind.Local).AddTicks(8400), new DateTime(2024, 10, 30, 11, 30, 51, 253, DateTimeKind.Local).AddTicks(8387) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R2",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 30, 51, 253, DateTimeKind.Local).AddTicks(8405), new DateTime(2024, 10, 30, 11, 30, 51, 253, DateTimeKind.Local).AddTicks(8404) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U1",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 30, 51, 253, DateTimeKind.Local).AddTicks(8661), new DateTime(2024, 10, 30, 11, 30, 51, 253, DateTimeKind.Local).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U2",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 30, 51, 253, DateTimeKind.Local).AddTicks(8665), new DateTime(2024, 10, 30, 11, 30, 51, 253, DateTimeKind.Local).AddTicks(8665) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R1",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 29, 9, 58, 24, 146, DateTimeKind.Local).AddTicks(638), new DateTime(2024, 10, 29, 9, 58, 24, 146, DateTimeKind.Local).AddTicks(626) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R2",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 29, 9, 58, 24, 146, DateTimeKind.Local).AddTicks(641), new DateTime(2024, 10, 29, 9, 58, 24, 146, DateTimeKind.Local).AddTicks(640) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U1",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 29, 9, 58, 24, 146, DateTimeKind.Local).AddTicks(907), new DateTime(2024, 10, 29, 9, 58, 24, 146, DateTimeKind.Local).AddTicks(906) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U2",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 29, 9, 58, 24, 146, DateTimeKind.Local).AddTicks(910), new DateTime(2024, 10, 29, 9, 58, 24, 146, DateTimeKind.Local).AddTicks(910) });
        }
    }
}
