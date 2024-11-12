using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Entitys
{
    [Table("comidas")]
    public class ComidasEntitys
    {
        [Key]
        [Column("id_comida")]
        public int Id { get; set; }
        [Column("imagen_url")]
        public string ImagenUrl { get; set; } = string.Empty;

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("precio")]
        public int Precio { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; } = string.Empty;
    }
}
