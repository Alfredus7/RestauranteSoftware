using Data.Data.Entitys;
using Microsoft.AspNetCore.Identity;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            // Identificadores de roles
            string ADMIN_ID = "5d4725d6-6dc4-4d3f-ab81-dda36159300e";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            string CAJERO_ROL_ID = "a7e02d5b-2a1c-4d42-bb91-8c971e983bb7";
            string COCINERO_ROL_ID = "b8d54e89-4b8c-47b2-a3bf-6c0a9fa6c9b3";

            // Identificadores de usuarios
            string CAJERO_USER_ID = "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd";
            string COCINERO_USER_ID = "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf";

            // Seed del rol Admin
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            // Seed del rol Cajero
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Cajero",
                NormalizedName = "CAJERO",
                Id = CAJERO_ROL_ID,
                ConcurrencyStamp = CAJERO_ROL_ID
            });

            // Seed del rol Cocinero
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Cocinero",
                NormalizedName = "COCINERO",
                Id = COCINERO_ROL_ID,
                ConcurrencyStamp = COCINERO_ROL_ID
            });

            // Crear usuario Admin y asignar contraseña
            var adminUser = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "admin@email.com",
                EmailConfirmed = true,
                UserName = "admin@email.com",
                NormalizedUserName = "ADMIN@EMAIL.COM",
            };

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "As12345!");
            builder.Entity<IdentityUser>().HasData(adminUser);

            // Crear usuario Cajero y asignar contraseña
            var cajeroUser = new IdentityUser
            {
                Id = CAJERO_USER_ID,
                Email = "cajero@email.com",
                EmailConfirmed = true,
                UserName = "cajero@email.com",
                NormalizedUserName = "CAJERO@EMAIL.COM",
            };
            cajeroUser.PasswordHash = ph.HashPassword(cajeroUser, "Caja7589$");
            builder.Entity<IdentityUser>().HasData(cajeroUser);

            // Crear usuario Cocinero y asignar contraseña
            var cocineroUser = new IdentityUser
            {
                Id = COCINERO_USER_ID,
                Email = "cocinero@email.com",
                EmailConfirmed = true,
                UserName = "cocinero@email.com",
                NormalizedUserName = "COCINERO@EMAIL.COM",
            };
            cocineroUser.PasswordHash = ph.HashPassword(cocineroUser, "Coci6756#");
            builder.Entity<IdentityUser>().HasData(cocineroUser);

            // Asignar el rol Admin al usuario Admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            // Asignar el rol Cajero al usuario Cajero
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = CAJERO_ROL_ID,
                UserId = CAJERO_USER_ID
            });

            // Asignar el rol Cocinero al usuario Cocinero
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = COCINERO_ROL_ID,
                UserId = COCINERO_USER_ID
            });

        }

        public DbSet<ComidasEntitys> Comidas { get; set; }
        public DbSet<EstadosPedidosEntitys> EstadosPedidos { get; set; }
        public DbSet<PedidosEntitys> Pedidos { get; set; }
        public DbSet<DetallesPedidosEntitys> DetallesPedidos { get; set; }
    }
}
