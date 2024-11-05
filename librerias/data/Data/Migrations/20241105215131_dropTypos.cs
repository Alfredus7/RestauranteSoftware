using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class dropTypos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comidas_tipos_platos_tipo",
                table: "comidas");

            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_tipos_pedidos_tipo_pedido",
                table: "pedidos");

            migrationBuilder.DropTable(
                name: "tipos_pedidos");

            migrationBuilder.DropTable(
                name: "tipos_platos");

            migrationBuilder.DropIndex(
                name: "IX_pedidos_tipo_pedido",
                table: "pedidos");

            migrationBuilder.DropIndex(
                name: "IX_comidas_tipo",
                table: "comidas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tipos_pedidos",
                columns: table => new
                {
                    id_tipo_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_pedidos", x => x.id_tipo_pedido);
                });

            migrationBuilder.CreateTable(
                name: "tipos_platos",
                columns: table => new
                {
                    id_tipo_plato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_platos", x => x.id_tipo_plato);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_tipo_pedido",
                table: "pedidos",
                column: "tipo_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_comidas_tipo",
                table: "comidas",
                column: "tipo");

            migrationBuilder.AddForeignKey(
                name: "FK_comidas_tipos_platos_tipo",
                table: "comidas",
                column: "tipo",
                principalTable: "tipos_platos",
                principalColumn: "id_tipo_plato",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_tipos_pedidos_tipo_pedido",
                table: "pedidos",
                column: "tipo_pedido",
                principalTable: "tipos_pedidos",
                principalColumn: "id_tipo_pedido",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
