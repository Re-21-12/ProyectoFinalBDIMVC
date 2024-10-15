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
    public class TuristumsController : Controller
    {
        private readonly ModelContext _context;

        public TuristumsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Turistums
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Turista.Include(t => t.CodigoSucursalNavigation).Include(t => t.NumeroVueloNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Turistums/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turistum = await _context.Turista
                .Include(t => t.CodigoSucursalNavigation)
                .Include(t => t.NumeroVueloNavigation)
                .FirstOrDefaultAsync(m => m.CodigoTurista == id);
            if (turistum == null)
            {
                return NotFound();
            }

            return View(turistum);
        }

        // GET: Turistums/Create
        public IActionResult Create()
        {
            ViewData["CodigoSucursal"] = new SelectList(_context.Sucursals, "CodigoSucursal", "CodigoSucursal");
            ViewData["NumeroVuelo"] = new SelectList(_context.Vuelos, "NumeroVuelo", "NumeroVuelo");
            return View();
        }

        // POST: Turistums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoTurista,NombreUno,NombreDos,NombreTres,ApellidoUno,ApellidoDos,Direccion,PaisResidencia,NumeroVuelo,CodigoSucursal")] Turistum turistum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turistum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoSucursal"] = new SelectList(_context.Sucursals, "CodigoSucursal", "CodigoSucursal", turistum.CodigoSucursal);
            ViewData["NumeroVuelo"] = new SelectList(_context.Vuelos, "NumeroVuelo", "NumeroVuelo", turistum.NumeroVuelo);
            return View(turistum);
        }

        // GET: Turistums/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turistum = await _context.Turista.FindAsync(id);
            if (turistum == null)
            {
                return NotFound();
            }
            ViewData["CodigoSucursal"] = new SelectList(_context.Sucursals, "CodigoSucursal", "CodigoSucursal", turistum.CodigoSucursal);
            ViewData["NumeroVuelo"] = new SelectList(_context.Vuelos, "NumeroVuelo", "NumeroVuelo", turistum.NumeroVuelo);
            return View(turistum);
        }

        // POST: Turistums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CodigoTurista,NombreUno,NombreDos,NombreTres,ApellidoUno,ApellidoDos,Direccion,PaisResidencia,NumeroVuelo,CodigoSucursal")] Turistum turistum)
        {
            if (id != turistum.CodigoTurista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turistum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuristumExists(turistum.CodigoTurista))
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
            ViewData["CodigoSucursal"] = new SelectList(_context.Sucursals, "CodigoSucursal", "CodigoSucursal", turistum.CodigoSucursal);
            ViewData["NumeroVuelo"] = new SelectList(_context.Vuelos, "NumeroVuelo", "NumeroVuelo", turistum.NumeroVuelo);
            return View(turistum);
        }

        // GET: Turistums/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turistum = await _context.Turista
                .Include(t => t.CodigoSucursalNavigation)
                .Include(t => t.NumeroVueloNavigation)
                .FirstOrDefaultAsync(m => m.CodigoTurista == id);
            if (turistum == null)
            {
                return NotFound();
            }

            return View(turistum);
        }

        // POST: Turistums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var turistum = await _context.Turista.FindAsync(id);
            if (turistum != null)
            {
                _context.Turista.Remove(turistum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuristumExists(decimal id)
        {
            return _context.Turista.Any(e => e.CodigoTurista == id);
        }
    }
}
