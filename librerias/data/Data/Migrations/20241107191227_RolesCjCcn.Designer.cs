﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestauranteSoftware.Data;

#nullable disable

namespace RestauranteSoftware.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241107191227_RolesCjCcn")]
    partial class RolesCjCcn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Data.Entitys.ComidasEntitys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_comida");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descripcion");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("imagen_url");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("precio");

                    b.HasKey("Id");

                    b.ToTable("comidas");
                });

            modelBuilder.Entity("Data.Data.Entitys.DetallesPedidosEntitys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_detalles_pedidos");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ComidaId")
                        .HasColumnType("int")
                        .HasColumnName("comida");

                    b.Property<DateTime>("FechaOrden")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int")
                        .HasColumnName("pedido");

                    b.Property<int>("precioTotal")
                        .HasColumnType("int")
                        .HasColumnName("precioTotal");

                    b.HasKey("Id");

                    b.HasIndex("ComidaId");

                    b.HasIndex("PedidoId");

                    b.ToTable("detalles_pedidos");
                });

            modelBuilder.Entity("Data.Data.Entitys.EstadosPedidosEntitys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_estado_pedido");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("estados_pedidos");
                });

            modelBuilder.Entity("Data.Data.Entitys.PedidosEntitys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_pedido");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int")
                        .HasColumnName("estado");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("pedidos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "a7e02d5b-2a1c-4d42-bb91-8c971e983bb7",
                            ConcurrencyStamp = "a7e02d5b-2a1c-4d42-bb91-8c971e983bb7",
                            Name = "Cajero",
                            NormalizedName = "CAJERO"
                        },
                        new
                        {
                            Id = "b8d54e89-4b8c-47b2-a3bf-6c0a9fa6c9b3",
                            ConcurrencyStamp = "b8d54e89-4b8c-47b2-a3bf-6c0a9fa6c9b3",
                            Name = "Cocinero",
                            NormalizedName = "COCINERO"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "5d4725d6-6dc4-4d3f-ab81-dda36159300e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "be4aa689-f664-4c99-a927-bcfdb4d1e836",
                            Email = "admin@email.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN@EMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPKPenRS7M3fsWBaN4yba6c3jq3OH3UKzIX6DOJeRYf0FakeI/71AtSVnpdG9z+dpA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "80b6c890-88cf-400b-9013-28f3b4d0ab1c",
                            TwoFactorEnabled = false,
                            UserName = "admin@email.com"
                        },
                        new
                        {
                            Id = "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "14496c64-eb2a-41cb-8a83-190f510a5326",
                            Email = "cajero@email.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "CAJERO@EMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOyUFD2/7arpLTs1sPIJXiAdYNRAzjRgP7SJ+LYcj6ogyt7tUmpvF49vH2RVc1Ck2Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "306f0ceb-dbef-4cbf-bae6-1cc9fb637d51",
                            TwoFactorEnabled = false,
                            UserName = "cajero@email.com"
                        },
                        new
                        {
                            Id = "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e770a4e5-0c7e-4b77-baa6-277a22e1656a",
                            Email = "cocinero@email.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "COCINERO@EMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOcymx5Y5ot8j0+6aX8AQnoPRkyW4/ejXmiA6VSgLrxyZuDfMdVharavbzvKuj8h7g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "05777cf0-d4a3-49b8-88b2-539f2d7e9d08",
                            TwoFactorEnabled = false,
                            UserName = "cocinero@email.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "5d4725d6-6dc4-4d3f-ab81-dda36159300e",
                            RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6"
                        },
                        new
                        {
                            UserId = "7c7b1288-2a9d-4d5f-bf4a-2d8b7b3cbadd",
                            RoleId = "a7e02d5b-2a1c-4d42-bb91-8c971e983bb7"
                        },
                        new
                        {
                            UserId = "6d6c3c9f-1a7d-4d6a-af9a-4d8d3f2a6cdf",
                            RoleId = "b8d54e89-4b8c-47b2-a3bf-6c0a9fa6c9b3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Data.Data.Entitys.DetallesPedidosEntitys", b =>
                {
                    b.HasOne("Data.Data.Entitys.ComidasEntitys", "Comida")
                        .WithMany()
                        .HasForeignKey("ComidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Data.Entitys.PedidosEntitys", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comida");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Data.Data.Entitys.PedidosEntitys", b =>
                {
                    b.HasOne("Data.Data.Entitys.EstadosPedidosEntitys", "EstadoPedido")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoPedido");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
