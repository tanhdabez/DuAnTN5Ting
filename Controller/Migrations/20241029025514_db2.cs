using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controller.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaPhuongXa",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "MaQuanHuyen",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "MaTinh",
                table: "Address");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaPhuongXa",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaQuanHuyen",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaTinh",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R1",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 25, 14, 21, 16, 45, DateTimeKind.Local).AddTicks(2522), new DateTime(2024, 10, 25, 14, 21, 16, 45, DateTimeKind.Local).AddTicks(2511) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R2",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 25, 14, 21, 16, 45, DateTimeKind.Local).AddTicks(2525), new DateTime(2024, 10, 25, 14, 21, 16, 45, DateTimeKind.Local).AddTicks(2524) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U1",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 25, 14, 21, 16, 45, DateTimeKind.Local).AddTicks(2763), new DateTime(2024, 10, 25, 14, 21, 16, 45, DateTimeKind.Local).AddTicks(2763) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U2",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 10, 25, 14, 21, 16, 45, DateTimeKind.Local).AddTicks(2768), new DateTime(2024, 10, 25, 14, 21, 16, 45, DateTimeKind.Local).AddTicks(2767) });
        }
    }
}
