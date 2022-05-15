using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Udemy.WebApi.Migrations
{
    public partial class InitialProductAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "Name", "Price", "Stock" },
                values: new object[] { 1, new DateTime(2022, 4, 6, 17, 46, 50, 234, DateTimeKind.Local).AddTicks(7541), "www.asd.com", "Bilgisayar", 15000m, 134 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
