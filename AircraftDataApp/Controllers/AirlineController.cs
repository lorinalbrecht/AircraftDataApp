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
    public class AirlineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AirlineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Airline
        public async Task<IActionResult> Index()
        {
              return _context.Airline != null ? 
                          View(await _context.Airline.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Airline'  is null.");
        }

        // GET: Airline/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Airline == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline
                .FirstOrDefaultAsync(m => m.IdAirline == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // GET: Airline/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airline/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAirline,AirlineName,Country")] Airline airline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airline);
        }

        // GET: Airline/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Airline == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline.FindAsync(id);
            if (airline == null)
            {
                return NotFound();
            }
            return View(airline);
        }

        // POST: Airline/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAirline,AirlineName,Country")] Airline airline)
        {
            if (id != airline.IdAirline)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirlineExists(airline.IdAirline))
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
            return View(airline);
        }

        // GET: Airline/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Airline == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline
                .FirstOrDefaultAsync(m => m.IdAirline == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // POST: Airline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Airline == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Airline'  is null.");
            }
            var airline = await _context.Airline.FindAsync(id);
            if (airline != null)
            {
                _context.Airline.Remove(airline);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirlineExists(int id)
        {
          return (_context.Airline?.Any(e => e.IdAirline == id)).GetValueOrDefault();
        }
    }
}
