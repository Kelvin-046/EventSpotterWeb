namespace EventSpotterWeb.Models
{
    public class Tickets
    {
        public int TicketID { get; set; }
        public string SeatNumber { get; set; }
        public DateTime ReservationDate { get; set; }

        // Many-to-One relationship with Reservation
        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }

        // One-to-One relationship with TicketManagement
        public TicketManagement? TicketManagement { get; set; }
    }
}
