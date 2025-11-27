using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    /// <summary>
    /// Repository interface for managing <see cref="TaskList"/> entities, 
    /// extending <see cref="IGenericRepository{T}"/> with methods specific to user and week queries.
    /// </summary>
    public interface ITaskListRepository: IGenericRepository<TaskList>
    {
        /// <summary>
        /// Retrieves all <see cref="TaskList"/> entities for a specific user within a given year and week number.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="year">The year for which to retrieve task lists.</param>
        /// <param name="weekNumber">The ISO week number for which to retrieve task lists.</param>
        /// <returns>
        /// A task that returns an enumerable of <see cref="TaskList"/> entities matching the specified criteria.
        /// </returns>
        Task<IEnumerable<TaskList>> GetAllByUserIdAndWeek(int userId, int year, int weekNumber);

        /// <summary>
        /// Retrieves all <see cref="TaskList"/> entities for a specific user on a specific date
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="date">The date of the tasklist.</param>
        /// <returns>A collection of <see cref="TaskList"/> entities for the specified user and date.</returns>
        Task<TaskList?> GetAllByUserIdAndDate(int userId, DateTime date);

        /// <summary>
        /// Retrieves a <see cref="TaskList"/> by its ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="TaskList"/>.</param>
        /// <returns>The <see cref="TaskList"/> with the specified ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified ID is not found or is deleted.</exception>
        Task<TaskList?> GetByIdUntracked(int id);
    }
}
