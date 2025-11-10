using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    /// <summary>
    /// Repository interface for managing <see cref="Zone"/> entities,
    /// extending <see cref="IGenericRepository{T}"/> with zone-specific operations
    /// such as retrieval by plantation site, pagination, and deletion (soft and hard).
    /// </summary>
    public interface IZoneRepository: IGenericRepository<Zone>
    {
        /// <summary>
        /// Retrieves all <see cref="Zone"/> entities associated with a specific plantation site.
        /// </summary>
        /// <param name="plantationSiteId">The unique identifier of the plantation site.</param>
        /// <returns>A task that returns an enumerable of <see cref="Zone"/> entities.</returns>
        Task<IEnumerable<Zone>> GetAllByPlantationSiteId(int plantationSiteId);

        /// <summary>
        /// Retrieves a paginated list of <see cref="Zone"/> entities.
        /// </summary>
        /// <param name="pageNr">The page number to retrieve (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A task that returns an enumerable of <see cref="Zone"/> entities for the requested page.</returns>
        Task<IEnumerable<Zone>> GetAll(int pageNr, int pageSize);

        /// <summary>
        /// Soft deletes a <see cref="Zone"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the zone to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Delete(int id);

        /// <summary>
        /// Hard deletes a <see cref="Zone"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the zone to permanently delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task HardDelete(int id);

        /// <summary>
        /// Hard deletes the specified <see cref="Zone"/> entity.
        /// </summary>
        /// <param name="item">The zone entity to permanently delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task HardDelete(Zone item);
    }

}
