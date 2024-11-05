using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class añadirImagenComida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imagen_url",
                table: "comidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagen_url",
                table: "comidas");
        }
    }
}
