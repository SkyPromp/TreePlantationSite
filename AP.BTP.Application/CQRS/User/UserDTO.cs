using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.CQRS.TaskList;

namespace AP.BTP.Application.CQRS.User
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
        /// The user's display name. Defaults to an empty string if not set.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The user's email address. Defaults to an empty string if not set.
        /// </summary>
        public string Email { get; set; } = string.Empty;

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
