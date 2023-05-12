using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AircraftDataApp.Data;
using AircraftDataApp.Models;
using System.Drawing.Text;

namespace AircraftDataApp.Controllers
{
    public class AircraftController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AircraftController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aircraft
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Aircraft.Include(a => a.AircraftType).Include(a => a.Airline);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Aircraft/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aircraft == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircraft
                .Include(a => a.AircraftType)
                .Include(a => a.Airline)
                .FirstOrDefaultAsync(m => m.IdAircraft == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        // GET: Aircraft/Create
        public IActionResult Create()
        {
            ViewData["FsAircraftType"] = new SelectList(_context.Set<AircraftType>(), "IdAircraftType", "FullType");
            ViewData["FsAirline"] = new SelectList(_context.Set<Airline>(), "IdAirline", "AirlineName");
            return View();
        }

        // POST: Aircraft/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAircraft,Registration,FsAircraftType,FsAirline")] Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aircraft);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FsAircraftType"] = new SelectList(_context.Set<AircraftType>(), "IdAircraftType", "IdAircraftType", aircraft.FsAircraftType);
            ViewData["FsAirline"] = new SelectList(_context.Set<Airline>(), "IdAirline", "IdAirline", aircraft.FsAirline);
            return View(aircraft);
        }

        // GET: Aircraft/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aircraft == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircraft.FindAsync(id);
            if (aircraft == null)
            {
                return NotFound();
            }
            ViewData["FsAircraftType"] = new SelectList(_context.Set<AircraftType>(), "IdAircraftType", "FullType", aircraft.FsAircraftType);
            ViewData["FsAirline"] = new SelectList(_context.Set<Airline>(), "IdAirline", "AirlineName", aircraft.FsAirline);
            return View(aircraft);
        }

        // POST: Aircraft/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAircraft,Registration,FsAircraftType,FsAirline")] Aircraft aircraft)
        {
            if (id != aircraft.IdAircraft)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aircraft);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AircraftExists(aircraft.IdAircraft))
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
            ViewData["FsAircraftType"] = new SelectList(_context.Set<AircraftType>(), "IdAircraftType", "IdAircraftType", aircraft.FsAircraftType);
            ViewData["FsAirline"] = new SelectList(_context.Set<Airline>(), "IdAirline", "IdAirline", aircraft.FsAirline);
            return View(aircraft);
        }

        // GET: Aircraft/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aircraft == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircraft
                .Include(a => a.AircraftType)
                .Include(a => a.Airline)
                .FirstOrDefaultAsync(m => m.IdAircraft == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        // POST: Aircraft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aircraft == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Aircraft'  is null.");
            }
            var aircraft = await _context.Aircraft.FindAsync(id);
            if (aircraft != null)
            {
                _context.Aircraft.Remove(aircraft);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AircraftExists(int id)
        {
          return (_context.Aircraft?.Any(e => e.IdAircraft == id)).GetValueOrDefault();
        }
    }
}
