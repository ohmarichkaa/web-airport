using System;
using System.Collections.Generic;

namespace AirportProj.Models;

public partial class Passenger
{
    public int PassengerId { get; set; }

    public string PassportNum { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Initials { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
