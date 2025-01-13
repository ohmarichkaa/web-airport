using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportProj.Models;

public partial class Gate
{
    public int GateId { get; set; }
    public int? TerminalId { get; set; }
    [ForeignKey("TerminalId")]

    [Display(Name = "Термінал")]
    public Terminal Terminal { get; set; }

    public string GateNum { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

}
