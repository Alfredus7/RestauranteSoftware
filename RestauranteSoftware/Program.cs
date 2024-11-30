using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestauranteSoftware.Data;
using ProyectoPDF.Extension;
using Data.Data.Entitys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

// Configuración de DinkToPdf
var context = new CustomAssemblyLoadContext();
context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "LibreriaPDF/libwkhtmltox.dll"));
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

var app = builder.Build();

// Inicializar datos predeterminados
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var contextDb = services.GetRequiredService<ApplicationDbContext>();

    // Inicializar estados predeterminados en la tabla estados_pedidos
    InicializarEstadosPedidos(contextDb);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

// Método para inicializar estados predeterminados
void InicializarEstadosPedidos(ApplicationDbContext contexto)
{
    var estadosPredeterminados = new[]
    {
        new EstadosPedidosEntitys { Nombre = "Pendientes" },
        new EstadosPedidosEntitys { Nombre = "Progreso" },
        new EstadosPedidosEntitys { Nombre = "Pagado" },
        new EstadosPedidosEntitys { Nombre = "Anulado" },
        new EstadosPedidosEntitys { Nombre = "Completado" }
    };

    foreach (var estado in estadosPredeterminados)
    {
        if (!contexto.EstadosPedidos.Any(e => e.Nombre == estado.Nombre))
        {
            contexto.EstadosPedidos.Add(estado);
        }
    }

    contexto.SaveChanges();
}
