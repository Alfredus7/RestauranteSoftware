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
    public class EstadosPedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstadosPedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EstadosPedidos
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadosPedidos.ToListAsync());
        }

        // GET: EstadosPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadosPedidosEntitys = await _context.EstadosPedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadosPedidosEntitys == null)
            {
                return NotFound();
            }

            return View(estadosPedidosEntitys);
        }

        // GET: EstadosPedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadosPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] EstadosPedidosEntitys estadosPedidosEntitys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadosPedidosEntitys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosPedidosEntitys);
        }

        // GET: EstadosPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadosPedidosEntitys = await _context.EstadosPedidos.FindAsync(id);
            if (estadosPedidosEntitys == null)
            {
                return NotFound();
            }
            return View(estadosPedidosEntitys);
        }

        // POST: EstadosPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] EstadosPedidosEntitys estadosPedidosEntitys)
        {
            if (id != estadosPedidosEntitys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadosPedidosEntitys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadosPedidosEntitysExists(estadosPedidosEntitys.Id))
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
            return View(estadosPedidosEntitys);
        }

        // GET: EstadosPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadosPedidosEntitys = await _context.EstadosPedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadosPedidosEntitys == null)
            {
                return NotFound();
            }

            return View(estadosPedidosEntitys);
        }

        // POST: EstadosPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadosPedidosEntitys = await _context.EstadosPedidos.FindAsync(id);
            if (estadosPedidosEntitys != null)
            {
                _context.EstadosPedidos.Remove(estadosPedidosEntitys);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadosPedidosEntitysExists(int id)
        {
            return _context.EstadosPedidos.Any(e => e.Id == id);
        }
    }
}
