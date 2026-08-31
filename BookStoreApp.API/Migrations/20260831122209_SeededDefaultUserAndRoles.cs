using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8b1c8127-d259-4d2e-b923-8ef5d6dc0f16", null, "User", "USER" },
                    { "e6bc83af-a28a-46ed-a195-b83dd026f2b0", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bfef30ad-77c0-407e-afdf-5fa451d958ac", 0, "82370cb5-b608-4429-99ee-401d606f1548", "admin@bookstore.com", false, null, null, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEH34XrBQcKPmOM4iO5KH98upPaVYbpns5A+gBAPeAV6df29kiIZk/2+LIYskOqeH7w==", null, false, "dee7be7b-7039-41b2-9d6b-aabee9a3ad4d", false, "admin@bookstore.com" },
                    { "f94b47be-f02b-4872-86c9-87ee2abf24c6", 0, "2ae678a1-1011-4f26-b1f9-67a21e7d860d", "user@bookstore.com", false, null, null, false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAELUh2BPFSqtht6nStiEvYeQW4JewG+jZkH27yS75XmtIP/HAHZ0Ed5R4s9mPp7KUJA==", null, false, "7a65c3e1-0331-430d-b133-fd18c35cbab7", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e6bc83af-a28a-46ed-a195-b83dd026f2b0", "bfef30ad-77c0-407e-afdf-5fa451d958ac" },
                    { "8b1c8127-d259-4d2e-b923-8ef5d6dc0f16", "f94b47be-f02b-4872-86c9-87ee2abf24c6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6bc83af-a28a-46ed-a195-b83dd026f2b0", "bfef30ad-77c0-407e-afdf-5fa451d958ac" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8b1c8127-d259-4d2e-b923-8ef5d6dc0f16", "f94b47be-f02b-4872-86c9-87ee2abf24c6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b1c8127-d259-4d2e-b923-8ef5d6dc0f16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6bc83af-a28a-46ed-a195-b83dd026f2b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfef30ad-77c0-407e-afdf-5fa451d958ac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94b47be-f02b-4872-86c9-87ee2abf24c6");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
