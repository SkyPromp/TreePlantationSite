using AP.BTP.Contracts.Enums;

namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Data transfer object (DTO) representing a user in the system, including authentication information, personal details,
    /// and related plantation sites and task lists.
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// The unique identifier of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Auth0 identifier for the user.
        /// </summary>
        public required string Auth0Id { get; set; }

        /// <summary>
        /// The user's first name. Defaults to an empty string if not set.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The user's last name. Defaults to an empty string if not set.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// The user's phone number. Defaults to an empty string if not set.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// The user's email address. Defaults to an empty string if not set.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// the user's approval status. defaults to false if not set.
        /// </summary>
        public bool IsApproved { get; set; } = false;

        /// <summary>
        /// the user's role.
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// A collection of plantation sites associated with the user. Can be <c>null</c> if none exist.
        /// </summary>
        public ICollection<PlantationSiteDTO>? PlantationSites { get; set; }

        /// <summary>
        /// A collection of task lists associated with the user. Can be <c>null</c> if none exist.
        /// </summary>
        public ICollection<TaskListDTO>? TaskLists { get; set; }
    }
}
