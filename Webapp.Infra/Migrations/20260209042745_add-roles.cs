using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapp.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a1a9525c-51ab-45ee-9bb9-8958c6df85b0"), "3b10415d-2e9c-46bb-8b17-8eb5d6bb1ced", "Admin", "ADMIN" },
                    { new Guid("cd583380-a397-4c43-87f0-dccf7f4c521a"), "3b10415d-2e9c-46bb-8b17-8eb5d6bb1ced", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1a9525c-51ab-45ee-9bb9-8958c6df85b0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cd583380-a397-4c43-87f0-dccf7f4c521a"));
        }
    }
}
