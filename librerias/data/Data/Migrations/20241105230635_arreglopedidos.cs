using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class arreglopedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_pedidos_estado",
                table: "pedidos",
                column: "estado");

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_estados_pedidos_estado",
                table: "pedidos",
                column: "estado",
                principalTable: "estados_pedidos",
                principalColumn: "id_estado_pedido",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_estados_pedidos_estado",
                table: "pedidos");

            migrationBuilder.DropIndex(
                name: "IX_pedidos_estado",
                table: "pedidos");
        }
    }
}
