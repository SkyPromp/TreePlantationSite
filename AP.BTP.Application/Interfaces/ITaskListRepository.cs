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
    }
}
