using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class arreglos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Prioridad",
                table: "pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4725d6-6dc4-4d3f-ab81-dda36159300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4aad6660-de51-45a1-9eeb-ddcf1dc42a2d", "AQAAAAIAAYagAAAAEIjeFjE48DwIDiZ6JwgTy5Tjulw4vCBCVtvACkobLywwU3wL+dsTYCkKmWbOX9g4Yg==", "ed3cfd8d-96d7-4f0e-a6fa-9f5279e55b3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4431d802-8eda-4ada-a418-db70955bdeff", "AQAAAAIAAYagAAAAEECDWPsbqUqSG52ltG1YvmhVJmdBRJqw7HvmvosC9TMZDsVQs+V/E2NxC49qphoc/w==", "36bfcdba-3f54-4134-be62-c100dfd9992b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b49dcd4a-1f81-4857-83f9-65e39259a1a7", "AQAAAAIAAYagAAAAEPg0vHbLheQBsvrDB+D89M+UIML9sAEmQk2Wqy92wuFIDsviVMewNvnkSIfunMXNpA==", "def74058-f7ac-4bfa-8168-01fdc899fffc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Prioridad",
                table: "pedidos",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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
    }
}
