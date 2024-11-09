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
        static List<int> ids = new List<int>();
        public PedidosEntitysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PedidosEntitys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pedidos.Include(p => p.EstadoPedido);
            return View(await applicationDbContext.ToListAsync());
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
            if (pedidosComidas.IdComidas == null)
            {
                ids = new List<int>();
                pedidosComidas = new PedidosComidas();
                var pedido = new PedidosEntitys
                {
                    Fecha = DateTime.Now // Asigna la fecha actual al campo Fecha
                };
                pedidosComidas.Pedido = pedido;
                
            }
            var comidas = new List<ComidasEntitys>();
            comidas = await _context.Comidas.ToListAsync();
            pedidosComidas.Comidas = comidas;
            return View(pedidosComidas);
        }

        // POST: PedidosEntitys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,EstadoId,TotalPedido")] PedidosEntitys pedidosEntitys)
        {
            if (ModelState.IsValid)
            {
                // Asigna la fecha actual al campo Fecha si es necesario
                pedidosEntitys.Fecha = DateTime.Now;
                _context.Add(pedidosEntitys);
                await _context.SaveChangesAsync();
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
        public async Task<IActionResult> AddComidas(int id, [Bind("Id,Fecha,EstadoId,TotalPedido")] PedidosEntitys pedido)
        {
            var pedidosComidas = new PedidosComidas();
            ViewData["EstadoId"] = new SelectList(_context.EstadosPedidos, "Id", "Nombre");
            pedidosComidas.Pedido = pedido;
            var comidas = new List<ComidasEntitys>();
            comidas = await _context.Comidas.ToListAsync();
            pedidosComidas.Comidas = comidas;
            ids.Add(id);
            pedidosComidas.IdComidas = ids;
            return RedirectToAction(nameof(Create), pedidosComidas);
        }
    }
}
