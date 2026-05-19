using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EDA_Customer.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ItemsInCart", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, 2, "Alice", new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890") },
                    { 2, 1, "Bob", new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901") },
                    { 3, 3, "Charlie", new Guid("c3d4e5f6-a7b8-9012-cdef-123456789012") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, "Laptop", new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), 10 },
                    { 2, "Mouse", new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), 50 },
                    { 3, "Keyboard", new Guid("c3d4e5f6-a7b8-9012-cdef-123456789012"), 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
