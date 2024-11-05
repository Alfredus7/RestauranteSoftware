using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data.Entitys;
using RestauranteSoftware.Data;

namespace RestauranteSoftware.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pedidos.Include(p => p.EstadoPedido);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pedidos/Details/5
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

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["EstadoId"] = new SelectList(_context.EstadosPedidos, "Id", "Nombre");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cantidad,EstadoId")] PedidosEntitys pedidosEntitys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidosEntitys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoId"] = new SelectList(_context.EstadosPedidos, "Id", "Nombre", pedidosEntitys.EstadoId);
            return View(pedidosEntitys);
        }

        // GET: Pedidos/Edit/5
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

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantidad,EstadoId")] PedidosEntitys pedidosEntitys)
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

        // GET: Pedidos/Delete/5
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

        // POST: Pedidos/Delete/5
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
    }
}
