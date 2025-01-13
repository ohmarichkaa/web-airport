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
    public class FlightsController : Controller
    {
        private readonly AerportContext _context;

        public FlightsController(AerportContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            var aerportContext = _context.Flights.Include(f => f.Aeroport).Include(f => f.Airline).Include(f => f.Gate).Include(f => f.Plane);
            return View(await aerportContext.ToListAsync());
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.Aeroport)
                .Include(f => f.Airline)
                .Include(f => f.Gate)
                .Include(f => f.Plane)
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }


        // GET: Flights/Details/5
        public async Task<IActionResult> Look(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.Aeroport)
                .Include(f => f.Airline)
                .Include(f => f.Gate).ThenInclude(g => g.Terminal)
                .Include(f => f.Plane)
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            ViewData["AeroportId"] = new SelectList(_context.Aeroports, "AeroportId", "AeroportId");
            ViewData["AirlineId"] = new SelectList(_context.Airlines, "AirlineId", "AirlineId");
            ViewData["GateId"] = new SelectList(_context.Gates, "GateId", "GateId");
            ViewData["PlaneId"] = new SelectList(_context.Planes, "PlaneId", "PlaneId");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,FlightNumber,DepartureDate,DepartureTime,ArrivalDate,ArrivalTime,Destination,AeroportId,Status,EconomPrice,FirstPrice,BizPrice,AirlineId,GateId,PlaneId")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AeroportId"] = new SelectList(_context.Aeroports, "AeroportId", "AeroportId", flight.AeroportId);
            ViewData["AirlineId"] = new SelectList(_context.Airlines, "AirlineId", "AirlineId", flight.AirlineId);
            ViewData["GateId"] = new SelectList(_context.Gates, "GateId", "GateId", flight.GateId);
            ViewData["PlaneId"] = new SelectList(_context.Planes, "PlaneId", "PlaneId", flight.PlaneId);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            ViewData["AeroportId"] = new SelectList(_context.Aeroports, "AeroportId", "AeroportId", flight.AeroportId);
            ViewData["AirlineId"] = new SelectList(_context.Airlines, "AirlineId", "AirlineId", flight.AirlineId);
            ViewData["GateId"] = new SelectList(_context.Gates, "GateId", "GateId", flight.GateId);
            ViewData["PlaneId"] = new SelectList(_context.Planes, "PlaneId", "PlaneId", flight.PlaneId);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightId,FlightNumber,DepartureDate,DepartureTime,ArrivalDate,ArrivalTime,Destination,AeroportId,Status,EconomPrice,FirstPrice,BizPrice,AirlineId,GateId,PlaneId")] Flight flight)
        {
            if (id != flight.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightId))
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
            ViewData["AeroportId"] = new SelectList(_context.Aeroports, "AeroportId", "AeroportId", flight.AeroportId);
            ViewData["AirlineId"] = new SelectList(_context.Airlines, "AirlineId", "AirlineId", flight.AirlineId);
            ViewData["GateId"] = new SelectList(_context.Gates, "GateId", "GateId", flight.GateId);
            ViewData["PlaneId"] = new SelectList(_context.Planes, "PlaneId", "PlaneId", flight.PlaneId);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.Aeroport)
                .Include(f => f.Airline)
                .Include(f => f.Gate)
                .Include(f => f.Plane)
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.FlightId == id);
        }

        [HttpPost]
        public async Task<IActionResult> PurchaseTicket(int flightId, string selectedTicketClass)
        {
            Console.WriteLine($"PurchaseTicket called with flightId: {flightId}, selectedTicketClass: {selectedTicketClass}");

            var flight = await _context.Flights
                .Include(f => f.Tickets)
                .Include(f => f.Plane)
                .FirstOrDefaultAsync(f => f.FlightId == flightId);

            if (flight == null)
            {
                return NotFound();
            }

            bool seatsAvailable = false;

            switch (selectedTicketClass)
            {
                case "Econom":
                    seatsAvailable = flight.Tickets.Count(t => t.Class == "Економ-клас") < flight.Plane.EconomyClass;
                    break;
                case "First":
                    seatsAvailable = flight.Tickets.Count(t => t.Class == "Перший клас") < flight.Plane.FirstClass;
                    break;
                case "Business":
                    seatsAvailable = flight.Tickets.Count(t => t.Class == "Бізнес-клас") < flight.Plane.BusinessClass;
                    break;
            }

            var viewModel = new FlightPassengerViewModel
            {
                Flight = flight,
                SelectedTicketClass = selectedTicketClass,
                Passenger = new Passenger()
            };
          
            if (seatsAvailable)
            {
                return RedirectToAction("Authorize", "Passengers", new { flightId = flightId, ticketClass = selectedTicketClass });
            }
            else
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Немає доступних місць у вибраному класі" });               
            }
        }
        
    }
}