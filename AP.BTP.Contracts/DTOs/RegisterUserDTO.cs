using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for registering a new user, including personal details, email, and password.
    /// </summary>
    public class RegisterUserDTO
    {
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
        [PasswordRequirements]
        public string Password { get; set; }

        /// <summary>
        /// Confirmation of the user's password. Must match the <see cref="Password"/> field.
        /// </summary>
        [Required(ErrorMessage = "Bevestig je wachtwoord.")]
        [Compare("Password", ErrorMessage = "Wachtwoorden komen niet overeen.")]
        public string ConfirmPassword { get; set; }
    }

    public class PasswordRequirementsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string? password = value as string;

            if (string.IsNullOrWhiteSpace(password))
                return new ValidationResult("Wachtwoord is verplicht.");

            if (!Regex.IsMatch(password, @"[a-z]"))
                return new ValidationResult("Wachtwoord moet minimaal 1 kleine letter bevatten.");

            if (!Regex.IsMatch(password, @"[A-Z]"))
                return new ValidationResult("Wachtwoord moet minimaal 1 hoofdletter bevatten.");

            if (!Regex.IsMatch(password, @"\d"))
                return new ValidationResult("Wachtwoord moet minimaal 1 nummer bevatten.");

            if (!Regex.IsMatch(password, @"[\W_]"))
                return new ValidationResult("Wachtwoord moet minimaal 1 speciaal teken bevatten.");

            return ValidationResult.Success;
        }
    }
}
