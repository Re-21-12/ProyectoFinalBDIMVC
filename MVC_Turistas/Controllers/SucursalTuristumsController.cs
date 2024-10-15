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
    public class SucursalTuristumsController : Controller
    {
        private readonly ModelContext _context;

        public SucursalTuristumsController(ModelContext context)
        {
            _context = context;
        }

        // GET: SucursalTuristums
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.SucursalTurista.Include(s => s.CodigoSucursalNavigation).Include(s => s.CodigoTuristaNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: SucursalTuristums/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursalTuristum = await _context.SucursalTurista
                .Include(s => s.CodigoSucursalNavigation)
                .Include(s => s.CodigoTuristaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoSucursalTurista == id);
            if (sucursalTuristum == null)
            {
                return NotFound();
            }

            return View(sucursalTuristum);
        }

        // GET: SucursalTuristums/Create
        public IActionResult Create()
        {
            ViewData["CodigoSucursal"] = new SelectList(_context.Sucursals, "CodigoSucursal", "CodigoSucursal");
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista");
            return View();
        }

        // POST: SucursalTuristums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoSucursalTurista,CodigoSucursal,CodigoTurista")] SucursalTuristum sucursalTuristum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucursalTuristum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoSucursal"] = new SelectList(_context.Sucursals, "CodigoSucursal", "CodigoSucursal", sucursalTuristum.CodigoSucursal);
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista", sucursalTuristum.CodigoTurista);
            return View(sucursalTuristum);
        }

        // GET: SucursalTuristums/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursalTuristum = await _context.SucursalTurista.FindAsync(id);
            if (sucursalTuristum == null)
            {
                return NotFound();
            }
            ViewData["CodigoSucursal"] = new SelectList(_context.Sucursals, "CodigoSucursal", "CodigoSucursal", sucursalTuristum.CodigoSucursal);
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista", sucursalTuristum.CodigoTurista);
            return View(sucursalTuristum);
        }

        // POST: SucursalTuristums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CodigoSucursalTurista,CodigoSucursal,CodigoTurista")] SucursalTuristum sucursalTuristum)
        {
            if (id != sucursalTuristum.CodigoSucursalTurista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursalTuristum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalTuristumExists(sucursalTuristum.CodigoSucursalTurista))
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
            ViewData["CodigoSucursal"] = new SelectList(_context.Sucursals, "CodigoSucursal", "CodigoSucursal", sucursalTuristum.CodigoSucursal);
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista", sucursalTuristum.CodigoTurista);
            return View(sucursalTuristum);
        }

        // GET: SucursalTuristums/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursalTuristum = await _context.SucursalTurista
                .Include(s => s.CodigoSucursalNavigation)
                .Include(s => s.CodigoTuristaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoSucursalTurista == id);
            if (sucursalTuristum == null)
            {
                return NotFound();
            }

            return View(sucursalTuristum);
        }

        // POST: SucursalTuristums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var sucursalTuristum = await _context.SucursalTurista.FindAsync(id);
            if (sucursalTuristum != null)
            {
                _context.SucursalTurista.Remove(sucursalTuristum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalTuristumExists(decimal id)
        {
            return _context.SucursalTurista.Any(e => e.CodigoSucursalTurista == id);
        }
    }
}
