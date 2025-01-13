namespace AirportProj.Models
{
    public class FlightPassengerViewModel
    {
        public Flight Flight { get; set; }
        public string SelectedTicketClass { get; set; }
        public string ErrorMessage { get; set; }
        public Passenger Passenger { get; set; }
    }
}
