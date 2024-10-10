namespace EventSpotterWeb.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int MaxParticipants { get; set; }
        public decimal Cost { get; set; }
        public int AvailableSeats { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }
        public int CategoryID { get; set; }
        public int OrganizerID { get; set; }

        // Many-to-One relationship with Organizer
        public Organizer? Organizer { get; set; }

        // Many-to-One relationship with Category
        public Category? Category { get; set; }

        // One-to-Many relationship: An Event can have multiple Reservations
        public ICollection<Reservation>? Reservations { get; set; }

        
    }   
}
