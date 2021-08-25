using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamTimeChallenge.Web.Data.Migrations
{
    public partial class AddSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("e64cf0e5-f863-496a-a75a-14ab11e90818"), "9fb9c00b-6770-4975-9d82-a4398a2e2335", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a11bea62-628b-4f5e-9941-99f31c933514"), "a01e40fc-c120-4527-8817-5545de465999", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("863cf62e-4317-4db5-9557-88921b557329"), "90e57652-92b3-4d38-920f-6e11c6af7e08", "Teacher", "TEACHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("863cf62e-4317-4db5-9557-88921b557329"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a11bea62-628b-4f5e-9941-99f31c933514"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e64cf0e5-f863-496a-a75a-14ab11e90818"));
        }
    }
}
