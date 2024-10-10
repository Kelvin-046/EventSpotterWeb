using System.ComponentModel.DataAnnotations;

namespace EventSpotterWeb.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "E-mailadres is verplicht.")]
        [EmailAddress(ErrorMessage = "Voer een geldig e-mailadres in.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        [StringLength(100, ErrorMessage = "Het wachtwoord moet minimaal {2} tekens lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bevestig je wachtwoord.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "De wachtwoorden komen niet overeen.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Rol is verplicht.")]
        public UserRole Role { get; set; } // Gebruik enum UserRole in plaats van string
    }
}