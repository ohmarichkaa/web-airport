using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirportProj;
using AirportProj.Models;

namespace AirportProj.Controllers
{
    public class AeroportsController : Controller
    {
        private readonly AerportContext _context;

        public AeroportsController(AerportContext context)
        {
            _context = context;
        }

        // GET: Aeroports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aeroports.ToListAsync());
        }

        // GET: Aeroports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroport = await _context.Aeroports
                .FirstOrDefaultAsync(m => m.AeroportId == id);
            if (aeroport == null)
            {
                return NotFound();
            }

            return View(aeroport);
        }

        // GET: Aeroports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aeroports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AeroportId,City,Name,Country,IataCode,IcaoCode")] Aeroport aeroport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aeroport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aeroport);
        }

        // GET: Aeroports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroport = await _context.Aeroports.FindAsync(id);
            if (aeroport == null)
            {
                return NotFound();
            }
            return View(aeroport);
        }

        // POST: Aeroports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AeroportId,City,Name,Country,IataCode,IcaoCode")] Aeroport aeroport)
        {
            if (id != aeroport.AeroportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aeroport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeroportExists(aeroport.AeroportId))
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
            return View(aeroport);
        }

        // GET: Aeroports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroport = await _context.Aeroports
                .FirstOrDefaultAsync(m => m.AeroportId == id);
            if (aeroport == null)
            {
                return NotFound();
            }

            return View(aeroport);
        }

        // POST: Aeroports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aeroport = await _context.Aeroports.FindAsync(id);
            if (aeroport != null)
            {
                _context.Aeroports.Remove(aeroport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AeroportExists(int id)
        {
            return _context.Aeroports.Any(e => e.AeroportId == id);
        }
    }
}
