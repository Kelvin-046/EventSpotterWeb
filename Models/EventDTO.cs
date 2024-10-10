namespace EventSpotterWeb.Models
{
    public class EventDto
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


    }

}
