using System;
using System.Collections.Generic;

namespace AirportProj.Models;

public partial class Plane
{
    public int PlaneId { get; set; }

    public int MaxDistance { get; set; }

    public int Speed { get; set; }

    public int FirstClass { get; set; }

    public int BusinessClass { get; set; }

    public int EconomyClass { get; set; }

    public string SerialNum { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

}
