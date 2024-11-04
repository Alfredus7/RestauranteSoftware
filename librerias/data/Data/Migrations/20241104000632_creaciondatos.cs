using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class creaciondatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estados_pedidos",
                columns: table => new
                {
                    id_estado_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados_pedidos", x => x.id_estado_pedido);
                });

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

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    id_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_pedido = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.id_pedido);
                    table.ForeignKey(
                        name: "FK_pedidos_estados_pedidos_estado",
                        column: x => x.estado,
                        principalTable: "estados_pedidos",
                        principalColumn: "id_estado_pedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedidos_tipos_pedidos_tipo_pedido",
                        column: x => x.tipo_pedido,
                        principalTable: "tipos_pedidos",
                        principalColumn: "id_tipo_pedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comidas",
                columns: table => new
                {
                    id_comida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comidas", x => x.id_comida);
                    table.ForeignKey(
                        name: "FK_comidas_tipos_platos_tipo",
                        column: x => x.tipo,
                        principalTable: "tipos_platos",
                        principalColumn: "id_tipo_plato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalles_pedidos",
                columns: table => new
                {
                    id_detalles_pedidos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pedido = table.Column<int>(type: "int", nullable: false),
                    comida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalles_pedidos", x => x.id_detalles_pedidos);
                    table.ForeignKey(
                        name: "FK_detalles_pedidos_comidas_comida",
                        column: x => x.comida,
                        principalTable: "comidas",
                        principalColumn: "id_comida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalles_pedidos_pedidos_pedido",
                        column: x => x.pedido,
                        principalTable: "pedidos",
                        principalColumn: "id_pedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comidas_tipo",
                table: "comidas",
                column: "tipo");

            migrationBuilder.CreateIndex(
                name: "IX_detalles_pedidos_comida",
                table: "detalles_pedidos",
                column: "comida");

            migrationBuilder.CreateIndex(
                name: "IX_detalles_pedidos_pedido",
                table: "detalles_pedidos",
                column: "pedido");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_estado",
                table: "pedidos",
                column: "estado");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_tipo_pedido",
                table: "pedidos",
                column: "tipo_pedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalles_pedidos");

            migrationBuilder.DropTable(
                name: "comidas");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "tipos_platos");

            migrationBuilder.DropTable(
                name: "estados_pedidos");

            migrationBuilder.DropTable(
                name: "tipos_pedidos");
        }
    }
}
