using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class SoyTakeshiEsUnGustoBonitoDia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4725d6-6dc4-4d3f-ab81-dda36159300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8c8f838-8bc3-49e7-b72d-743a3cdae7e3", "AQAAAAIAAYagAAAAEN+CGw+hCefhuWZx1iIyYQlY5cVmVUV36Y4oUdXV/4DLh8lcBgovzVAuCo2alqj28g==", "8af6a75c-0cf0-41fb-9538-5120690a9438" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e223b8b3-76f5-4c7a-9101-4cf23f140160", "AQAAAAIAAYagAAAAEAtS92EbR74rn5xI8yswIItdaRtL5fwiWzBcn8DedjZMUlmIWxnz3bF04RJzM70AcQ==", "7b141967-47fd-460a-8bb2-6c0c0ae42f21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05af84c6-cca8-474c-b6ba-ebfbf0a7f0ab", "AQAAAAIAAYagAAAAEONsPcKinB0zdGtk5O7i6JFHfW3iMfQy/dvCJ8Ssfa3E6Y1MVVi0vTTDL6GXeHCVcA==", "07cdd802-a3c5-4935-ad53-4cc9dd25aa4e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4725d6-6dc4-4d3f-ab81-dda36159300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf2d7ad5-6bf7-4159-ad90-7ffdb968e3ef", "AQAAAAIAAYagAAAAEGwnvMwg2KicCneYnlqqbJAj3+wZ7f+g0uNsgIM39Vhp+8uP456sjllFtN00AUA4Kw==", "7f58f95d-1ff9-4f2e-8b23-28edcf8fe8ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8be033f-261b-41e7-834a-b70c4827e1f2", "AQAAAAIAAYagAAAAEJQ1ol7xrI6mQIPh67sEHvuVXZnBkxMimFSaWAXJNHdWeGuA2L97KzErJjUFGxqAYA==", "a9f28c83-68c1-4bf7-86cc-f28e20e82966" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95d72560-2f8a-4714-8457-b3cb58098a2e", "AQAAAAIAAYagAAAAEJ85Rdx32+T58X79mdfs1OcUjPiQWITpA6SLKdiJdzyyU0RMgO81+CCfz1C2ONHImA==", "33d10f5f-ebef-4c4d-8756-8e7d085c852e" });
        }
    }
}
