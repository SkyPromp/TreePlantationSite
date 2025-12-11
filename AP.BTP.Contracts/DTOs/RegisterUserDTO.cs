using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for registering a new user, including personal details, email, and password.
    /// </summary>
    public record RegisterUserDto
    {
        /// <summary>
        /// The first name of the user.
        /// </summary>
        [Required(ErrorMessage = "Voornaam is verplicht")]
        public required string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        [Required(ErrorMessage = "Achternaam is verplicht")]
        public required string LastName { get; set; }

        /// <summary>
        /// The phone number of the user. Must be a valid phone format
        /// </summary>
        [Required(ErrorMessage = "Telefoonnummer is verplicht.")]
        [Phone(ErrorMessage = "Ongeldig telefoonnummer.")]
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// The email address of the user. Must be a valid email format.
        /// </summary>
        [Required(ErrorMessage = "E-mail is verplicht")]
        [EmailAddress(ErrorMessage = "Vul een geldig e-mailadres in.")]
        public required string Email { get; set; }

        /// <summary>
        /// The password for the user account.
        /// </summary>
        /// <remarks>The password must comply with the constraints defined by the <see
        /// cref="PasswordRequirements"/>.</remarks>
        [PasswordRequirements]
        public required string Password { get; set; }

        /// <summary>
        /// Confirmation of the user's password. Must match the <see cref="Password"/> field.
        /// </summary>
        [Required(ErrorMessage = "Bevestig je wachtwoord.")]
        [Compare("Password", ErrorMessage = "Wachtwoorden komen niet overeen.")]
        public required string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// Specifies password requirements for a data field.
    /// </summary>
    /// <remarks>
    /// This attribute validates that a password meets certain complexity requirements, including:
    /// <list type="bullet">
    ///   <item><description>At least one lowercase letter.</description></item>
    ///   <item><description>At least one uppercase letter.</description></item>
    ///   <item><description>At least one numeric digit.</description></item>
    ///   <item><description>At least one special character.</description></item>
    /// </list>
    /// If the password does not meet these requirements, a validation error message is returned.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class PasswordRequirementsAttribute : ValidationAttribute
    {
        /// <summary>
        /// Validates the specified password value according to the defined complexity rules.
        /// </summary>
        /// <param name="value">The value of the password field being validated.</param>
        /// <param name="validationContext">The context in which the validation is performed.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating success or describing the validation error.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string? password = value as string;

            if (string.IsNullOrWhiteSpace(password))
                return new ValidationResult("Wachtwoord is verplicht.");

            if (!Regexes.Lowercase().IsMatch(password))
                return new ValidationResult("Wachtwoord moet minimaal 1 kleine letter bevatten.");

            if (!Regexes.Uppercase().IsMatch(password))
                return new ValidationResult("Wachtwoord moet minimaal 1 hoofdletter bevatten.");

            if (!Regexes.Digit().IsMatch(password))
                return new ValidationResult("Wachtwoord moet minimaal 1 nummer bevatten.");

            if (!Regexes.Special().IsMatch(password))
                return new ValidationResult("Wachtwoord moet minimaal 1 speciaal teken bevatten.");

            return ValidationResult.Success;
        }
    }

    /// <summary>
    /// Contains precompiled regular expressions used to validate password components.
    /// </summary>
    public static partial class Regexes
    {
        /// <summary>
        /// Matches any lowercase ASCII letter.
        /// </summary>
        [GeneratedRegex("[a-z]")]
        public static partial Regex Lowercase();

        /// <summary>
        /// Matches any uppercase ASCII letter.
        /// </summary>
        [GeneratedRegex("[A-Z]")]
        public static partial Regex Uppercase();

        /// <summary>
        /// Matches any numeric digit.
        /// </summary>
        [GeneratedRegex(@"\d")]
        public static partial Regex Digit();

        /// <summary>
        /// Matches any special character (non-word character or underscore).
        /// </summary>
        [GeneratedRegex(@"[\W_]")]
        public static partial Regex Special();
    }
}
