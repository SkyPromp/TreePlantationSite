using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    /// <summary>
    /// Repository interface for managing <see cref="TaskItem"/> entities, 
    /// providing standard data access operations through <see cref="IGenericRepository{T}"/>.
    /// </summary>
    public interface ITaskItemRepository : IGenericRepository<TaskItem>
    {
        /// <summary>
        /// Soft deletes a <see cref="TaskItem"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the tree to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Delete(int id);
    }
}
