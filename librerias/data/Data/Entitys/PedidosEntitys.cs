using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Entitys
{
    [Table("pedidos")]
    public class PedidosEntitys
    {
        [Key]
        [Column("id_pedido")]
        public int Id { get; set; }

        [Column("tipo_pedido")]
        public int TipoPedidoId { get; set; }

        [Column("estado")]
        public int EstadoId { get; set; }
    }
}
