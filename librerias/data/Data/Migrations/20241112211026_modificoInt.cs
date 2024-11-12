using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class modificoInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "total",
                table: "pedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "precio",
                table: "comidas",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4725d6-6dc4-4d3f-ab81-dda36159300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1cb56f6-9d54-4390-ac0e-f9c7cf3169f0", "AQAAAAIAAYagAAAAEDemFWINwyefzZ6iqLPFmeha1Eg+AUn7cFD/ijrAJi/5hGCms9TjVWeF5YmrwneC0g==", "7d4c99b3-0dae-44c6-a781-1e2ed34faf93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efaf1e4b-bf10-49f6-9aa6-6b75b28d54fd", "AQAAAAIAAYagAAAAEDKU1LkC+zy4+mo/iNI9GgHeDFYMuXxb9pgR9AVcgGpynfEAJbRHO8L4DCFgQ7OBZg==", "d8508406-89f9-468a-949c-ca1d2ef982ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9a4e569-1c92-4bb5-93db-7871ece3127b", "AQAAAAIAAYagAAAAEDYzJgsN9kOG+zi5Bv/4mL89Pkd6cOi1DnSogonhl3ke1rz3CMJxkLNS5btLvgOSEA==", "849b8437-f39e-419b-a07a-54b5e82f64e9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "total",
                table: "pedidos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "precio",
                table: "comidas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
