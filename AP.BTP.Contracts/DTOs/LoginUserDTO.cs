using System.ComponentModel.DataAnnotations;

namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for logging a user in.
    /// </summary>
    public record LoginUserDTO
    {
        /// <summary>
        /// The email address of the user. Must be a valid email format.
        /// </summary>
        [Required(ErrorMessage = "E-mail is verplicht.")]
        [EmailAddress(ErrorMessage = "Vul een geldig e-mailadres in.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The password for the user account.
        /// </summary>
        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Whether the login request is for the maintenance app.
        /// </summary>
        public bool? IsForMaintenance { get; set; } = null;
    }
}
