using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportProj.Models;

namespace AirportProj.Repository
{
    public class MyRepository : IRepository
    {
        private AerportContext context;
        public MyRepository(AerportContext _context)
        {
            context = _context;
        }
        
        public IEnumerable<Service> GetServices()
        {
            return context.Services;
        }

        public IEnumerable<Flight> GetFlights()
        {
            return context.Flights;
        }

    }
}
