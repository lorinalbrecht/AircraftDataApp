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
    public class AircraftTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AircraftTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AircraftType
        public async Task<IActionResult> Index()
        {
              return _context.AircraftType != null ? 
                          View(await _context.AircraftType.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AircraftType'  is null.");
        }

        // GET: AircraftType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AircraftType == null)
            {
                return NotFound();
            }

            var aircraftType = await _context.AircraftType
                .FirstOrDefaultAsync(m => m.IdAircraftType == id);
            if (aircraftType == null)
            {
                return NotFound();
            }

            return View(aircraftType);
        }

        // GET: AircraftType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AircraftType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAircraftType,TypeName,Manufacturer,MaxWeight,Range")] AircraftType aircraftType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aircraftType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aircraftType);
        }

        // GET: AircraftType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AircraftType == null)
            {
                return NotFound();
            }

            var aircraftType = await _context.AircraftType.FindAsync(id);
            if (aircraftType == null)
            {
                return NotFound();
            }
            return View(aircraftType);
        }

        // POST: AircraftType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAircraftType,TypeName,Manufacturer,MaxWeight,Range")] AircraftType aircraftType)
        {
            if (id != aircraftType.IdAircraftType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aircraftType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AircraftTypeExists(aircraftType.IdAircraftType))
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
            return View(aircraftType);
        }

        // GET: AircraftType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AircraftType == null)
            {
                return NotFound();
            }

            var aircraftType = await _context.AircraftType
                .FirstOrDefaultAsync(m => m.IdAircraftType == id);
            if (aircraftType == null)
            {
                return NotFound();
            }

            return View(aircraftType);
        }

        // POST: AircraftType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AircraftType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AircraftType'  is null.");
            }
            var aircraftType = await _context.AircraftType.FindAsync(id);
            if (aircraftType != null)
            {
                _context.AircraftType.Remove(aircraftType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AircraftTypeExists(int id)
        {
          return (_context.AircraftType?.Any(e => e.IdAircraftType == id)).GetValueOrDefault();
        }
    }
}
