using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controller.Migrations
{
    public partial class demo_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "ProductDetailSize");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "ProductDetailSize");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ProductDetailSize");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "ProductDetailColor");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "ProductDetailColor");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ProductDetailColor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "ProductDetailSize",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "ProductDetailSize",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ProductDetailSize",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "ProductDetailColor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "ProductDetailColor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ProductDetailColor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
