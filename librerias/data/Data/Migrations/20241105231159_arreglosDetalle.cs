using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class arreglosDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fecha",
                table: "detalles_pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "precioTotal",
                table: "detalles_pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha",
                table: "detalles_pedidos");

            migrationBuilder.DropColumn(
                name: "precioTotal",
                table: "detalles_pedidos");
        }
    }
}
