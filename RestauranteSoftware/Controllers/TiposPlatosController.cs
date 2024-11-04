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
    public class TiposPlatosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiposPlatosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TiposPlatos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposPlatos.ToListAsync());
        }

        // GET: TiposPlatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposPlatosEntitys = await _context.TiposPlatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposPlatosEntitys == null)
            {
                return NotFound();
            }

            return View(tiposPlatosEntitys);
        }

        // GET: TiposPlatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposPlatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TiposPlatosEntitys tiposPlatosEntitys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposPlatosEntitys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposPlatosEntitys);
        }

        // GET: TiposPlatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposPlatosEntitys = await _context.TiposPlatos.FindAsync(id);
            if (tiposPlatosEntitys == null)
            {
                return NotFound();
            }
            return View(tiposPlatosEntitys);
        }

        // POST: TiposPlatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TiposPlatosEntitys tiposPlatosEntitys)
        {
            if (id != tiposPlatosEntitys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposPlatosEntitys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposPlatosEntitysExists(tiposPlatosEntitys.Id))
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
            return View(tiposPlatosEntitys);
        }

        // GET: TiposPlatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposPlatosEntitys = await _context.TiposPlatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposPlatosEntitys == null)
            {
                return NotFound();
            }

            return View(tiposPlatosEntitys);
        }

        // POST: TiposPlatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposPlatosEntitys = await _context.TiposPlatos.FindAsync(id);
            if (tiposPlatosEntitys != null)
            {
                _context.TiposPlatos.Remove(tiposPlatosEntitys);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposPlatosEntitysExists(int id)
        {
            return _context.TiposPlatos.Any(e => e.Id == id);
        }
    }
}
