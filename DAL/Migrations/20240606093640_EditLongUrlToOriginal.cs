using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditLongUrlToOriginal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LongUrl",
                table: "UrlManagements",
                newName: "OriginalUrl");

            migrationBuilder.InsertData(
                table: "UrlManagements",
                columns: new[] { "Id", "Clicks", "CreatedAt", "OriginalUrl", "ShortUrl", "UserId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 6, 6, 12, 36, 39, 334, DateTimeKind.Local).AddTicks(6114), "https://www.google.com", "https://localhost:44345/1", "5ffe5d4a-1bef-46a7-9f7f-8d2f3129602c" },
                    { 2, 0, new DateTime(2024, 6, 6, 12, 36, 39, 334, DateTimeKind.Local).AddTicks(6159), "https://www.facebook.com", "https://localhost:44345/2", "5ffe5d4a-1bef-46a7-9f7f-8d2f3129602c" },
                    { 3, 0, new DateTime(2024, 6, 6, 12, 36, 39, 334, DateTimeKind.Local).AddTicks(6162), "https://www.youtube.com", "https://localhost:44345/3", "5ffe5d4a-1bef-46a7-9f7f-8d2f3129602c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UrlManagements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UrlManagements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UrlManagements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "OriginalUrl",
                table: "UrlManagements",
                newName: "LongUrl");
        }
    }
}
