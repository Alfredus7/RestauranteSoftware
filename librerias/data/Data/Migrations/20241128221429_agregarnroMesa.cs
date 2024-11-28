using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class agregarnroMesa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NroMesa",
                table: "pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4725d6-6dc4-4d3f-ab81-dda36159300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b20fda0-34d1-49d5-b853-3dea607fc1f6", "AQAAAAIAAYagAAAAEL54FWjwqkZ2FE+cYvzZX0rL8lpJkUsuFEBzybrRKvstCHLN+GPG+RTIN+H20uqYhQ==", "f79c72c3-5ffa-4255-a3fb-a22c519d1aaf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc045b45-d64f-4d9e-ae7c-13f3c7be430d", "AQAAAAIAAYagAAAAEMmoTvO4c24fUz1R6dcJmNmIeXNNQw7Z2hs0GmXine3wUumh2uHIAJRMZOw8SQUEgA==", "77e7438f-9aec-427b-ac7f-e53c416e82bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6bbb4dc-cfcf-4635-85de-e1d76910969c", "AQAAAAIAAYagAAAAEKhiCTSSxkCmUQK+01I1M9gx8HrErgwKtwNaD6mNd49l8pptHy77nqCeL8dSrqyg8Q==", "f2077120-363b-4230-a873-3e59e0c78b14" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NroMesa",
                table: "pedidos");

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
    }
}
