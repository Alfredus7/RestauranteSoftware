using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class EstaCosaDePorqueriaQueMePideHacerUnMigrationYaQueEstoyAquiTonotoElQueLoLea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4725d6-6dc4-4d3f-ab81-dda36159300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a6fea03-0b85-452c-85f3-99e2ebf53354", "AQAAAAIAAYagAAAAECReWNw329r0e1YPRzG6JlIqc+DIcAm9I/UgMiDcTkYP4lK7ozDGM2m/6CWM9YQW7A==", "148d93eb-ff09-4070-a56d-33a00d58a4d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4aab157-03b3-42c8-b22e-364ab4d153d6", "AQAAAAIAAYagAAAAEDroRswZXieCLXgIxFYNHXp7HL5fQdzWZLmp0qbtgTwJAqZ5wI29KhQLKkkh46MdtQ==", "177ddecc-7a6e-4a5a-a497-acf8104c4338" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4622a4ed-d2aa-40f1-bcbc-544cc6199efb", "AQAAAAIAAYagAAAAEG5au3Aa+k7mBdAUFf2uowhas+8h2iT+QKCCWoK/ce7t4BNCTSvmN0XgZC4icH3Hrg==", "5e9773a4-0f19-4067-b1cf-47253fca6a0d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
