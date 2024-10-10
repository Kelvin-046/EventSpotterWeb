using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventSpotterWeb.Models
{
    public class Account
    {
        public int AccountID { get; set; } // Auto-increment ID

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } 

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; } // Bijv. "Organizer" of "Participant"

        // Relaties
        public ICollection<Organizer> Organizers { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}
