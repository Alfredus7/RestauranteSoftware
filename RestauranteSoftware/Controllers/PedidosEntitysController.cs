using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data.Entitys;
using RestauranteSoftware.Data;
using RestauranteSoftware.viewModels;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;


namespace RestauranteSoftware.Controllers
{
    public class PedidosEntitysController : Controller
    {
        private readonly ApplicationDbContext _context;
        ListaComida listaComida = ListaComida.getListCom();
        private readonly IConverter _converter;
        public PedidosEntitysController(ApplicationDbContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;

        }


        public async Task<IActionResult> Reporte(string fecha)
        {
            if (!DateTime.TryParse(fecha, out DateTime fechaConvertida))
            {
                // Manejar error si la fecha no es válida
                return BadRequest("Fecha inválida.");
            }

            // Filtrar pedidos por la fecha convertida
            var applicationDbContext = _context.Pedidos
                .Include(p => p.EstadoPedido)
                .Where(p => p.Fecha.Date == fechaConvertida.Date);

            // Crear el modelo de vista
            PedidosViews pedidoViewModel = new PedidosViews
            {
                // Asignar los pedidos filtrados
                pedidos = await applicationDbContext.ToListAsync(),

                // Filtrar detalles de pedidos relacionados
                detallesPedidos = await _context.DetallesPedidos
                    .Include(x => x.Comida)
                    .Where(dp => dp.Pedido.Fecha.Date == fechaConvertida.Date)
                    .ToListAsync()
            };

            // Si no hay pedidos, enviar un mensaje indicando que no hay pedidos para esa fecha
            if (!pedidoViewModel.pedidos.Any())
            {
                // No hay pedidos para esa fecha
                ViewData["NoPedidos"] = "No hay pedidos para la fecha seleccionada.";
            }

            return View(pedidoViewModel);
        }


        public async Task<IActionResult> ReportePagados(string fecha)
        {
            if (!DateTime.TryParse(fecha, out DateTime fechaConvertida))
            {
                // Manejar error si la fecha no es válida
                return BadRequest("Fecha inválida.");
            }

            // Filtrar pedidos por la fecha y estado completado
            var applicationDbContext = _context.Pedidos
                .Include(p => p.EstadoPedido)
                .Where(p => p.Fecha.Date == fechaConvertida.Date && p.EstadoPedido. Nombre == "Pagado");

            // Crear el modelo de vista
            PedidosViews pedidoViewModel = new PedidosViews
            {
                // Asignar los pedidos filtrados
                pedidos = await applicationDbContext.ToListAsync(),

                // Filtrar detalles de pedidos relacionados
                detallesPedidos = await _context.DetallesPedidos
                    .Include(x => x.Comida)
                    .Where(dp => dp.Pedido.Fecha.Date == fechaConvertida.Date && dp.Pedido.EstadoPedido.Nombre == "Pagado")
                    .ToListAsync()
            };

            // Si no hay pedidos, enviar un mensaje indicando que no hay pedidos para esa fecha
            if (!pedidoViewModel.pedidos.Any())
            {
                // No hay pedidos para esa fecha
                ViewData["NoPedidos"] = "No hay pedidos para la fecha seleccionada.";
            }

            return View(pedidoViewModel);
        }




        public async Task<IActionResult> CrearReporte(string fecha)
        {

            if (!DateTime.TryParse(fecha, out DateTime fechaConvertida))
            {
                // Manejar error si la fecha no es válida
                return BadRequest("Fecha inválida.");
            }

            // Construir la URL completa de la vista que se desea convertir a PDF
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            string urlPagina = $"{baseUrl}/PedidosEntitys/Reporte?fecha={fecha}";

            // Configuración del documento PDF
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                    Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 },
                }
            };

            // Agrega los objetos (páginas) al documento PDF
            pdf.Objects.Add(new ObjectSettings
            {
                Page = urlPagina,
                WebSettings = new WebSettings
                {
                    DefaultEncoding = "utf-8",
                    Background = false // Esto deshabilita imágenes de fondo
                }
            });

            // Convierte el documento a PDF
            var archivoPDF = _converter.Convert(pdf);

            // Genera un nombre único para el archivo PDF
            string nombrePDF = $"reporte_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            // Devuelve el archivo PDF como una descarga
            return File(archivoPDF, "application/pdf", nombrePDF);
        }



        public async Task<IActionResult> CrearReportePagados(string fecha)
        {

            if (!DateTime.TryParse(fecha, out DateTime fechaConvertida))
            {
                // Manejar error si la fecha no es válida
                return BadRequest("Fecha inválida.");
            }

            // Construir la URL completa de la vista que se desea convertir a PDF
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            string urlPagina = $"{baseUrl}/PedidosEntitys/ReportePagados?fecha={fecha}";

            // Configuración del documento PDF
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                    Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 },
                }
            };

            // Agrega los objetos (páginas) al documento PDF
            pdf.Objects.Add(new ObjectSettings
            {
                Page = urlPagina,
                WebSettings = new WebSettings
                {
                    DefaultEncoding = "utf-8",
                    Background = false // Esto deshabilita imágenes de fondo
                }
            });

            // Convierte el documento a PDF
            var archivoPDF = _converter.Convert(pdf);

            // Genera un nombre único para el archivo PDF
            string nombrePDF = $"reporte_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            // Devuelve el archivo PDF como una descarga
            return File(archivoPDF, "application/pdf", nombrePDF);
        }







        // GET: PedidosEntitys
        public async Task<IActionResult> Index()
        {

            ViewData["EstadoId"] = new SelectList(_context.EstadosPedidos, "Id", "Nombre");
            var applicationDbContext = _context.Pedidos
                .Include(p => p.EstadoPedido)
                .OrderByDescending(p => p.IsPrioridad) // Prioritarios primero
                .ThenByDescending(p => p.Fecha); // Más recientes primero

            PedidosViews pedidoViewModel = new PedidosViews();
            pedidoViewModel.pedidos = await applicationDbContext.ToListAsync();
            pedidoViewModel.detallesPedidos = await _context.DetallesPedidos
                .Include(x => x.Comida)
                .ToListAsync();

            return View(pedidoViewModel);
        }





        // GET: PedidosEntitys/Create
        public async Task<IActionResult> Create(PedidosComidas pedidosComidas)
        {

            ViewData["EstadoId"] = new SelectList(_context.EstadosPedidos, "Id", "Nombre");
            if (pedidosComidas.Comidas == null)
            {
                listaComida.reiniciarVar();
                
            }
            pedidosComidas = new PedidosComidas();
            var pedido = new PedidosEntitys
            {
                Fecha = DateTime.Now // Asigna la fecha actual al campo Fecha
            };
            pedidosComidas.Pedido = pedido;
            var comidas = new List<ComidasEntitys>();
            comidas = await _context.Comidas.ToListAsync();
            pedidosComidas.Comidas = comidas;
            pedidosComidas.ListaComida = listaComida;
            return View(pedidosComidas);
        }

        // POST: PedidosEntitys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidosEntitys pedidosEntitys, int Totalito, bool IsPrioridad ,int Nro)
        {
            if (ModelState.IsValid)
            {
               
                // Asigna la fecha actual al campo Fecha si es necesario
                pedidosEntitys.EstadoId = 1; //id de pendiente
                pedidosEntitys.Fecha = DateTime.Now;
                pedidosEntitys.TotalPedido = Totalito;
                pedidosEntitys.IsPrioridad = IsPrioridad;
                pedidosEntitys.NroMesa = Nro;
                var list = listaComida.getIdCom();
                var listCant = listaComida.getCant();
                _context.Add(pedidosEntitys);

                await _context.SaveChangesAsync();
                for (int i = 0; i < listaComida.getIdCom().Count; i++)
                {
                    DetallesPedidosEntitys det = new DetallesPedidosEntitys();
                    det.PedidoId = pedidosEntitys.Id;
                    det.ComidaId = list[i];
                    det.Cantidad = listCant[i];

                    _context.DetallesPedidos.Add(det);
                    await _context.SaveChangesAsync();

                   
                }
                listaComida.reiniciarVar();

                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoId"] = new SelectList(_context.EstadosPedidos, "Id", "Nombre", pedidosEntitys.EstadoId);
            return View(pedidosEntitys);
        }

        // POST: PedidosEntitys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DateTime fecha, int totalPedido, bool isPrioridad, [Bind("EstadoId")] PedidosEntitys pedidosEntitys, int EstadoId, int Nro)
        {
            pedidosEntitys.Id = id;
            pedidosEntitys.EstadoId = EstadoId; //id de pendiente
            pedidosEntitys.Fecha = fecha;
            pedidosEntitys.TotalPedido = totalPedido;
            pedidosEntitys.IsPrioridad = isPrioridad;
            pedidosEntitys.NroMesa = Nro;
            try
            {
                _context.Update(pedidosEntitys);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidosEntitysExists(pedidosEntitys.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditComanda(int id, DateTime fecha, int totalPedido, bool isPrioridad, [Bind("EstadoId")] PedidosEntitys pedidosEntitys, int EstadoId, int Nro)
        {
            pedidosEntitys.Id = id;
            pedidosEntitys.EstadoId = EstadoId; //id de pendiente
            pedidosEntitys.Fecha = fecha;
            pedidosEntitys.TotalPedido = totalPedido;
            pedidosEntitys.IsPrioridad = isPrioridad;
            pedidosEntitys.NroMesa = Nro;
            try
            {
                _context.Update(pedidosEntitys);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidosEntitysExists(pedidosEntitys.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: PedidosEntitys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidosEntitys = await _context.Pedidos
                .Include(p => p.EstadoPedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidosEntitys == null)
            {
                return NotFound();
            }

            return View(pedidosEntitys);
        }

        // POST: PedidosEntitys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidosEntitys = await _context.Pedidos.FindAsync(id);
            if (pedidosEntitys != null)
            {
                _context.Pedidos.Remove(pedidosEntitys);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidosEntitysExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
        public async Task<IActionResult> AddComidas(int id, [Bind("Id,Fecha,EstadoId,TotalPedido")] PedidosEntitys pedido, int quantity, int precio, string nom)
        {
            var pedidosComidas = new PedidosComidas();
            ViewData["EstadoId"] = new SelectList(_context.EstadosPedidos, "Id", "Nombre");
            pedidosComidas.Pedido = pedido;
            var comidas = new List<ComidasEntitys>();
            
            comidas = await _context.Comidas.ToListAsync();
            pedidosComidas.Comidas = comidas;

            int i = listaComida.buscar(id);

            if (i == -1)
            {
                listaComida.addNom(nom);
                listaComida.addCant(quantity);
                listaComida.addTotal(precio * quantity);
                listaComida.addIdCom(id);
            }
            else
            {
                listaComida.sumarCant(quantity, i);
                listaComida.sumarTotal(precio * quantity, i);
            }
            
            return RedirectToAction(nameof(Create), pedidosComidas);
        }
        public async Task<IActionResult> DeleteComidas(int id, [Bind("Id,Fecha,EstadoId,TotalPedido")] PedidosEntitys pedido, int quantity, int precio, string nom)
        {
            var pedidosComidas = new PedidosComidas();
            ViewData["EstadoId"] = new SelectList(_context.EstadosPedidos, "Id", "Nombre");
            pedidosComidas.Pedido = pedido;
            var comidas = new List<ComidasEntitys>();

            comidas = await _context.Comidas.ToListAsync();
            pedidosComidas.Comidas = comidas;

            int i = listaComida.buscar(id);
            listaComida.eliminarComida(i);
            return RedirectToAction(nameof(Create), pedidosComidas);
        }

        public async Task<IActionResult> Imprimir(int? id)
        {
            // Validación inicial de parámetros
            if (id == null)
            {
                return NotFound("El ID del pedido no fue proporcionado.");
            }

            // Buscar el pedido en la base de datos
            var pedido = await _context.Pedidos
                .Include(p => p.EstadoPedido) // Incluir la relación con EstadoPedido
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pedido == null)
            {
                return NotFound($"No se encontró un pedido con el ID {id}.");
            }


            return View(pedido);


        }
        public async Task<PedidosViews> GetPedidosByDate(DateTime fecha)
        {
            PedidosViews pedidosViews = new PedidosViews();
            var applicationDbContext = _context.Pedidos.Include(p => p.EstadoPedido).Where(x => x.Fecha.Date == fecha.Date);
            PedidosViews pedidoViewModel = new PedidosViews();
            pedidoViewModel.pedidos = await applicationDbContext.ToListAsync();
            pedidoViewModel.detallesPedidos = await _context.DetallesPedidos.Include(x => x.Comida).ToListAsync();
                
            return (pedidosViews);
        }

        public async Task<IActionResult> Comanda()
        {
            ViewData["EstadoId"] = new SelectList(_context.EstadosPedidos, "Id", "Nombre");
            var applicationDbContext = _context.Pedidos
                .Include(p => p.EstadoPedido)
                .OrderByDescending(p => p.IsPrioridad) // Prioritarios primero
                .ThenByDescending(p => p.Fecha)
                .Where(p => p.EstadoId == 1);

            PedidosViews pedidoViewModel = new PedidosViews();
            pedidoViewModel.pedidos = await applicationDbContext.ToListAsync();
            pedidoViewModel.detallesPedidos = await _context.DetallesPedidos
                .Include(x => x.Comida)
                .ToListAsync();

            return View(pedidoViewModel);
        }
    }
}