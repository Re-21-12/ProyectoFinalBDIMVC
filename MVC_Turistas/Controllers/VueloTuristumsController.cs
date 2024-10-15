using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Turistas.Models;

namespace MVC_Turistas.Controllers
{
    public class VueloTuristumsController : Controller
    {
        private readonly ModelContext _context;

        public VueloTuristumsController(ModelContext context)
        {
            _context = context;
        }

        // GET: VueloTuristums
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.VueloTurista.Include(v => v.CodigoTuristaNavigation).Include(v => v.NumeroVueloNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: VueloTuristums/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueloTuristum = await _context.VueloTurista
                .Include(v => v.CodigoTuristaNavigation)
                .Include(v => v.NumeroVueloNavigation)
                .FirstOrDefaultAsync(m => m.NumeroVueloTurista == id);
            if (vueloTuristum == null)
            {
                return NotFound();
            }

            return View(vueloTuristum);
        }

        // GET: VueloTuristums/Create
        public IActionResult Create()
        {
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista");
            ViewData["NumeroVuelo"] = new SelectList(_context.Vuelos, "NumeroVuelo", "NumeroVuelo");
            return View();
        }

        // POST: VueloTuristums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroVueloTurista,Clase,NumeroVuelo,CodigoTurista")] VueloTuristum vueloTuristum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vueloTuristum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista", vueloTuristum.CodigoTurista);
            ViewData["NumeroVuelo"] = new SelectList(_context.Vuelos, "NumeroVuelo", "NumeroVuelo", vueloTuristum.NumeroVuelo);
            return View(vueloTuristum);
        }

        // GET: VueloTuristums/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueloTuristum = await _context.VueloTurista.FindAsync(id);
            if (vueloTuristum == null)
            {
                return NotFound();
            }
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista", vueloTuristum.CodigoTurista);
            ViewData["NumeroVuelo"] = new SelectList(_context.Vuelos, "NumeroVuelo", "NumeroVuelo", vueloTuristum.NumeroVuelo);
            return View(vueloTuristum);
        }

        // POST: VueloTuristums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("NumeroVueloTurista,Clase,NumeroVuelo,CodigoTurista")] VueloTuristum vueloTuristum)
        {
            if (id != vueloTuristum.NumeroVueloTurista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vueloTuristum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VueloTuristumExists(vueloTuristum.NumeroVueloTurista))
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
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista", vueloTuristum.CodigoTurista);
            ViewData["NumeroVuelo"] = new SelectList(_context.Vuelos, "NumeroVuelo", "NumeroVuelo", vueloTuristum.NumeroVuelo);
            return View(vueloTuristum);
        }

        // GET: VueloTuristums/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueloTuristum = await _context.VueloTurista
                .Include(v => v.CodigoTuristaNavigation)
                .Include(v => v.NumeroVueloNavigation)
                .FirstOrDefaultAsync(m => m.NumeroVueloTurista == id);
            if (vueloTuristum == null)
            {
                return NotFound();
            }

            return View(vueloTuristum);
        }

        // POST: VueloTuristums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var vueloTuristum = await _context.VueloTurista.FindAsync(id);
            if (vueloTuristum != null)
            {
                _context.VueloTurista.Remove(vueloTuristum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VueloTuristumExists(decimal id)
        {
            return _context.VueloTurista.Any(e => e.NumeroVueloTurista == id);
        }
    }
}
