using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrganumatorMssql.Migrations
{
    /// <inheritdoc />
    public partial class addroleseedings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15bd4ae1-e9b9-4ddb-844a-339529d553e1", null, "Admin", "ADMIN" },
                    { "ef82acf5-4dca-4e24-8177-087a1e432a1d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15bd4ae1-e9b9-4ddb-844a-339529d553e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef82acf5-4dca-4e24-8177-087a1e432a1d");
        }
    }
}
