using System;
using System.Collections.Generic;

namespace AirportProj.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Price { get; set; }
}
