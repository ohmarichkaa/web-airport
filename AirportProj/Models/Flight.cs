using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportProj.Models;

public partial class Flight
{
    [Display(Name = "Код рейсу")]
    public int FlightId { get; set; }
    [Display(Name = "Номер рейсу")]
    public string FlightNumber { get; set; } = null!;

    [Display(Name = "Дата відправлення")]
    public DateOnly DepartureDate { get; set; }

    [Display(Name = "Час відправлення")]
    public TimeOnly DepartureTime { get; set; }

    [Display(Name = "Дата прибуття")]
    public DateOnly ArrivalDate { get; set; }

    [Display(Name = "Час прибуття")]
    public TimeOnly ArrivalTime { get; set; }

    [Display(Name = "Призначення")]
    public string Destination { get; set; } = null!;

    [Display(Name = "Код аеропорту")]
    public int AeroportId { get; set; }
    [ForeignKey("AeroportId")]

    [Display(Name = "Аеропорт")]
    public Aeroport Aeroport { get; set; } = null!;
    [Display(Name = "Статус рейсу")]
    public string Status { get; set; } = null!;
    [Display(Name = "Ціна в економ-класі")]
    public decimal? EconomPrice { get; set; }
    [Display(Name = "Ціна в  першому класі")]
    public decimal? FirstPrice { get; set; }
    [Display(Name = "Ціна в бізнес-класі")]
    public decimal? BizPrice { get; set; }
    [Display(Name = "Код авіалінії")]
    public int AirlineId { get; set; }
    [ForeignKey("AirlineId")]

    [Display(Name = "Авіакомпанія")]
    public Airline Airline { get; set; } = null!;
    [Display(Name = "Код виходу")]
    public int GateId { get; set; }
    [ForeignKey("GateId")]

    [Display(Name = "Вихід до літака")]
    public Gate Gate { get; set; } = null!;
    [Display(Name = "Код літака")]
    public int? PlaneId { get; set; }
    [ForeignKey("PlaneId")]

    [Display(Name = "Літак")]
    public Plane Plane { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
