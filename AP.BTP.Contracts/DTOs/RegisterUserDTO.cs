using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for registering a new user, including personal details, email, and password.
    /// </summary>
    public class RegisterUserDTO
    {
        /// <summary>
        /// The unique identifier of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the user.
        /// </summary>
        [Required(ErrorMessage = "Voornaam is verplicht")]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        [Required(ErrorMessage = "Achternaam is verplicht")]
        public string LastName { get; set; }

        /// <summary>
        /// The phone number of the user. Must be a valid phone format
        /// </summary>
        [Required(ErrorMessage = "Telefoonnummer is verplicht.")]
        [Phone(ErrorMessage = "Ongeldig telefoonnummer.")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The email address of the user. Must be a valid email format.
        /// </summary>
        [Required(ErrorMessage = "E-mail is verplicht")]
        [EmailAddress(ErrorMessage = "Vul een geldig e-mailadres in.")]
        public string Email { get; set; }

        /// <summary>
        /// The password for the user account. Must contain at least one lowercase letter, 
        /// one uppercase letter, one digit, and one special character.
        /// </summary>
        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
            ErrorMessage = "Wachtwoord voldoet niet aan de eisen")]
        public string Password { get; set; }

        /// <summary>
        /// Confirmation of the user's password. Must match the <see cref="Password"/> field.
        /// </summary>
        [Required(ErrorMessage = "Bevestig je wachtwoord.")]
        [Compare("Password", ErrorMessage = "Wachtwoorden komen niet overeen.")]
        public string ConfirmPassword { get; set; }
    }
}
