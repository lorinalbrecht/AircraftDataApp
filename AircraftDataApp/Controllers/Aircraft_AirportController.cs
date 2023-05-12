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
    public class Aircraft_AirportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Aircraft_AirportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aircraft_Airport
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Aircraft_Airport.Include(a => a.Aircraft).Include(a => a.Airport);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Aircraft_Airport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aircraft_Airport == null)
            {
                return NotFound();
            }

            var aircraft_Airport = await _context.Aircraft_Airport
                .Include(a => a.Aircraft)
                .Include(a => a.Airport)
                .FirstOrDefaultAsync(m => m.IdAircraftAirport == id);
            if (aircraft_Airport == null)
            {
                return NotFound();
            }

            return View(aircraft_Airport);
        }

        // GET: Aircraft_Airport/Create
        public IActionResult Create()
        {
            ViewData["FsAircraft"] = new SelectList(_context.Aircraft, "IdAircraft", "Registration");
            ViewData["FsAirport"] = new SelectList(_context.Airport, "IdAirport", "FullAirport");
            return View();
        }

        // POST: Aircraft_Airport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAircraftAirport,FsAircraft,FsAirport,DatePosition")] Aircraft_Airport aircraft_Airport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aircraft_Airport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FsAircraft"] = new SelectList(_context.Aircraft, "IdAircraft", "IdAircraft", aircraft_Airport.FsAircraft);
            ViewData["FsAirport"] = new SelectList(_context.Airport, "IdAirport", "IdAirport", aircraft_Airport.FsAirport);
            return View(aircraft_Airport);
        }

        // GET: Aircraft_Airport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aircraft_Airport == null)
            {
                return NotFound();
            }

            var aircraft_Airport = await _context.Aircraft_Airport.FindAsync(id);
            if (aircraft_Airport == null)
            {
                return NotFound();
            }
            ViewData["FsAircraft"] = new SelectList(_context.Aircraft, "IdAircraft", "Registration", aircraft_Airport.FsAircraft);
            ViewData["FsAirport"] = new SelectList(_context.Airport, "IdAirport", "FullAirport", aircraft_Airport.FsAirport);
            return View(aircraft_Airport);
        }

        // POST: Aircraft_Airport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAircraftAirport,FsAircraft,FsAirport,DatePosition")] Aircraft_Airport aircraft_Airport)
        {
            if (id != aircraft_Airport.IdAircraftAirport)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aircraft_Airport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Aircraft_AirportExists(aircraft_Airport.IdAircraftAirport))
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
            ViewData["FsAircraft"] = new SelectList(_context.Aircraft, "IdAircraft", "IdAircraft", aircraft_Airport.FsAircraft);
            ViewData["FsAirport"] = new SelectList(_context.Airport, "IdAirport", "IdAirport", aircraft_Airport.FsAirport);
            return View(aircraft_Airport);
        }

        // GET: Aircraft_Airport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aircraft_Airport == null)
            {
                return NotFound();
            }

            var aircraft_Airport = await _context.Aircraft_Airport
                .Include(a => a.Aircraft)
                .Include(a => a.Airport)
                .FirstOrDefaultAsync(m => m.IdAircraftAirport == id);
            if (aircraft_Airport == null)
            {
                return NotFound();
            }

            return View(aircraft_Airport);
        }

        // POST: Aircraft_Airport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aircraft_Airport == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Aircraft_Airport'  is null.");
            }
            var aircraft_Airport = await _context.Aircraft_Airport.FindAsync(id);
            if (aircraft_Airport != null)
            {
                _context.Aircraft_Airport.Remove(aircraft_Airport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Aircraft_AirportExists(int id)
        {
          return (_context.Aircraft_Airport?.Any(e => e.IdAircraftAirport == id)).GetValueOrDefault();
        }
    }
}
