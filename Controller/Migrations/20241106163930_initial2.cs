using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controller.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Customer_CustomerId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "DiaChiChiTiet",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "HoVaTen",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "MaPhuongXa",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "MaQuanHuyen",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "MaTinh",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "Address");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R1",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 11, 6, 23, 39, 30, 82, DateTimeKind.Local).AddTicks(3113), new DateTime(2024, 11, 6, 23, 39, 30, 82, DateTimeKind.Local).AddTicks(3099) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R2",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 11, 6, 23, 39, 30, 82, DateTimeKind.Local).AddTicks(3116), new DateTime(2024, 11, 6, 23, 39, 30, 82, DateTimeKind.Local).AddTicks(3115) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U1",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 11, 6, 23, 39, 30, 82, DateTimeKind.Local).AddTicks(3338), new DateTime(2024, 11, 6, 23, 39, 30, 82, DateTimeKind.Local).AddTicks(3337) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U2",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 11, 6, 23, 39, 30, 82, DateTimeKind.Local).AddTicks(3341), new DateTime(2024, 11, 6, 23, 39, 30, 82, DateTimeKind.Local).AddTicks(3341) });

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Customer_CustomerId",
                table: "Address",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Customer_CustomerId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DiaChiChiTiet",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HoVaTen",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaPhuongXa",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaQuanHuyen",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaTinh",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SDT",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R1",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 11, 3, 23, 1, 7, 31, DateTimeKind.Local).AddTicks(7712), new DateTime(2024, 11, 3, 23, 1, 7, 31, DateTimeKind.Local).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "R2",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 11, 3, 23, 1, 7, 31, DateTimeKind.Local).AddTicks(7715), new DateTime(2024, 11, 3, 23, 1, 7, 31, DateTimeKind.Local).AddTicks(7715) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U1",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 11, 3, 23, 1, 7, 31, DateTimeKind.Local).AddTicks(7857), new DateTime(2024, 11, 3, 23, 1, 7, 31, DateTimeKind.Local).AddTicks(7856) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "U2",
                columns: new[] { "NgayCapNhat", "NgayTao" },
                values: new object[] { new DateTime(2024, 11, 3, 23, 1, 7, 31, DateTimeKind.Local).AddTicks(7904), new DateTime(2024, 11, 3, 23, 1, 7, 31, DateTimeKind.Local).AddTicks(7904) });

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Customer_CustomerId",
                table: "Address",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
