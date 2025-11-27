using AP.BTP.Contracts.DTOs;

namespace AP.BTP.Application.Interfaces
{
    /// <summary>
    /// Defines methods for interacting with Auth0 management operations, including 
    /// retrieving roles, and managing users in the Auth0 system.
    /// </summary>
    public interface IAuth0ManagementService
    {
        /// <summary>
        /// Retrieves a specific user from Auth0 by their unique Auth0 identifier.
        /// </summary>
        /// <param name="auth0Id">The unique Auth0 identifier of the user.</param>
        /// <returns>A task that returns the <see cref="Auth0User"/> if found; otherwise, null.</returns>
        Task<Auth0UserDTO?> GetUserByIdAsync(string auth0Id);

        /// <summary>
        /// Deletes a user from Auth0.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteUserAsync(string userId);

        /// <summary>
        /// Creates a user in Auth0.
        /// </summary>
        /// <param name="username">The name of the user to be created.</param>
        /// <param name="email">The email of the user to be created.</param>
        /// <param name="password">The password of the user to be created.</param>
        /// <returns>A task that returns the <see cref="Auth0User"/> if created; otherwise, null.</returns>
        Task<Auth0UserDTO?> CreateUserAsync(string username, string email, string password);

        /// <summary>
        /// assigns a role to a user in Auth0.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to assign the role to.</param>
        /// <param name="role">The name of the role to assign.</param>
        Task AssignRoleToUserAsync(string userId, string role);
    }
}
