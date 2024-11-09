using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class PediComida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4725d6-6dc4-4d3f-ab81-dda36159300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99ec1b4f-a001-4495-bb79-a669fb0817a9", "AQAAAAIAAYagAAAAEDRrn78IoU6bZ5BB+upqdMiX0QnsMralw3CtVwtclBe+WlKvbtjD9pvZOZ8+bZKAaw==", "4f6f5462-4571-49ab-bb87-7e6e4230e1b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bee9007-174d-4990-927c-c29d666d9bf0", "AQAAAAIAAYagAAAAEA5ltKdrHX2MPowQemmZd+voQyZBpSup0/EiSvz6wpK4PIwS30dZE1+QY+YNz1/oIg==", "886157c0-72fb-4a2a-a9e5-8b6a3c04d28a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b73e0305-6f5e-4e9c-94f0-f8eb38bc62ac", "AQAAAAIAAYagAAAAECE9bf1gEo/PlnOJ+ozynGa6NK7IABqpHDamStnZtuu2ZBeWQNZBrUYrlGLnS8YJOQ==", "6f3e17a6-8381-4805-ae82-aa6ed58d7176" });
        }
    }
}
