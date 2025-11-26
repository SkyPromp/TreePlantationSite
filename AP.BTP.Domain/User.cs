using AP.BTP.Contracts.Enums;
using AP.BTP.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace AP.BTP.Domain
{
    /// <summary>
    /// Represents a system user with associated plantation sites and task lists.
    /// Implements <see cref="IDeletable"/> to support soft deletion.
    /// </summary>
    public class User: IDeletable
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Auth0 identifier of the user.
        /// </summary>
        public required string Auth0Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// gets or sets a value indicating whether the user is approved. default is false.
        /// </summary>
        public bool IsApproved { get; set; } = false;

        /// <summary>
        /// gets or sets the role of the user.
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// Gets or sets the collection of plantation sites associated with the user.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] public ICollection<PlantationSite> PlantationSites { get; set; } = new List<PlantationSite>();

        /// <summary>
        /// Gets or sets the collection of task lists associated with the user.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] public ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();

        /// <summary>
        /// Gets or sets a value indicating whether the user is considered deleted (soft deletion).
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
