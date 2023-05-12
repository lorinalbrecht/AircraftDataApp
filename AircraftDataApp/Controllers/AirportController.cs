using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AircraftDataApp.Data;
using AircraftDataApp.Models;

namespace AircraftDataApp.Controllers
{
    public class AirportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AirportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Airport
        public async Task<IActionResult> Index()
        {
              return _context.Airport != null ? 
                          View(await _context.Airport.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Airport'  is null.");
        }

        // GET: Airport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Airport == null)
            {
                return NotFound();
            }

            var airport = await _context.Airport
                .FirstOrDefaultAsync(m => m.IdAirport == id);
            if (airport == null)
            {
                return NotFound();
            }

            return View(airport);
        }

        // GET: Airport/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAirport,AirportName,AirportCodeShort,AirportCodeLong,Location,Country")] Airport airport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airport);
        }

        // GET: Airport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Airport == null)
            {
                return NotFound();
            }

            var airport = await _context.Airport.FindAsync(id);
            if (airport == null)
            {
                return NotFound();
            }
            return View(airport);
        }

        // POST: Airport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAirport,AirportName,AirportCodeShort,AirportCodeLong,Location,Country")] Airport airport)
        {
            if (id != airport.IdAirport)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirportExists(airport.IdAirport))
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
            return View(airport);
        }

        // GET: Airport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Airport == null)
            {
                return NotFound();
            }

            var airport = await _context.Airport
                .FirstOrDefaultAsync(m => m.IdAirport == id);
            if (airport == null)
            {
                return NotFound();
            }

            return View(airport);
        }

        // POST: Airport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Airport == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Airport'  is null.");
            }
            var airport = await _context.Airport.FindAsync(id);
            if (airport != null)
            {
                _context.Airport.Remove(airport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirportExists(int id)
        {
          return (_context.Airport?.Any(e => e.IdAirport == id)).GetValueOrDefault();
        }
    }
}
