using AirportProj.Models;
using AirportProj.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace AirportProj.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        private readonly AerportContext _context;

        public HomeController(AerportContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> HomePage(string keyword, DateOnly? date, string type)
        {
            IQueryable<Flight> query = _context.Flights.Include(f => f.Aeroport).Include(f => f.Airline).Include(f => f.Gate).Include(f => f.Plane);

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(f => f.Aeroport.Country.Contains(keyword) || f.Aeroport.City.Contains(keyword) || f.Aeroport.IcaoCode.Contains(keyword) || f.Aeroport.IataCode.Contains(keyword) || f.Aeroport.Name.Contains(keyword));
            }

            if (date != null)
            {
                if (type == "відправлення")
                {
                    query = query.Where(f => f.DepartureDate == date.Value);
                    query = query.Where(f => f.Destination == type);
                }
                else if (type == "прибуття")
                {
                    query = query.Where(f => f.ArrivalDate == date.Value);
                    query = query.Where(f => f.Destination == type);
                }
            }

            var flights = await query.ToListAsync();

            //return View("HomePage", result);

            //var flights = await _context.Flights.Include(f => f.Aeroport).Include(f => f.Airline).Include(f => f.Gate).Include(f => f.Plane).ToListAsync();
            var services = await _context.Services.ToListAsync();

            var viewModel = new HomePageViewModel
            {
                Flights = flights,
                Services = services
            };

            return View(viewModel);
        }
        public IActionResult Error(string errorMessage)
        {
            var errorViewModel = new ErrorViewModel
            {
                RequestId = errorMessage
            };
            return View(errorViewModel);
        }

    }

    

    public class HomePageViewModel
    {
        public IEnumerable<Service>? Services { get; set; }
        public IEnumerable<Flight>? Flights { get; set; }
    }
}

