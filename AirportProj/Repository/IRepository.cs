using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportProj.Models;


namespace AirportProj.Repository
{
    public interface IRepository
    {
        
        IEnumerable<Service> GetServices();

        IEnumerable<Flight> GetFlights();
    }
}
