using Microsoft.EntityFrameworkCore.Migrations;

namespace DataImporter.Web.Data.Migrations
{
    public partial class updateColumnDatasTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColumnData_Groups_GroupId",
                table: "ColumnData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColumnData",
                table: "ColumnData");

            migrationBuilder.RenameTable(
                name: "ColumnData",
                newName: "ColumnDatas");

            migrationBuilder.RenameIndex(
                name: "IX_ColumnData_GroupId",
                table: "ColumnDatas",
                newName: "IX_ColumnDatas_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColumnDatas",
                table: "ColumnDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ColumnDatas_Groups_GroupId",
                table: "ColumnDatas",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColumnDatas_Groups_GroupId",
                table: "ColumnDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColumnDatas",
                table: "ColumnDatas");

            migrationBuilder.RenameTable(
                name: "ColumnDatas",
                newName: "ColumnData");

            migrationBuilder.RenameIndex(
                name: "IX_ColumnDatas_GroupId",
                table: "ColumnData",
                newName: "IX_ColumnData_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColumnData",
                table: "ColumnData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ColumnData_Groups_GroupId",
                table: "ColumnData",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
