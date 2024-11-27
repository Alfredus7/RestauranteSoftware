using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class agregoprioridad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Prioridad",
                table: "pedidos",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4725d6-6dc4-4d3f-ab81-dda36159300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8b81546-8fc0-4797-901c-e293465d4ea0", "AQAAAAIAAYagAAAAEO57M+zNVTVskcAAdRWZxfk0aWKOblzqbyJbqPEznFjqEoGhePAREhINY6DzdFRsAA==", "8b992c63-9477-431c-be78-e612c8830e33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29e01350-14a8-47b0-aa52-e66091ec998e", "AQAAAAIAAYagAAAAEF6LKS2vdMbukkNHi427oWLWMjzwMQ57v8RtFr5nO5ney7jbv0F943FWM72DzpsCKA==", "2ef51ea8-794d-4ec6-bc3d-1d87e1ca43a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06f72947-2c2a-4aa4-9f04-df1b1484fb69", "AQAAAAIAAYagAAAAEH1rjJ1J+BzKe5CW9c0c6TqEqRIJBMOsGK2LEm1ai9S7EhcppytV9GNvDUY4WLacvg==", "4e75b055-86e3-4291-b6be-7e33901c19e0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prioridad",
                table: "pedidos");

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
    }
}
