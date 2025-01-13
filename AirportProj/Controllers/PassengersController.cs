using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirportProj;
using AirportProj.Models;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Sockets;

namespace AirportProj.Controllers
{
    public class PassengersController : Controller
    {
        private readonly AerportContext _context;

        public PassengersController(AerportContext context)
        {
            _context = context;
        }

        // GET: Passengers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Passengers.ToListAsync());
        }

        // GET: Passengers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers
                .FirstOrDefaultAsync(m => m.PassengerId == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // GET: Passengers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassengerId,PassportNum,Surname,Initials,BirthDate,Email")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passenger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passenger);
        }

        // GET: Passengers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }
            return View(passenger);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PassengerId,PassportNum,Surname,Initials,BirthDate,Email")] Passenger passenger)
        {
            if (id != passenger.PassengerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passenger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassengerExists(passenger.PassengerId))
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
            return View(passenger);
        }

        // GET: Passengers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers
                .FirstOrDefaultAsync(m => m.PassengerId == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassengerExists(int id)
        {
            return _context.Passengers.Any(e => e.PassengerId == id);
        }

        // GET: Passengers/Authorize
        public IActionResult Authorize(int flightId, string ticketClass)
        {
            var viewModel = new FlightPassengerViewModel
            {
                Flight = new Flight { FlightId = flightId },
                SelectedTicketClass = ticketClass,
                Passenger = new Passenger()
            };

            return View(viewModel);
        }

        // POST: Passengers/Authorize
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authorize(FlightPassengerViewModel viewModel)
        {
            var existingPassenger = await _context.Passengers
                .FirstOrDefaultAsync(p => p.Email == viewModel.Passenger.Email && p.PassportNum == viewModel.Passenger.PassportNum);
            
            if (existingPassenger != null)
            {
                // Проверка на совпадение всех данных
                if (existingPassenger.Surname == viewModel.Passenger.Surname && existingPassenger.Initials == viewModel.Passenger.Initials &&
                    existingPassenger.BirthDate == viewModel.Passenger.BirthDate)
                {
                    // Все данные совпадают, покупка билета
                    var ticket = new Ticket
                    {
                        FlightId = viewModel.Flight.FlightId,
                        PassengerId = existingPassenger.PassengerId,
                        Class = viewModel.SelectedTicketClass,
                        DateOfPurch = DateOnly.FromDateTime(DateTime.Now),
                         TicketNum = GenerateUniqueTicketNum()
                    };

                    _context.Tickets.Add(ticket);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "\"Пасажир вже зареєстрований, але інші дані не співпадають." });                    
                }
            }
            else
            {
                var newPassenger = new Passenger
                {
                    Email = viewModel.Passenger.Email,
                    PassportNum = viewModel.Passenger.PassportNum,
                    Surname = viewModel.Passenger.Surname,
                    Initials = viewModel.Passenger.Initials,
                    BirthDate = viewModel.Passenger.BirthDate
                };

                _context.Passengers.Add(newPassenger);
                await _context.SaveChangesAsync();

                var ticket = new Ticket
                {
                    FlightId = viewModel.Flight.FlightId,
                    PassengerId = newPassenger.PassengerId,
                    Class = viewModel.SelectedTicketClass,
                    DateOfPurch = DateOnly.FromDateTime(DateTime.Now),
                    TicketNum = GenerateUniqueTicketNum()
                };

                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();

                return RedirectToAction("HomePage", "Home");
            }

        }

        private string GenerateUniqueTicketNum()
        {
            return Guid.NewGuid().ToString();
        }


        // GET: Passengers/AuthorizeForTickets
        public IActionResult Authorize2()
        {
            return View();
        }

        // POST: Passengers/AuthorizeForTickets
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AuthorizeForTickets(Passenger viewModel)
        {
            var passenger = await _context.Passengers
                .FirstOrDefaultAsync(p => p.Email == viewModel.Email && p.PassportNum == viewModel.PassportNum);

            if (passenger == null)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Неправильний email або номер паспорта." });
            }

            return RedirectToAction("MyTickets", new { id = passenger.PassengerId });
        }

        // GET: Passengers/MyTickets/5
        public async Task<IActionResult> MyTickets(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers
                .Include(p => p.Tickets)
                .ThenInclude(t => t.Flight)
                .FirstOrDefaultAsync(m => m.PassengerId == id);

            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // POST: Passengers/ReturnTicket/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReturnTicket(int ticketId, int passengerId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MyTickets", new { id = passengerId });
        }
    }
}
