using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Web.Migrations.ApplicationDb
{
    public partial class RoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("29142a26-6d3a-4fdb-a412-6385e0e4ab93"), "f7ee8a8b-3f6c-4adb-bfff-950832e7c797", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("66b1a671-3bf6-404c-bfd0-1897f3351a67"), "24818d3a-100c-42a2-97ef-77c006d73476", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("60284edf-004e-4941-862e-abc322087ca2"), "60e65a12-cf68-4a96-9bcb-eefe3017a430", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("29142a26-6d3a-4fdb-a412-6385e0e4ab93"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60284edf-004e-4941-862e-abc322087ca2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66b1a671-3bf6-404c-bfd0-1897f3351a67"));
        }
    }
}
