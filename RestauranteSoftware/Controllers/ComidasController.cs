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
    public class ComidasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComidasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Comidas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Comidas.Include(c => c.TipoPlato);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Comidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comidasEntitys = await _context.Comidas
                .Include(c => c.TipoPlato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comidasEntitys == null)
            {
                return NotFound();
            }

            return View(comidasEntitys);
        }

        // GET: Comidas/Create
        public IActionResult Create()
        {
            ViewData["TipoPlatoId"] = new SelectList(_context.TiposPlatos, "Id", "Nombre");
            return View();
        }

        // POST: Comidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Precio,Descripcion,TipoPlatoId")] ComidasEntitys comidasEntitys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comidasEntitys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoPlatoId"] = new SelectList(_context.TiposPlatos, "Id", "Nombre", comidasEntitys.TipoPlatoId);
            return View(comidasEntitys);
        }

        // GET: Comidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comidasEntitys = await _context.Comidas.FindAsync(id);
            if (comidasEntitys == null)
            {
                return NotFound();
            }
            ViewData["TipoPlatoId"] = new SelectList(_context.TiposPlatos, "Id", "Nombre", comidasEntitys.TipoPlatoId);
            return View(comidasEntitys);
        }

        // POST: Comidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Precio,Descripcion,TipoPlatoId")] ComidasEntitys comidasEntitys)
        {
            if (id != comidasEntitys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comidasEntitys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComidasEntitysExists(comidasEntitys.Id))
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
            ViewData["TipoPlatoId"] = new SelectList(_context.TiposPlatos, "Id", "Nombre", comidasEntitys.TipoPlatoId);
            return View(comidasEntitys);
        }

        // GET: Comidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comidasEntitys = await _context.Comidas
                .Include(c => c.TipoPlato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comidasEntitys == null)
            {
                return NotFound();
            }

            return View(comidasEntitys);
        }

        // POST: Comidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comidasEntitys = await _context.Comidas.FindAsync(id);
            if (comidasEntitys != null)
            {
                _context.Comidas.Remove(comidasEntitys);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComidasEntitysExists(int id)
        {
            return _context.Comidas.Any(e => e.Id == id);
        }
    }
}
