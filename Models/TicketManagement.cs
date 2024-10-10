using System.Net.Sockets;

namespace EventSpotterWeb.Models
{
    public class TicketManagement
    {
        public int? TicketManagementID { get; set; }
        public string? Status { get; set; }

        // One-to-One relationship with Ticket
        public int? TicketID { get; set; }
        public Tickets? Ticket { get; set; }
    }
}
