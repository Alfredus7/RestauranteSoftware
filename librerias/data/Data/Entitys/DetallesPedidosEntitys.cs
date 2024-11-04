using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Entitys
{
    [Table("detalles_pedidos")]
    public class DetallesPedidosEntitys
    {
        [Key]
        [Column("id_detalles_pedidos")]
        public int Id { get; set; }

        [Column("pedido")]
        public int PedidoId { get; set; }

        [Column("comida")]
        public int ComidaId { get; set; }

        [ForeignKey("PedidoId")]
        public PedidosEntitys? Pedido { get; set; }

        [ForeignKey("ComidaId")]
        public ComidasEntitys? Comida { get; set; }
    }
}
