using AP.BTP.Application.CQRS.Auth0User;

namespace AP.BTP.Application.Interfaces
{
    /// <summary>
    /// Defines methods for interacting with Auth0 management operations, including user approval,
    /// retrieving roles, and managing users in the Auth0 system.
    /// </summary>
    public interface IAuth0ManagementService
    {
        /// <summary>
        /// Approves a user in Auth0 and assigns the specified role.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to approve.</param>
        /// <param name="role">The role to assign to the user.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task ApproveUserAsync(string userId, string role);

        /// <summary>
        /// Retrieves a paginated list of all unapproved users in Auth0 that match the specified search term.
        /// </summary>
        /// <param name="pageNr">The page number to retrieve (1-based).</param>
        /// <param name="pageSize">The number of users per page.</param>
        /// <param name="search">A search term to filter users by username or email.</param>
        /// <returns>
        /// A task that returns a tuple containing:
        /// <list type="bullet">
        /// <item><description>An enumerable of <see cref="Auth0User"/> representing the users.</description></item>
        /// <item><description>The total count of matching unapproved users.</description></item>
        /// </list>
        /// </returns>
        Task<(IEnumerable<Auth0User> Items, int TotalCount)> GetAllUnapprovedUsersPaged(int pageNr, int pageSize, string search);

        /// <summary>
        /// Retrieves all roles available in Auth0.
        /// </summary>
        /// <returns>A task that returns an enumerable of <see cref="Auth0Role"/>.</returns>
        Task<IEnumerable<Auth0Role>> GetRoles();

        /// <summary>
        /// Retrieves a specific user from Auth0 by their unique Auth0 identifier.
        /// </summary>
        /// <param name="auth0Id">The unique Auth0 identifier of the user.</param>
        /// <returns>A task that returns the <see cref="Auth0User"/> if found; otherwise, null.</returns>
        Task<Auth0User?> GetUserByIdAsync(string auth0Id);

        /// <summary>
        /// Deletes a user from Auth0.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteUserAsync(string userId);
    }
}
