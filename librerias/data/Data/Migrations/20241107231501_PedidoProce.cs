using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class PedidoProce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cantidad",
                table: "pedidos");

            migrationBuilder.DropColumn(
                name: "fecha",
                table: "detalles_pedidos");

            migrationBuilder.RenameColumn(
                name: "precioTotal",
                table: "detalles_pedidos",
                newName: "cantidad");

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha",
                table: "pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "total",
                table: "pedidos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha",
                table: "pedidos");

            migrationBuilder.DropColumn(
                name: "total",
                table: "pedidos");

            migrationBuilder.RenameColumn(
                name: "cantidad",
                table: "detalles_pedidos",
                newName: "precioTotal");

            migrationBuilder.AddColumn<int>(
                name: "cantidad",
                table: "pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha",
                table: "detalles_pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4725d6-6dc4-4d3f-ab81-dda36159300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be4aa689-f664-4c99-a927-bcfdb4d1e836", "AQAAAAIAAYagAAAAEPKPenRS7M3fsWBaN4yba6c3jq3OH3UKzIX6DOJeRYf0FakeI/71AtSVnpdG9z+dpA==", "80b6c890-88cf-400b-9013-28f3b4d0ab1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e770a4e5-0c7e-4b77-baa6-277a22e1656a", "AQAAAAIAAYagAAAAEOcymx5Y5ot8j0+6aX8AQnoPRkyW4/ejXmiA6VSgLrxyZuDfMdVharavbzvKuj8h7g==", "05777cf0-d4a3-49b8-88b2-539f2d7e9d08" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14496c64-eb2a-41cb-8a83-190f510a5326", "AQAAAAIAAYagAAAAEOyUFD2/7arpLTs1sPIJXiAdYNRAzjRgP7SJ+LYcj6ogyt7tUmpvF49vH2RVc1Ck2Q==", "306f0ceb-dbef-4cbf-bae6-1cc9fb637d51" });
        }
    }
}
