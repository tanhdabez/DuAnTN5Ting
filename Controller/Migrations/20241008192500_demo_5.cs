using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controller.Migrations
{
    public partial class demo_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "Color");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "Size",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "Size",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "Size",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "Color",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "Color",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "Color",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
