using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangesMinor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "courses");

            migrationBuilder.AddColumn<bool>(
                name: "is_visible",
                table: "courses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "photo_path",
                table: "courses",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("ce9b1d65-086a-4c11-8f40-e5dbb43391cd"),
                column: "created_date",
                value: new DateTime(2025, 1, 1, 18, 25, 30, 463, DateTimeKind.Utc).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("ce9b1d69-086a-4c11-8f40-e5dbb43391cd"),
                column: "created_date",
                value: new DateTime(2025, 1, 1, 18, 25, 30, 463, DateTimeKind.Utc).AddTicks(3050));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_visible",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "photo_path",
                table: "courses");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "courses",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("ce9b1d65-086a-4c11-8f40-e5dbb43391cd"),
                column: "created_date",
                value: new DateTime(2024, 12, 30, 17, 2, 44, 44, DateTimeKind.Utc).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("ce9b1d69-086a-4c11-8f40-e5dbb43391cd"),
                column: "created_date",
                value: new DateTime(2024, 12, 30, 17, 2, 44, 44, DateTimeKind.Utc).AddTicks(9654));
        }
    }
}
