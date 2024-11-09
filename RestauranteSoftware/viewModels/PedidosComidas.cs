using Data.Data.Entitys;
namespace RestauranteSoftware.viewModels
{
    public class PedidosComidas
    {
        public PedidosEntitys Pedido{ get; set; }
        public IList<ComidasEntitys>? Comidas { get; set; }
        public int cantidad { get; set; }
        public ListaComida ListaComida { get; set; }
    }
}