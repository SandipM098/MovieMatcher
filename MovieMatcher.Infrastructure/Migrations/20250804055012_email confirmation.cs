using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMatcher.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class emailconfirmation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailConfirmationToken",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AppUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailConfirmationToken", "EmailConfirmed" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EmailConfirmationToken", "EmailConfirmed" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmationToken",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AppUsers");
        }
    }
}
