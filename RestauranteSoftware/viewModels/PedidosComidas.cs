using Data.Data.Entitys;
namespace RestauranteSoftware.viewModels
{
    public class PedidosComidas
    {
        public PedidosEntitys Pedido{ get; set; }
        public IList<ComidasEntitys>? Comidas { get; set; }
        public IList<int>? IdComidas { get; set; }
    }
}