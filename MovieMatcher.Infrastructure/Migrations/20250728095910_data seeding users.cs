using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieMatcher.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dataseedingusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Email", "PasswordHash", "ProfileImageUrl", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", "admin123", null, "admin" },
                    { 2, "sandip@gmail.com", "sandip123", null, "sandip" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
