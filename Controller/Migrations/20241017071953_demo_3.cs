using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controller.Migrations
{
    public partial class demo_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "NgayCapNhat", "NgayTao", "Ten", "TrangThai", "UserId" },
                values: new object[] { "R1", new DateTime(2024, 10, 17, 14, 19, 53, 237, DateTimeKind.Local).AddTicks(8724), new DateTime(2024, 10, 17, 14, 19, 53, 237, DateTimeKind.Local).AddTicks(8715), "Admin", "Active", null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "NgayCapNhat", "NgayTao", "Ten", "TrangThai", "UserId" },
                values: new object[] { "R2", new DateTime(2024, 10, 17, 14, 19, 53, 237, DateTimeKind.Local).AddTicks(8726), new DateTime(2024, 10, 17, 14, 19, 53, 237, DateTimeKind.Local).AddTicks(8726), "Staff", "Active", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Ma", "NgayCapNhat", "NgayTao", "Password", "RoleId", "TrangThai", "Username" },
                values: new object[] { "U1", "admin@gmail.com", "U001", new DateTime(2024, 10, 17, 14, 19, 53, 237, DateTimeKind.Local).AddTicks(8867), new DateTime(2024, 10, 17, 14, 19, 53, 237, DateTimeKind.Local).AddTicks(8867), "admin001", "R1", "Active", "admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Ma", "NgayCapNhat", "NgayTao", "Password", "RoleId", "TrangThai", "Username" },
                values: new object[] { "U2", "staff@gmail.com", "U002", new DateTime(2024, 10, 17, 14, 19, 53, 237, DateTimeKind.Local).AddTicks(8872), new DateTime(2024, 10, 17, 14, 19, 53, 237, DateTimeKind.Local).AddTicks(8871), "staff001", "R2", "Active", "staff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U1");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U2");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R1");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R2");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "NgayCapNhat", "NgayTao", "Ten", "TrangThai", "UserId" },
                values: new object[] { "1", new DateTime(2024, 10, 17, 10, 27, 27, 936, DateTimeKind.Local).AddTicks(4738), new DateTime(2024, 10, 17, 10, 27, 27, 936, DateTimeKind.Local).AddTicks(4726), "Admin", "Active", null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "NgayCapNhat", "NgayTao", "Ten", "TrangThai", "UserId" },
                values: new object[] { "2", new DateTime(2024, 10, 17, 10, 27, 27, 936, DateTimeKind.Local).AddTicks(4741), new DateTime(2024, 10, 17, 10, 27, 27, 936, DateTimeKind.Local).AddTicks(4741), "Staff", "Active", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Ma", "NgayCapNhat", "NgayTao", "Password", "RoleId", "TrangThai", "Username" },
                values: new object[] { "1", "admin@gmail.com", "U001", new DateTime(2024, 10, 17, 10, 27, 27, 936, DateTimeKind.Local).AddTicks(4869), new DateTime(2024, 10, 17, 10, 27, 27, 936, DateTimeKind.Local).AddTicks(4868), "admin001", "1", "Active", "admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Ma", "NgayCapNhat", "NgayTao", "Password", "RoleId", "TrangThai", "Username" },
                values: new object[] { "2", "staff@gmail.com", "U002", new DateTime(2024, 10, 17, 10, 27, 27, 936, DateTimeKind.Local).AddTicks(4873), new DateTime(2024, 10, 17, 10, 27, 27, 936, DateTimeKind.Local).AddTicks(4873), "staff001", "2", "Active", "staff" });
        }
    }
}
