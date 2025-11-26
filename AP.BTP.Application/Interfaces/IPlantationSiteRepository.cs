using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    /// <summary>
    /// Defines a repository interface for managing <see cref="PlantationSite"/> entities,
    /// extending the generic repository with pagination support.
    /// </summary>
    public interface IPlantationSiteRepository: IGenericRepository<PlantationSite>
    {
        /// <summary>
        /// Retrieves a paginated list of <see cref="PlantationSite"/> entities that match the specified search term.
        /// </summary>
        /// <param name="pageNr">The page number to retrieve (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">A search term to filter plantation sites by name, city, or other criteria.</param>
        /// <param name="sortAscending">An optional sorting bool to sort sites by name.</param>
        /// <returns>
        /// A task that returns a tuple containing:
        /// <list type="bullet">
        /// <item><description>An enumerable of <see cref="PlantationSite"/> items for the requested page.</description></item>
        /// <item><description>The total count of matching plantation sites.</description></item>
        /// </list>
        /// </returns>
        Task<(IEnumerable<PlantationSite> Items, int TotalCount)> GetAllPaged(int pageNr, int pageSize, string search, bool sortAscending);
    }
}
