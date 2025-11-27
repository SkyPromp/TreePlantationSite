using AP.BTP.Contracts.DTOs;
using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    /// <summary>
    /// Repository interface for managing <see cref="Tree"/> entities,
    /// extending <see cref="IGenericRepository{T}"/> with tree-specific operations such as
    /// soft and hard deletion, and paginated retrieval.
    /// </summary>
    public interface ITreeRepository: IGenericRepository<Tree>
    {
        /// <summary>
        /// Soft deletes a <see cref="Tree"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the tree to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Delete(int id);

        /// <summary>
        /// Hard deletes a <see cref="Tree"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the tree to permanently delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task HardDelete(int id);

        /// <summary>
        /// Hard deletes the specified <see cref="Tree"/> entity.
        /// </summary>
        /// <param name="item">The tree entity to permanently delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task HardDelete(Tree item);

        /// <summary>
        /// Retrieves a paginated list of <see cref="Tree"/> entities, optionally filtered by a search string or sorted by name.
        /// </summary>
        /// <param name="pageNr">The page number to retrieve (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">An optional search string to filter trees by species or other properties.</param>
        /// <param name="sortAscending">An optional sorting bool to sort trees by species.</param>
        /// <returns>
        /// A task that returns a paginated list of trees containing total count.
        /// </returns>
        Task<(IEnumerable<Tree> Items, int totalCount)> GetAllPaged(int pageNr, int pageSize, string? search, bool sortAscending);

        /// <summary>
        /// Retrieves all <see cref="Tree"/> entities that are not soft-deleted.
        /// <param name="search">Optional search string to filter by species name.</param>
        /// </summary>
        Task<IEnumerable<Tree>> GetAll(string? search);
    }
}
