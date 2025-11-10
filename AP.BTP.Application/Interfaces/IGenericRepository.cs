namespace AP.BTP.Application.Interfaces
{
    /// <summary>
    /// Defines a generic repository interface for performing common data access operations
    /// such as retrieving, creating, updating, and deleting entities.
    /// </summary>
    /// <typeparam name="T">The type of entity managed by the repository.</typeparam>
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Retrieves all entities of type <typeparamref name="T"/> from the data source.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, containing an enumerable collection
        /// of all entities.
        /// </returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Retrieves an entity of type <typeparamref name="T"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to retrieve.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the entity if found;
        /// otherwise, <c>null</c>.
        /// </returns>
        Task<T?> GetById(int id);

        /// <summary>
        /// Creates a new entity of type <typeparamref name="T"/> in the data source.
        /// </summary>
        /// <param name="item">The entity to create.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the created entity.
        /// </returns>
        Task<T> Create(T item);

        /// <summary>
        /// Updates an existing entity of type <typeparamref name="T"/> in the data source.
        /// </summary>
        /// <param name="modifiedItem">The modified entity with updated values.</param>
        /// <returns>The updated entity.</returns>
        T Update(T modifiedItem);

        /// <summary>
        /// Deletes an existing entity of type <typeparamref name="T"/> from the data source.
        /// </summary>
        /// <param name="item">The entity to delete.</param>
        void Delete(T item);
    }

}
