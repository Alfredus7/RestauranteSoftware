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
    public class TiposPedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiposPedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TiposPedidos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposPedidos.ToListAsync());
        }

        // GET: TiposPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposPedidosEntitys = await _context.TiposPedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposPedidosEntitys == null)
            {
                return NotFound();
            }

            return View(tiposPedidosEntitys);
        }

        // GET: TiposPedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TiposPedidosEntitys tiposPedidosEntitys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposPedidosEntitys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposPedidosEntitys);
        }

        // GET: TiposPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposPedidosEntitys = await _context.TiposPedidos.FindAsync(id);
            if (tiposPedidosEntitys == null)
            {
                return NotFound();
            }
            return View(tiposPedidosEntitys);
        }

        // POST: TiposPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TiposPedidosEntitys tiposPedidosEntitys)
        {
            if (id != tiposPedidosEntitys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposPedidosEntitys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposPedidosEntitysExists(tiposPedidosEntitys.Id))
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
            return View(tiposPedidosEntitys);
        }

        // GET: TiposPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposPedidosEntitys = await _context.TiposPedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposPedidosEntitys == null)
            {
                return NotFound();
            }

            return View(tiposPedidosEntitys);
        }

        // POST: TiposPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposPedidosEntitys = await _context.TiposPedidos.FindAsync(id);
            if (tiposPedidosEntitys != null)
            {
                _context.TiposPedidos.Remove(tiposPedidosEntitys);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposPedidosEntitysExists(int id)
        {
            return _context.TiposPedidos.Any(e => e.Id == id);
        }
    }
}
