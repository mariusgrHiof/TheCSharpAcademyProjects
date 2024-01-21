using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBudget.mariusgrHiof.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Electronic devices", "Electronic" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CategoryId", "Date", "Name" },
                values: new object[] { 3, 10000m, 2, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samsung TV" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Car parts", "Car Parts" });
        }
    }
}
