using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data.Entitys;
using RestauranteSoftware.Data;
using RestauranteSoftware.viewModels;
using System.Collections.ObjectModel;


namespace RestauranteSoftware.Controllers
{
    public class PedidosEntitysController : Controller
    {
        private readonly ApplicationDbContext _context;
        ListaComida listaComida = ListaComida.getListCom();
        public PedidosEntitysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PedidosEntitys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pedidos.Include(p => p.EstadoPedido);
            PedidosViews pedidoViewModel = new PedidosViews();
            pedidoViewModel.pedidos = await applicationDbContext.ToListAsync();
            pedidoViewModel.detallesPedidos = await _context.DetallesPedidos.Include(x => x.Comida).ToListAsync();


            return View(pedidoViewModel);
        }

        // GET: PedidosEntitys/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("Id,Fecha,EstadoId,TotalPedido")] PedidosEntitys pedidosEntitys, int Totalito)
        {
            if (ModelState.IsValid)
            {
               
                // Asigna la fecha actual al campo Fecha si es necesario
                pedidosEntitys.EstadoId = 1; //id de pendiente
                pedidosEntitys.Fecha = DateTime.Now;
                pedidosEntitys.TotalPedido = Totalito; //aquí colocar pedido
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

        // GET: PedidosEntitys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidosEntitys = await _context.Pedidos.FindAsync(id);
            if (pedidosEntitys == null)
            {
                return NotFound();
            }
            ViewData["EstadoId"] = new SelectList(_context.EstadosPedidos, "Id", "Nombre", pedidosEntitys.EstadoId);
            return View(pedidosEntitys);
        }

        // POST: PedidosEntitys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,EstadoId,TotalPedido")] PedidosEntitys pedidosEntitys)
        {
            if (id != pedidosEntitys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
            ViewData["EstadoId"] = new SelectList(_context.EstadosPedidos, "Id", "Nombre", pedidosEntitys.EstadoId);
            return View(pedidosEntitys);
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
    }
}