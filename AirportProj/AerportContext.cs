using System;
using System.Collections.Generic;
using System.Numerics;
using AirportProj.Models;

using Microsoft.EntityFrameworkCore;

namespace AirportProj;

public partial class AerportContext : DbContext
{
  
    public AerportContext(DbContextOptions<AerportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Aeroport> Aeroports { get; set; }

    public virtual DbSet<Airline> Airlines { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Gate> Gates { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Models.Plane> Planes { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Terminal> Terminals { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=AirportDB;Integrated Security=True;Connect Timeout=30; TrustServerCertificate =true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Admin>().HasData(
                new { AdminId = 1, Email = "ad@m.in", Password = "admin" });

        

        modelBuilder.Entity<Airline>().HasData(
                new { AirlineId = 1, Name = "American Airlines", IataCode = "AA", IcaoCode = "AAl"},
                new { AirlineId = 2, Name = "Delta Air Lines", IataCode = "DL", IcaoCode = "DAl" },
                new { AirlineId = 3, Name = "United Airlines", IataCode = "UA", IcaoCode = "UAl" },
                new { AirlineId = 4, Name = "Southwest Airlines", IataCode = "WN", IcaoCode = "SWA" });
        modelBuilder.Entity<Airline>()
        .Property(t => t.AirlineId)
        .ValueGeneratedOnAdd();

        modelBuilder.Entity<Aeroport>().HasData(
                new { AeroportId = 1, City = "New York", Name = "John F. Kennedy International Airport", Country = "United States", IataCode = "JFK", IcaoCode = "KJFK" },
               new { AeroportId = 2, City = "Los Angeles", Name = "Los Angeles International Airport", Country = "United States", IataCode = "LAX", IcaoCode = "KLAX" },
               new { AeroportId = 3, City = "London", Name = "Heathrow Airport", Country = "United Kingdom", IataCode = "LHR", IcaoCode = "EGLL" },
               new { AeroportId = 4, City = "Tokyo", Name = "Tokyo Haneda Airport", Country = "Japan", IataCode = "HND", IcaoCode = "RJTT" },
               new { AeroportId = 5, City = "Paris", Name = "Charles de Gaulle Airport", Country = "France", IataCode = "CDG", IcaoCode = "LFPG" },
               new { AeroportId = 6, City = "Dubai", Name = "Dubai International Airport", Country = "United Arab Emirates", IataCode = "DXB", IcaoCode = "OMDB" },
               new { AeroportId = 7, City = "Frankfurt", Name = "Frankfurt Airport", Country = "Germany", IataCode = "FRA", IcaoCode = "EDDF" },
               new { AeroportId = 8, City = "Sydney", Name = "Sydney Kingsford Smith Airport", Country = "Australia", IataCode = "SYD", IcaoCode = "YSSY" });

        modelBuilder.Entity<Aeroport>()
        .Property(t => t.AeroportId)
        .ValueGeneratedOnAdd();

        modelBuilder.Entity<Models.Plane>().HasData(
                new { PlaneId = 1, MaxDistance = 15000, Speed = 900, FirstClass= 14, BusinessClass = 50, EconomyClass = 300, SerialNum = "SN12345A" },
              new { PlaneId = 2, MaxDistance = 13500, Speed = 850, FirstClass = 10, BusinessClass = 40, EconomyClass = 250, SerialNum = "SN12348D" },
              new { PlaneId = 3, MaxDistance = 12000, Speed = 870, FirstClass = 12, BusinessClass = 45, EconomyClass = 380, SerialNum = "SN12350F" });

        modelBuilder.Entity<Models.Plane>()
        .Property(t => t.PlaneId)
        .ValueGeneratedOnAdd();


        modelBuilder.Entity<Passenger>().HasData(
    new { PassengerId = 1, PassportNum = "A12345678", Surname = "Smith", Initials = "J", BirthDate = new DateOnly(1980, 1, 15), Email = "jsmith@example.com" },
    new { PassengerId = 2, PassportNum = "B23456789", Surname = "Johnson", Initials = "M", BirthDate = new DateOnly(1975, 2, 20), Email = "mjohnson@example.com" },
    new { PassengerId = 3, PassportNum = "C34567890", Surname = "Williams", Initials = "L", BirthDate = new DateOnly(1990, 3, 25), Email = "lwilliams@example.com" },
    new { PassengerId = 4, PassportNum = "D45678901", Surname = "Jones", Initials = "S", BirthDate = new DateOnly(1985, 4, 30), Email = "sjones@example.com" },
    new { PassengerId = 5, PassportNum = "E56789012", Surname = "Brown", Initials = "R", BirthDate = new DateOnly(1970, 5, 10), Email = "rbrown@example.com" },
    new { PassengerId = 6, PassportNum = "F67890123", Surname = "Davis", Initials = "K", BirthDate = new DateOnly(1965, 6, 15), Email = "kdavis@example.com" },
    new { PassengerId = 7, PassportNum = "G78901234", Surname = "Miller", Initials = "T", BirthDate = new DateOnly(1995, 7, 20), Email = "tmiller@example.com" },
    new { PassengerId = 8, PassportNum = "H89012345", Surname = "Wilson", Initials = "A", BirthDate = new DateOnly(1982, 8, 25), Email = "awilson@example.com" },
    new { PassengerId = 9, PassportNum = "I90123456", Surname = "Moore", Initials = "C", BirthDate = new DateOnly(1992, 9, 30), Email = "cmoore@example.com" },
    new { PassengerId = 10, PassportNum = "J01234567", Surname = "Taylor", Initials = "E", BirthDate = new DateOnly(1988, 10, 10), Email = "etaylor@example.com" },
    new { PassengerId = 11, PassportNum = "K12345678", Surname = "Anderson", Initials = "B", BirthDate = new DateOnly(1978, 11, 15), Email = "banderson@example.com" },
    new { PassengerId = 12, PassportNum = "L23456789", Surname = "Thomas", Initials = "D", BirthDate = new DateOnly(1998, 12, 20), Email = "dthomas@example.com" },
    new { PassengerId = 13, PassportNum = "M34567890", Surname = "Jackson", Initials = "F", BirthDate = new DateOnly(1983, 1, 25), Email = "fjackson@example.com" },
    new { PassengerId = 14, PassportNum = "N45678901", Surname = "White", Initials = "G", BirthDate = new DateOnly(1993, 2, 28), Email = "gwhite@example.com" },
    new { PassengerId = 15, PassportNum = "O56789012", Surname = "Harris", Initials = "H", BirthDate = new DateOnly(1973, 3, 5), Email = "hharris@example.com" },
    new { PassengerId = 16, PassportNum = "P67890123", Surname = "Martin", Initials = "I", BirthDate = new DateOnly(1968, 4, 10), Email = "imartin@example.com" },
    new { PassengerId = 17, PassportNum = "Q78901234", Surname = "Thompson", Initials = "J", BirthDate = new DateOnly(1997, 5, 15), Email = "jthompson@example.com" },
    new { PassengerId = 18, PassportNum = "R89012345", Surname = "Garcia", Initials = "K", BirthDate = new DateOnly(1987, 6, 20), Email = "kgarcia@example.com" },
    new { PassengerId = 19, PassportNum = "S90123456", Surname = "Martinez", Initials = "L", BirthDate = new DateOnly(1991, 7, 25), Email = "lmartinez@example.com" },
    new { PassengerId = 20, PassportNum = "T01234567", Surname = "Robinson", Initials = "M", BirthDate = new DateOnly(1986, 8, 30), Email = "mrobinson@example.com" },
    new { PassengerId = 21, PassportNum = "U12345678", Surname = "Clark", Initials = "N", BirthDate = new DateOnly(1976, 9, 5), Email = "nclark@example.com" },
    new { PassengerId = 22, PassportNum = "V23456789", Surname = "Rodriguez", Initials = "O", BirthDate = new DateOnly(1996, 10, 10), Email = "orodriguez@example.com" },
    new { PassengerId = 23, PassportNum = "W34567890", Surname = "Lewis", Initials = "P", BirthDate = new DateOnly(1984, 11, 15), Email = "plewis@example.com" }
);
        modelBuilder.Entity<Passenger>()
        .Property(t => t.PassengerId)
        .ValueGeneratedOnAdd();

        modelBuilder.Entity<Terminal>().HasData(
                new { TerminalId = 1, Name = "Terminal 1", Capacity = 5000 },
                new { TerminalId = 2, Name = "Terminal 2", Capacity = 3000 },
                new { TerminalId = 3, Name = "Terminal 3", Capacity = 2200});

        modelBuilder.Entity<Terminal>()
       .Property(t => t.TerminalId)
       .ValueGeneratedOnAdd();

        modelBuilder.Entity<Gate>().HasData(
                new { GateId = 1, TerminalId = 1, GateNum = "A1" },
                new { GateId = 2, TerminalId = 1, GateNum = "A2" },
                new { GateId = 3, TerminalId = 1, GateNum = "A3" },
                new { GateId = 4, TerminalId = 2, GateNum = "B1" },
                new { GateId = 5, TerminalId = 2, GateNum = "B2" },
                new { GateId = 6, TerminalId = 3, GateNum = "C1" },
                new { GateId = 7, TerminalId = 3, GateNum = "C2" });
        modelBuilder.Entity<Gate>()
     .Property(t => t.GateId)
     .ValueGeneratedOnAdd();


        modelBuilder.Entity<Service>().HasData(
                new { ServiceId = 1, Name = "Wi-fi", Description = "Доступ до швидкісного Wi-Fi в Інтернеті в аеропорту", Price = "Безкоштовно"},
                new { ServiceId = 2, Name = "Паркування", Description = "Доступ до паркувальних майданчиків аеропорту для короткострокового або довгострокового паркування", Price = "50 грн./година" },
                new { ServiceId = 3, Name = "Ресторани та магазини", Description = "Широкий вибір магазинів та ресторанів на території аеропорту", Price = "Ціни встановлюють заклади" },
                new { ServiceId = 4, Name = "VIP-зала очікування", Description = "Комфортні зали очікування із усіма зручностями", Price = "200 грн./година"},
                new { ServiceId = 5, Name = "Камери збереження", Description = "Можливість безпечного зберігання для вашого багажу.", Price = "100 грн./доба"},
                new { ServiceId = 6, Name = "Таксі", Description = "Послуги таксі та громадського транспорту", Price = "За тарифами перевізника" });

        modelBuilder.Entity<Service>()
    .Property(t => t.ServiceId)
    .ValueGeneratedOnAdd();


        modelBuilder.Entity<Flight>().HasData(
     new
     {
         FlightId = 1,
         FlightNumber = "AA101",
         DepartureDate = new DateOnly(2024, 07, 01),
         DepartureTime = new TimeOnly(8, 0),
         ArrivalDate = new DateOnly(2024, 07, 01),
         ArrivalTime = new TimeOnly(12, 0),
         Destination = "відправлення",
         AeroportId = 1,
         Status = "Вчасно",
         EconomPrice = 2300.00m,
         FirstPrice = 3800.00m,
         BizPrice = 6500.00m,
         AirlineId = 1,
         GateId = 1,
         PlaneId = 1
     },
     new
     {
         FlightId = 2,
         FlightNumber = "AA102",
         DepartureDate = new DateOnly(2024, 07, 02),
         DepartureTime = new TimeOnly(9, 0),
         ArrivalDate = new DateOnly(2024, 07, 02),
         ArrivalTime = new TimeOnly(13, 0),
         Destination = "прибуття",
         AeroportId = 2,
         Status = "Вчасно",
         EconomPrice = 3320.00m,
         FirstPrice = 4820.00m,
         BizPrice = 7520.00m,
         AirlineId = 1,
         GateId = 2,
         PlaneId = 2
     },
     new
     {
         FlightId = 3,
         FlightNumber = "AA103",
         DepartureDate = new DateOnly(2024, 07, 03),
         DepartureTime = new TimeOnly(10, 0),
         ArrivalDate = new DateOnly(2024, 07, 03),
         ArrivalTime = new TimeOnly(14, 0),
         Destination = "відправлення",
         AeroportId = 3,
         Status = "Затримка",
         EconomPrice = 2340.00m,
         FirstPrice = 5840.00m,
         BizPrice = 8540.00m,
         AirlineId = 1,
         GateId = 3,
         PlaneId = 3
     },
     new
     {
         FlightId = 4,
         FlightNumber = "AA104",
         DepartureDate = new DateOnly(2024, 07, 04),
         DepartureTime = new TimeOnly(11, 0),
         ArrivalDate = new DateOnly(2024, 07, 04),
         ArrivalTime = new TimeOnly(15, 0),
         Destination = "прибуття",
         AeroportId = 4,
         Status = "Вчасно",
         EconomPrice = 3360.00m,
         FirstPrice = 6860.00m,
         BizPrice = 9560.00m,
         AirlineId = 1,
         GateId = 4,
         PlaneId = 2
     },
     new
     {
         FlightId = 5,
         FlightNumber = "AA105",
         DepartureDate = new DateOnly(2024, 07, 05),
         DepartureTime = new TimeOnly(12, 0),
         ArrivalDate = new DateOnly(2024, 07, 05),
         ArrivalTime = new TimeOnly(16, 0),
         Destination = "відправлення",
         AeroportId = 1,
         Status = "Вчасно",
         EconomPrice = 1380.00m,
         FirstPrice = 3880.00m,
         BizPrice = 4580.00m,
         AirlineId = 2,
         GateId = 1,
         PlaneId = 1
     },
     new
     {
         FlightId = 6,
         FlightNumber = "AA107",
         DepartureDate = new DateOnly(2024, 07, 07),
         DepartureTime = new TimeOnly(13, 0),
         ArrivalDate = new DateOnly(2024, 07, 07),
         ArrivalTime = new TimeOnly(17, 0),
         Destination = "прибуття",
         AeroportId = 2,
         Status = "Вчасно",
         EconomPrice = 2400.00m,
         FirstPrice = 3900.00m,
         BizPrice = 5600.00m,
         AirlineId = 2,
         GateId = 2,
         PlaneId = 2
     },
    new
    {
        FlightId = 7,
        FlightNumber = "AA107",
        DepartureDate = new DateOnly(2024, 07, 07),
        DepartureTime = new TimeOnly(14, 0),
        ArrivalDate = new DateOnly(2024, 07, 07),
        ArrivalTime = new TimeOnly(18, 0),
        Destination = "відправлення",
        AeroportId = 3,
        Status = "Затримка",
        EconomPrice = 1420.00m,
        FirstPrice = 2920.00m,
        BizPrice = 4620.00m,
        AirlineId = 2,
        GateId = 3,
        PlaneId = 3
    },
    new
    {
        FlightId = 8,
        FlightNumber = "AA108",
        DepartureDate = new DateOnly(2024, 07, 08),
        DepartureTime = new TimeOnly(15, 0),
        ArrivalDate = new DateOnly(2024, 07, 08),
        ArrivalTime = new TimeOnly(19, 0),
        Destination = "прибуття",
        AeroportId = 4,
        Status = "Вчасно",
        EconomPrice = 1440.00m,
        FirstPrice = 2940.00m,
        BizPrice = 3640.00m,
        AirlineId = 2,
        GateId = 4,
        PlaneId = 2
    },
    new
    {
        FlightId = 9,
        FlightNumber = "AA109",
        DepartureDate = new DateOnly(2024, 07, 09),
        DepartureTime = new TimeOnly(16, 0),
        ArrivalDate = new DateOnly(2024, 07, 09),
        ArrivalTime = new TimeOnly(20, 0),
        Destination = "відправлення",
        AeroportId = 1,
        Status = "Вчасно",
        EconomPrice = 3460.00m,
        FirstPrice = 7960.00m,
        BizPrice = 10760.00m,
        AirlineId = 3,
        GateId = 1,
        PlaneId = 1
    },
    new
    {
        FlightId = 10,
        FlightNumber = "AA110",
        DepartureDate = new DateOnly(2024, 07, 10),
        DepartureTime = new TimeOnly(17, 0),
        ArrivalDate = new DateOnly(2024, 07, 10),
        ArrivalTime = new TimeOnly(21, 0),
        Destination = "прибуття",
        AeroportId = 2,
        Status = "Вчасно",
        EconomPrice = 2480.00m,
        FirstPrice = 4980.00m,
        BizPrice = 8680.00m,
        AirlineId = 3,
        GateId = 2,
        PlaneId = 2
    },
    new
    {
        FlightId = 11,
        FlightNumber = "AA111",
        DepartureDate = new DateOnly(2024, 07, 11),
        DepartureTime = new TimeOnly(18, 0),
        ArrivalDate = new DateOnly(2024, 07, 11),
        ArrivalTime = new TimeOnly(22, 0),
        Destination = "відправлення",
        AeroportId = 3,
        Status = "Затримка",
        EconomPrice = 6500.00m,
        FirstPrice = 11000.00m,
        BizPrice = 14700.00m,
        AirlineId = 3,
        GateId = 3,
        PlaneId = 3
    },
    new
    {
        FlightId = 12,
        FlightNumber = "AA112",
        DepartureDate = new DateOnly(2024, 07, 12),
        DepartureTime = new TimeOnly(19, 0),
        ArrivalDate = new DateOnly(2024, 07, 12),
        ArrivalTime = new TimeOnly(23, 0),
        Destination = "прибуття",
        AeroportId = 4,
        Status = "Вчасно",
        EconomPrice = 4520.00m,
        FirstPrice = 11020.00m,
        BizPrice = 17200.00m,
        AirlineId = 3,
        GateId = 4,
        PlaneId = 2
    },
    new
    {
        FlightId = 13,
        FlightNumber = "AA113",
        DepartureDate = new DateOnly(2024, 07, 13),
        DepartureTime = new TimeOnly(20, 0),
        ArrivalDate = new DateOnly(2024, 07, 13),
        ArrivalTime = new TimeOnly(23, 56),
        Destination = "відправлення",
        AeroportId = 1,
        Status = "Вчасно",
        EconomPrice = 2540.00m,
        FirstPrice = 5040.00m,
        BizPrice = 7400.00m,
        AirlineId = 4,
        GateId = 1,
        PlaneId = 1
    },
    new
    {
        FlightId = 14,
        FlightNumber = "AA114",
        DepartureDate = new DateOnly(2024, 07, 14),
        DepartureTime = new TimeOnly(21, 0),
        ArrivalDate = new DateOnly(2024, 07, 14),
        ArrivalTime = new TimeOnly(1, 0),
        Destination = "прибуття",
        AeroportId = 2,
        Status = "Вчасно",
        EconomPrice = 3560.00m,
        FirstPrice = 4070.00m,
        BizPrice = 7070.00m,
        AirlineId = 4,
        GateId = 2,
        PlaneId = 2
    },
    new
    {
        FlightId = 15,
        FlightNumber = "AA115",
        DepartureDate = new DateOnly(2024, 07, 15),
        DepartureTime = new TimeOnly(22, 0),
        ArrivalDate = new DateOnly(2024, 07, 15),
        ArrivalTime = new TimeOnly(2, 0),
        Destination = "відправлення",
        AeroportId = 3,
        Status = "Затримка",
        EconomPrice = 1880.00m,
        FirstPrice = 2780.00m,
        BizPrice = 5680.00m,
        AirlineId = 4,
        GateId = 3,
        PlaneId = 3
    },
    new
    {
        FlightId = 16,
        FlightNumber = "AA116",
        DepartureDate = new DateOnly(2024, 07, 16),
        DepartureTime = new TimeOnly(23, 0),
        ArrivalDate = new DateOnly(2024, 07, 16),
        ArrivalTime = new TimeOnly(3, 0),
        Destination = "прибуття",
        AeroportId = 4,
        Status = "Вчасно",
        EconomPrice = 2600.00m,
        FirstPrice = 5100.00m,
        BizPrice = 8000.00m,
        AirlineId = 4,
        GateId = 4,
        PlaneId = 1
    },
    new
    {
        FlightId = 17,
        FlightNumber = "AA117",
        DepartureDate = new DateOnly(2024, 07, 17),
        DepartureTime = new TimeOnly(23, 30),
        ArrivalDate = new DateOnly(2024, 07, 17),
        ArrivalTime = new TimeOnly(4, 0),
        Destination = "відправлення",
        AeroportId = 1,
        Status = "Вчасно",
        EconomPrice = 6820.00m,
        FirstPrice = 10120.00m,
        BizPrice = 12820.00m,
        AirlineId = 1,
        GateId = 1,
        PlaneId = 1
    },
    new
    {
        FlightId = 18,
        FlightNumber = "AA118",
        DepartureDate = new DateOnly(2024, 07, 18),
        DepartureTime = new TimeOnly(1, 0),
        ArrivalDate = new DateOnly(2024, 07, 18),
        ArrivalTime = new TimeOnly(5, 0),
        Destination = "прибуття",
        AeroportId = 2,
        Status = "Вчасно",
        EconomPrice = 2040.00m,
        FirstPrice = 4140.00m,
        BizPrice = 5840.00m,
        AirlineId = 1,
        GateId = 2,
        PlaneId = 2
    },
    new
    {
        FlightId = 19,
        FlightNumber = "AA119",
        DepartureDate = new DateOnly(2024, 07, 19),
        DepartureTime = new TimeOnly(2, 0),
        ArrivalDate = new DateOnly(2024, 07, 19),
        ArrivalTime = new TimeOnly(6, 0),
        Destination = "відправлення",
        AeroportId = 3,
        Status = "Затримка",
        EconomPrice = 2660.00m,
        FirstPrice = 4160.00m,
        BizPrice = 6860.00m,
        AirlineId = 1,
        GateId = 3,
        PlaneId = 3
    },
    new
    {
        FlightId = 20,
        FlightNumber = "AA120",
        DepartureDate = new DateOnly(2024, 07, 20),
        DepartureTime = new TimeOnly(3, 0),
        ArrivalDate = new DateOnly(2024, 07, 20),
        ArrivalTime = new TimeOnly(7, 0),
        Destination = "прибуття",
        AeroportId = 4,
        Status = "Вчасно",
        EconomPrice = 4680.00m,
        FirstPrice = 5180.00m,
        BizPrice = 7880.00m,
        AirlineId = 1,
        GateId = 4,
        PlaneId = 1
    },
    new
    {
        FlightId = 21,
        FlightNumber = "AA121",
        DepartureDate = new DateOnly(2024, 07, 21),
        DepartureTime = new TimeOnly(4, 0),
        ArrivalDate = new DateOnly(2024, 07, 21),
        ArrivalTime = new TimeOnly(8, 0),
        Destination = "відправлення",
        AeroportId = 1,
        Status = "Вчасно",
        EconomPrice = 9700.00m,
        FirstPrice = 12000.00m,
        BizPrice = 19000.00m,
        AirlineId = 2,
        GateId = 1,
        PlaneId = 1
    },
    new
    {
        FlightId = 22,
        FlightNumber = "AA122",
        DepartureDate = new DateOnly(2024, 07, 22),
        DepartureTime = new TimeOnly(5, 0),
        ArrivalDate = new DateOnly(2024, 07, 22),
        ArrivalTime = new TimeOnly(9, 0),
        Destination = "прибуття",
        AeroportId = 2,
        Status = "Вчасно",
        EconomPrice = 720.00m,
        FirstPrice = 1220.00m,
        BizPrice = 2920.00m,
        AirlineId = 2,
        GateId = 2,
        PlaneId = 2
    },
    new
    {
        FlightId = 23,
        FlightNumber = "AA123",
        DepartureDate = new DateOnly(2024, 07, 23),
        DepartureTime = new TimeOnly(6, 0),
        ArrivalDate = new DateOnly(2024, 07, 23),
        ArrivalTime = new TimeOnly(10, 0),
        Destination = "відправлення",
        AeroportId = 3,
        Status = "Затримка",
        EconomPrice = 740.00m,
        FirstPrice = 1240.00m,
        BizPrice = 2940.00m,
        AirlineId = 2,
        GateId = 3,
        PlaneId = 3
    },
    new
    {
        FlightId = 24,
        FlightNumber = "AA124",
        DepartureDate = new DateOnly(2024, 07, 24),
        DepartureTime = new TimeOnly(7, 0),
        ArrivalDate = new DateOnly(2024, 07, 24),
        ArrivalTime = new TimeOnly(11, 0),
        Destination = "прибуття",
        AeroportId = 4,
        Status = "Вчасно",
        EconomPrice = 1760.00m,
        FirstPrice = 2260.00m,
        BizPrice = 3960.00m,
        AirlineId = 2,
        GateId = 4,
        PlaneId = 1
    },
    new
    {
        FlightId = 25,
        FlightNumber = "AA125",
        DepartureDate = new DateOnly(2024, 07, 25),
        DepartureTime = new TimeOnly(8, 0),
        ArrivalDate = new DateOnly(2024, 07, 25),
        ArrivalTime = new TimeOnly(12, 0),
        Destination = "відправлення",
        AeroportId = 1,
        Status = "Вчасно",
        EconomPrice = 780.00m,
        FirstPrice = 1280.00m,
        BizPrice = 980.00m,
        AirlineId = 3,
        GateId = 1,
        PlaneId = 1
    },
    new
    {
        FlightId = 26,
        FlightNumber = "AA126",
        DepartureDate = new DateOnly(2024, 07, 26),
        DepartureTime = new TimeOnly(9, 0),
        ArrivalDate = new DateOnly(2024, 07, 26),
        ArrivalTime = new TimeOnly(13, 0),
        Destination = "прибуття",
        AeroportId = 2,
        Status = "Вчасно",
        EconomPrice = 2800.00m,
        FirstPrice = 5300.00m,
        BizPrice = 10000.00m,
        AirlineId = 3,
        GateId = 2,
        PlaneId = 2
    },
   new
   {
       FlightId = 27,
       FlightNumber = "AA127",
       DepartureDate = new DateOnly(2024, 07, 27),
       DepartureTime = new TimeOnly(10, 0),
       ArrivalDate = new DateOnly(2024, 07, 27),
       ArrivalTime = new TimeOnly(14, 0),
       Destination = "відправлення",
       AeroportId = 3,
       Status = "Затримка",
       EconomPrice = 1820.00m,
       FirstPrice = 3620.00m,
       BizPrice = 6020.00m,
       AirlineId = 3,
       GateId = 3,
       PlaneId = 3
   },
    new
    {
        FlightId = 28,
        FlightNumber = "AA128",
        DepartureDate = new DateOnly(2024, 07, 28),
        DepartureTime = new TimeOnly(11, 0),
        ArrivalDate = new DateOnly(2024, 07, 28),
        ArrivalTime = new TimeOnly(15, 0),
        Destination = "прибуття",
        AeroportId = 4,
        Status = "Вчасно",
        EconomPrice = 3840.00m,
        FirstPrice = 7340.00m,
        BizPrice = 10040.00m,
        AirlineId = 3,
        GateId = 4,
        PlaneId = 3
    },
    new
    {
        FlightId = 29,
        FlightNumber = "AA129",
        DepartureDate = new DateOnly(2024, 07, 29),
        DepartureTime = new TimeOnly(12, 0),
        ArrivalDate = new DateOnly(2024, 07, 29),
        ArrivalTime = new TimeOnly(16, 0),
        Destination = "відправлення",
        AeroportId = 1,
        Status = "Вчасно",
        EconomPrice = 1860.00m,
        FirstPrice = 2360.00m,
        BizPrice = 3070.00m,
        AirlineId = 4,
        GateId = 1,
        PlaneId = 1
    },
    new
    {
        FlightId = 30,
        FlightNumber = "AA130",
        DepartureDate = new DateOnly(2024, 07, 30),
        DepartureTime = new TimeOnly(13, 0),
        ArrivalDate = new DateOnly(2024, 07, 30),
        ArrivalTime = new TimeOnly(17, 0),
        Destination = "прибуття",
        AeroportId = 2,
        Status = "Вчасно",
        EconomPrice = 3880.00m,
        FirstPrice = 5380.00m,
        BizPrice = 8080.00m,
        AirlineId = 4,
        GateId = 2,
        PlaneId = 2
    },
    new
    {
        FlightId = 31,
        FlightNumber = "AA131",
        DepartureDate = new DateOnly(2024, 07, 01),
        DepartureTime = new TimeOnly(14, 0),
        ArrivalDate = new DateOnly(2024, 07, 01),
        ArrivalTime = new TimeOnly(18, 0),
        Destination = "відправлення",
        AeroportId = 3,
        Status = "Затримка",
        EconomPrice = 1900.00m,
        FirstPrice = 3400.00m,
        BizPrice = 7100.00m,
        AirlineId = 4,
        GateId = 3,
        PlaneId = 3
    },
    new
    {
        FlightId = 32,
        FlightNumber = "AA132",
        DepartureDate = new DateOnly(2024, 07, 02),
        DepartureTime = new TimeOnly(15, 0),
        ArrivalDate = new DateOnly(2024, 07, 02),
        ArrivalTime = new TimeOnly(19, 0),
        Destination = "прибуття",
        AeroportId = 4,
        Status = "Вчасно",
        EconomPrice = 3920.00m,
        FirstPrice = 420.00m,
        BizPrice = 5120.00m,
        AirlineId = 4,
        GateId = 4,
        PlaneId = 2
    },
    new
    {
        FlightId = 33,
        FlightNumber = "AA133",
        DepartureDate = new DateOnly(2024, 07, 03),
        DepartureTime = new TimeOnly(16, 0),
        ArrivalDate = new DateOnly(2024, 07, 03),
        ArrivalTime = new TimeOnly(20, 0),
        Destination = "відправлення",
        AeroportId = 1,
        Status = "Вчасно",
        EconomPrice = 3940.00m,
        FirstPrice = 6440.00m,
        BizPrice = 11400.00m,
        AirlineId = 1,
        GateId = 1,
        PlaneId = 1
    }


 );

        modelBuilder.Entity<Flight>()
   .Property(t => t.FlightId)
   .ValueGeneratedOnAdd();

        modelBuilder.Entity<Ticket>()
   .Property(t => t.TicketId)
   .ValueGeneratedOnAdd();


        modelBuilder.Entity<Terminal>().HasMany(g => g.Gates).WithOne(t => t.Terminal).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Gate>().HasMany(f => f.Flights).WithOne(g => g.Gate).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Airline>().HasMany(f => f.Flights).WithOne(a => a.Airline).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Aeroport>().HasMany(f => f.Flights).WithOne(aer => aer.Aeroport).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Models.Plane>().HasMany(f => f.Flights).WithOne(p => p.Plane).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Flight>().HasMany(t => t.Tickets).WithOne(f => f.Flight).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Passenger>().HasMany(t => t.Tickets).WithOne(p => p.Passenger).OnDelete(DeleteBehavior.Cascade);
    }
}
