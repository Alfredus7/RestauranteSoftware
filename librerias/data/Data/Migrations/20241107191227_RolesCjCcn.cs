using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class RolesCjCcn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "Admin", "ADMIN" },
                    { "a7e02d5b-2a1c-4d42-bb91-8c971e983bb7", "a7e02d5b-2a1c-4d42-bb91-8c971e983bb7", "Cajero", "CAJERO" },
                    { "b8d54e89-4b8c-47b2-a3bf-6c0a9fa6c9b3", "b8d54e89-4b8c-47b2-a3bf-6c0a9fa6c9b3", "Cocinero", "COCINERO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5d4725d6-6dc4-4d3f-ab81-dda36159300e", 0, "be4aa689-f664-4c99-a927-bcfdb4d1e836", "admin@email.com", true, false, null, null, "ADMIN@EMAIL.COM", "AQAAAAIAAYagAAAAEPKPenRS7M3fsWBaN4yba6c3jq3OH3UKzIX6DOJeRYf0FakeI/71AtSVnpdG9z+dpA==", null, false, "80b6c890-88cf-400b-9013-28f3b4d0ab1c", false, "admin@email.com" },
                    { "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf", 0, "e770a4e5-0c7e-4b77-baa6-277a22e1656a", "cocinero@email.com", true, false, null, null, "COCINERO@EMAIL.COM", "AQAAAAIAAYagAAAAEOcymx5Y5ot8j0+6aX8AQnoPRkyW4/ejXmiA6VSgLrxyZuDfMdVharavbzvKuj8h7g==", null, false, "05777cf0-d4a3-49b8-88b2-539f2d7e9d08", false, "cocinero@email.com" },
                    { "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd", 0, "14496c64-eb2a-41cb-8a83-190f510a5326", "cajero@email.com", true, false, null, null, "CAJERO@EMAIL.COM", "AQAAAAIAAYagAAAAEOyUFD2/7arpLTs1sPIJXiAdYNRAzjRgP7SJ+LYcj6ogyt7tUmpvF49vH2RVc1Ck2Q==", null, false, "306f0ceb-dbef-4cbf-bae6-1cc9fb637d51", false, "cajero@email.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "5d4725d6-6dc4-4d3f-ab81-dda36159300e" },
                    { "b8d54e89-4b8c-47b2-a3bf-6c0a9fa6c9b3", "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf" },
                    { "a7e02d5b-2a1c-4d42-bb91-8c971e983bb7", "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "5d4725d6-6dc4-4d3f-ab81-dda36159300e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b8d54e89-4b8c-47b2-a3bf-6c0a9fa6c9b3", "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a7e02d5b-2a1c-4d42-bb91-8c971e983bb7", "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7e02d5b-2a1c-4d42-bb91-8c971e983bb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8d54e89-4b8c-47b2-a3bf-6c0a9fa6c9b3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4725d6-6dc4-4d3f-ab81-dda36159300e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd");
        }
    }
}
