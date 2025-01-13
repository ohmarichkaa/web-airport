using System;
using System.Collections.Generic;

namespace AirportProj.Models;

public partial class Terminal
{
    public int TerminalId { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<Gate> Gates { get; set; } = new List<Gate>();
}
