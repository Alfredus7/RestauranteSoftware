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
    public class DetallesPedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetallesPedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetallesPedidos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetallesPedidos.Include(d => d.Comida).Include(d => d.Pedido);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetallesPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesPedidosEntitys = await _context.DetallesPedidos
                .Include(d => d.Comida)
                .Include(d => d.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detallesPedidosEntitys == null)
            {
                return NotFound();
            }

            return View(detallesPedidosEntitys);
        }

        // GET: DetallesPedidos/Create
        public IActionResult Create()
        {
            ViewData["ComidaId"] = new SelectList(_context.Comidas, "Id", "Descripcion");
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id");
            return View();
        }

        // POST: DetallesPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PedidoId,ComidaId")] DetallesPedidosEntitys detallesPedidosEntitys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallesPedidosEntitys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComidaId"] = new SelectList(_context.Comidas, "Id", "Descripcion", detallesPedidosEntitys.ComidaId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", detallesPedidosEntitys.PedidoId);
            return View(detallesPedidosEntitys);
        }

        // GET: DetallesPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesPedidosEntitys = await _context.DetallesPedidos.FindAsync(id);
            if (detallesPedidosEntitys == null)
            {
                return NotFound();
            }
            ViewData["ComidaId"] = new SelectList(_context.Comidas, "Id", "Descripcion", detallesPedidosEntitys.ComidaId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", detallesPedidosEntitys.PedidoId);
            return View(detallesPedidosEntitys);
        }

        // POST: DetallesPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PedidoId,ComidaId")] DetallesPedidosEntitys detallesPedidosEntitys)
        {
            if (id != detallesPedidosEntitys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesPedidosEntitys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesPedidosEntitysExists(detallesPedidosEntitys.Id))
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
            ViewData["ComidaId"] = new SelectList(_context.Comidas, "Id", "Descripcion", detallesPedidosEntitys.ComidaId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", detallesPedidosEntitys.PedidoId);
            return View(detallesPedidosEntitys);
        }

        // GET: DetallesPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesPedidosEntitys = await _context.DetallesPedidos
                .Include(d => d.Comida)
                .Include(d => d.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detallesPedidosEntitys == null)
            {
                return NotFound();
            }

            return View(detallesPedidosEntitys);
        }

        // POST: DetallesPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallesPedidosEntitys = await _context.DetallesPedidos.FindAsync(id);
            if (detallesPedidosEntitys != null)
            {
                _context.DetallesPedidos.Remove(detallesPedidosEntitys);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesPedidosEntitysExists(int id)
        {
            return _context.DetallesPedidos.Any(e => e.Id == id);
        }
    }
}
