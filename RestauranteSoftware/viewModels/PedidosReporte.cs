using Data.Data.Entitys;

namespace RestauranteSoftware.viewModels
{
    public class PedidosReporte
    {
        public PedidosEntitys pedidos;
        public IEnumerable<DetallesPedidosEntitys> detallesPedidos;
        public PedidosReporte() { }
    }
}
