using Data.Data.Entitys;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RestauranteSoftware.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TiposPlatosEntitys> TiposPlatos { get; set; }
        public DbSet<ComidasEntitys> Comidas { get; set; }
        public DbSet<TiposPedidosEntitys> TiposPedidos { get; set; }
        public DbSet<EstadosPedidosEntitys> EstadosPedidos { get; set; }
        public DbSet<PedidosEntitys> Pedidos { get; set; }
        public DbSet<DetallesPedidosEntitys> DetallesPedidos { get; set; }
    }
}
