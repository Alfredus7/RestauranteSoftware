using Data.Data.Entitys;

namespace RestauranteSoftware.viewModels
{
    public class PedidosViews
    {
        public IEnumerable<PedidosEntitys> pedidos;
        public IEnumerable<DetallesPedidosEntitys> detallesPedidos;
        public PedidosViews() { }

    }
}
