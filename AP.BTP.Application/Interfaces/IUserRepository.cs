using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    /// <summary>
    /// Repository interface for managing <see cref="User"/> entities,
    /// extending <see cref="IGenericRepository{T}"/> with user-specific operations
    /// such as retrieval by Auth0 ID, paginated queries, and soft deletion.
    /// </summary>
    public interface IUserRepository: IGenericRepository<User>
    {
        /// <summary>
        /// Retrieves a <see cref="User"/> entity by its Auth0 identifier.
        /// </summary>
        /// <param name="Auth0Id">The Auth0 ID of the user.</param>
        /// <returns>
        /// A task that returns the <see cref="User"/> if found; otherwise, <c>null</c>.
        /// </returns>
        Task<User?> GetUserByAuth0Id(string Auth0Id);

        /// <summary>
        /// Retrieves a <see cref="User"/> entity by its Auth0 identifier, also if the user is deleted.
        /// </summary>
        /// <param name="Auth0Id">The Auth0 ID of the user.</param>
        /// <returns>
        /// A task that returns the <see cref="User"/> if found; otherwise, <c>null</c>.
        /// </returns>
        Task<User?> GetUserByAuth0IdIncludingDeleted(string auth0UserId);

        /// <summary>
        /// Retrieves a paginated list of all approved users matching the specified search term.
        /// </summary>
        /// <param name="pageNr">The page number to retrieve (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">A search term to filter users.</param>
        /// <returns>
        /// A task that returns a tuple containing:
        /// <list type="bullet">
        /// <item><description>An enumerable of <see cref="User"/> items for the requested page.</description></item>
        /// <item><description>The total count of matching users.</description></item>
        /// </list>
        /// </returns>
        Task<(IEnumerable<User> Items, int TotalCount)> GetAllApprovedPaged(int pageNr, int pageSize, string search);

        /// <summary>
        /// Retrieves a paginated list of all operator users matching the specified search term.
        /// </summary>
        /// <param name="pageNr">The page number to retrieve (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">A search term to filter operator users.</param>
        /// <returns>
        /// A task that returns a tuple containing:
        /// <list type="bullet">
        /// <item><description>An enumerable of <see cref="User"/> items for the requested page.</description></item>
        /// <item><description>The total count of matching operator users.</description></item>
        /// </list>
        /// </returns>
        Task<(IEnumerable<User> Items, int TotalCount)> GetAllOperatorsPaged(int pageNr, int pageSize, string search);

        /// <summary>
        /// Retrieves a paginated list of all unapproved users matching the specified search term.
        /// </summary>
        /// <param name="pageNr">The page number to retrieve (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">A search term to filter approved users.</param>
        /// <returns>
        /// A task that returns a tuple containing:
        /// <list type="bullet">
        /// <item><description>An enumerable of <see cref="User"/> items for the requested page.</description></item>
        /// <item><description>The total count of matching operator users.</description></item>
        /// </list>
        /// </returns>
        Task<(IEnumerable<User> Items, int TotalCount)> GetAllUnapprovedUsersPaged(int pageNr, int pageSize, string search);

        /// <summary>
        /// Soft deletes a <see cref="User"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete.</param>
        /// <returns>A task representing the asynchronous delete operation.</returns>
        Task Delete(int id);
    }
}
