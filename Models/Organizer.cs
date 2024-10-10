namespace EventSpotterWeb.Models
{
    public class Organizer
    {
        public int OrganizerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int AccountID { get; set; } // Dit is de UserId die verwijst naar de Account
        public Account Accounts { get; set; } // Navigatie-eigenschap

        // One-to-Many relationship: An Organizer can create multiple Events
        public ICollection<Event>? Events { get; set; }
    }
}
