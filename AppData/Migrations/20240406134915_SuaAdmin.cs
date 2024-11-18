﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class SuaAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "ID",
                keyValue: new Guid("2ec27ab7-5f67-4ed5-ae67-52f9c9726ebf"),
                columns: new[] { "Email", "SDT" },
                values: new object[] { "admin@gmail.com", "0985143915" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "ID",
                keyValue: new Guid("2ec27ab7-5f67-4ed5-ae67-52f9c9726ebf"),
                columns: new[] { "Email", "SDT" },
                values: new object[] { "tamncph25588@fpt.edu.vn", "0988143310" });
        }
    }
}
