using System;
using System.Collections.Generic;

namespace AirportProj.Models;
public partial class Airline
{
    public int AirlineId { get; set; }

    public string Name { get; set; } = null!;

    public string IataCode { get; set; } = null!;

    public string IcaoCode { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}
