using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controller.Migrations
{
    public partial class db3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R1",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 29, 9, 55, 14, 78, DateTimeKind.Local).AddTicks(8716), new DateTime(2024, 10, 29, 9, 55, 14, 78, DateTimeKind.Local).AddTicks(8705) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R2",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 29, 9, 55, 14, 78, DateTimeKind.Local).AddTicks(8718), new DateTime(2024, 10, 29, 9, 55, 14, 78, DateTimeKind.Local).AddTicks(8718) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U1",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 29, 9, 55, 14, 78, DateTimeKind.Local).AddTicks(9159), new DateTime(2024, 10, 29, 9, 55, 14, 78, DateTimeKind.Local).AddTicks(9158) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U2",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 29, 9, 55, 14, 78, DateTimeKind.Local).AddTicks(9163), new DateTime(2024, 10, 29, 9, 55, 14, 78, DateTimeKind.Local).AddTicks(9162) });
        }
    }
}
