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
    public class HotelTuristumsController : Controller
    {
        private readonly ModelContext _context;

        public HotelTuristumsController(ModelContext context)
        {
            _context = context;
        }

        // GET: HotelTuristums
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.HotelTurista.Include(h => h.CodigoHotelNavigation).Include(h => h.CodigoTuristaNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: HotelTuristums/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelTuristum = await _context.HotelTurista
                .Include(h => h.CodigoHotelNavigation)
                .Include(h => h.CodigoTuristaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoHotelTurista == id);
            if (hotelTuristum == null)
            {
                return NotFound();
            }

            return View(hotelTuristum);
        }

        // GET: HotelTuristums/Create
        public IActionResult Create()
        {
            ViewData["CodigoHotel"] = new SelectList(_context.Hotels, "CodigoHotel", "CodigoHotel");
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista");
            return View();
        }

        // POST: HotelTuristums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoHotelTurista,CodigoHotel,CodigoTurista,Regimen,FechaLlegada,FechaPartida")] HotelTuristum hotelTuristum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelTuristum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoHotel"] = new SelectList(_context.Hotels, "CodigoHotel", "CodigoHotel", hotelTuristum.CodigoHotel);
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista", hotelTuristum.CodigoTurista);
            return View(hotelTuristum);
        }

        // GET: HotelTuristums/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelTuristum = await _context.HotelTurista.FindAsync(id);
            if (hotelTuristum == null)
            {
                return NotFound();
            }
            ViewData["CodigoHotel"] = new SelectList(_context.Hotels, "CodigoHotel", "CodigoHotel", hotelTuristum.CodigoHotel);
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista", hotelTuristum.CodigoTurista);
            return View(hotelTuristum);
        }

        // POST: HotelTuristums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CodigoHotelTurista,CodigoHotel,CodigoTurista,Regimen,FechaLlegada,FechaPartida")] HotelTuristum hotelTuristum)
        {
            if (id != hotelTuristum.CodigoHotelTurista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelTuristum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelTuristumExists(hotelTuristum.CodigoHotelTurista))
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
            ViewData["CodigoHotel"] = new SelectList(_context.Hotels, "CodigoHotel", "CodigoHotel", hotelTuristum.CodigoHotel);
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista", hotelTuristum.CodigoTurista);
            return View(hotelTuristum);
        }

        // GET: HotelTuristums/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelTuristum = await _context.HotelTurista
                .Include(h => h.CodigoHotelNavigation)
                .Include(h => h.CodigoTuristaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoHotelTurista == id);
            if (hotelTuristum == null)
            {
                return NotFound();
            }

            return View(hotelTuristum);
        }

        // POST: HotelTuristums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var hotelTuristum = await _context.HotelTurista.FindAsync(id);
            if (hotelTuristum != null)
            {
                _context.HotelTurista.Remove(hotelTuristum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelTuristumExists(decimal id)
        {
            return _context.HotelTurista.Any(e => e.CodigoHotelTurista == id);
        }
    }
}
