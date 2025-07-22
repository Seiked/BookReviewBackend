using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookReview.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BooksSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Category", "CreatedAt", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", "Programming", new DateTime(2025, 7, 22, 8, 7, 42, 785, DateTimeKind.Utc).AddTicks(8935), "A Handbook of Agile Software Craftsmanship", "Clean Code" },
                    { 2, "Andrew Hunt & David Thomas", "Programming", new DateTime(2025, 7, 22, 8, 7, 42, 785, DateTimeKind.Utc).AddTicks(8940), "Your Journey to Mastery", "The Pragmatic Programmer" },
                    { 3, "George Orwell", "Dystopia", new DateTime(2025, 7, 22, 8, 7, 42, 785, DateTimeKind.Utc).AddTicks(8942), "A novel about a dystopian future and government surveillance", "1984" },
                    { 4, "Harper Lee", "Classic", new DateTime(2025, 7, 22, 8, 7, 42, 785, DateTimeKind.Utc).AddTicks(8973), "A novel about racial injustice in the Deep South", "To Kill a Mockingbird" },
                    { 5, "James Clear", "Self-Help", new DateTime(2025, 7, 22, 8, 7, 42, 785, DateTimeKind.Utc).AddTicks(8975), "An Easy & Proven Way to Build Good Habits & Break Bad Ones", "Atomic Habits" },
                    { 6, "Yuval Noah Harari", "History", new DateTime(2025, 7, 22, 8, 7, 42, 785, DateTimeKind.Utc).AddTicks(8976), "Explores the history and impact of Homo sapiens on the world", "Sapiens: A Brief History of Humankind" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Books");
        }
    }
}
