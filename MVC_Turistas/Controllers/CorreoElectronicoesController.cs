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
    public class CorreoElectronicoesController : Controller
    {
        private readonly ModelContext _context;

        public CorreoElectronicoesController(ModelContext context)
        {
            _context = context;
        }

        // GET: CorreoElectronicoes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.CorreoElectronicos.Include(c => c.CodigoTuristaNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: CorreoElectronicoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correoElectronico = await _context.CorreoElectronicos
                .Include(c => c.CodigoTuristaNavigation)
                .FirstOrDefaultAsync(m => m.CorreoElectronico1 == id);
            if (correoElectronico == null)
            {
                return NotFound();
            }

            return View(correoElectronico);
        }

        // GET: CorreoElectronicoes/Create
        public IActionResult Create()
        {
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista");
            return View();
        }

        // POST: CorreoElectronicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CorreoElectronico1,CodigoTurista")] CorreoElectronico correoElectronico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(correoElectronico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista", correoElectronico.CodigoTurista);
            return View(correoElectronico);
        }

        // GET: CorreoElectronicoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correoElectronico = await _context.CorreoElectronicos.FindAsync(id);
            if (correoElectronico == null)
            {
                return NotFound();
            }
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista", correoElectronico.CodigoTurista);
            return View(correoElectronico);
        }

        // POST: CorreoElectronicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CorreoElectronico1,CodigoTurista")] CorreoElectronico correoElectronico)
        {
            if (id != correoElectronico.CorreoElectronico1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(correoElectronico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorreoElectronicoExists(correoElectronico.CorreoElectronico1))
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
            ViewData["CodigoTurista"] = new SelectList(_context.Turista, "CodigoTurista", "CodigoTurista", correoElectronico.CodigoTurista);
            return View(correoElectronico);
        }

        // GET: CorreoElectronicoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correoElectronico = await _context.CorreoElectronicos
                .Include(c => c.CodigoTuristaNavigation)
                .FirstOrDefaultAsync(m => m.CorreoElectronico1 == id);
            if (correoElectronico == null)
            {
                return NotFound();
            }

            return View(correoElectronico);
        }

        // POST: CorreoElectronicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var correoElectronico = await _context.CorreoElectronicos.FindAsync(id);
            if (correoElectronico != null)
            {
                _context.CorreoElectronicos.Remove(correoElectronico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorreoElectronicoExists(string id)
        {
            return _context.CorreoElectronicos.Any(e => e.CorreoElectronico1 == id);
        }
    }
}
