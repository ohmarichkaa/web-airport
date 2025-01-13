using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportProj.Models;

public partial class Ticket
{
    public int TicketId { get; set; }
    public string TicketNum { get; set; } = null!;

    public int FlightId { get; set; }
    [ForeignKey("FlightId")]
    public Flight? Flight { get; set; }

    public int PassengerId { get; set; }
    [ForeignKey("PassengerId")]
    public Passenger? Passenger { get; set; }

    public string Class { get; set; } = null!;

    public DateOnly? DateOfPurch { get; set; }


}
