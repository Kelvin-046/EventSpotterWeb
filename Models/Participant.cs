namespace EventSpotterWeb.Models
{
    public class Participant
    {
        public int ParticipantID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int AccountID { get; set; } // Dit is de UserId die verwijst naar de Account
        public Account Account { get; set; } // Navigatie-eigenschap

        // One-to-Many relationship: A Participant can make multiple Reservations
        public ICollection<Reservation>? Reservations { get; set; }
        
    }
}
