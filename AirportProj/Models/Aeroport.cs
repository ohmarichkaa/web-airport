using System;
using System.Collections.Generic;

namespace AirportProj.Models;

public partial class Aeroport
{
    public int AeroportId { get; set; }

    public string? City { get; set; } = null!;

    public string? Name { get; set; } = null!;

    public string? Country { get; set; } = null!;

    public string? IataCode { get; set; } = null!;

    public string? IcaoCode { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}
