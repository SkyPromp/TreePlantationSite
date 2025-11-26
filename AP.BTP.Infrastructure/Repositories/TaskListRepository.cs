using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AP.BTP.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="TaskList"/> entities in the database.
    /// Implements <see cref="ITaskListRepository"/>.
    /// </summary>
    public class TaskListRepository: ITaskListRepository
    {
        private readonly DbSet<TaskList> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskListRepository"/> class.
        /// </summary>
        /// <param name="context">The <see cref="BTPContext"/> used to access the database.</param>
        public TaskListRepository(BTPContext context)
        {
            dbSet = context.Set<TaskList>();
        }

        /// <summary>
        /// Creates a new <see cref="TaskList"/> in the database.
        /// </summary>
        /// <param name="item">The <see cref="TaskList"/> to create.</param>
        /// <returns>The created <see cref="TaskList"/> entity.</returns>
        /// <exception cref="NotImplementedException">Thrown because this method is not yet implemented.</exception>
        public async Task<TaskList> Create(TaskList item)
        {
            await this.dbSet.AddAsync(item);

            return item;
        }

        /// <summary>
        /// Deletes a <see cref="TaskList"/> from the database.
        /// </summary>
        /// <param name="item">The <see cref="TaskList"/> to delete.</param>
        /// <exception cref="NotImplementedException">Thrown because this method is not yet implemented.</exception>
        public void Delete(TaskList item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves all <see cref="TaskList"/> entities from the database.
        /// </summary>
        /// <returns>A collection of <see cref="TaskList"/> entities.</returns>
        /// <exception cref="NotImplementedException">Thrown because this method is not yet implemented.</exception>
        public Task<IEnumerable<TaskList>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves all <see cref="TaskList"/> entities for a specific user in a specific ISO week and year.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="year">The year of the ISO week.</param>
        /// <param name="weekNumber">The ISO week number.</param>
        /// <returns>A collection of <see cref="TaskList"/> entities for the specified user and week.</returns>
        public async Task<IEnumerable<TaskList>> GetAllByUserIdAndWeek(int userId, int year, int weekNumber)
        {
            DateTime calendar = ISOWeek.ToDateTime(year, weekNumber, DayOfWeek.Monday);
            DateTime startOfWeek = calendar.Date;
            DateTime endOfWeek = startOfWeek.AddDays(7);

            return await dbSet
                .Where(tl =>
                    !tl.IsDeleted &&
                    tl.UserId == userId &&
                    tl.Date >= startOfWeek &&
                    tl.Date < endOfWeek)
                .Include(tl => tl.TaskItems.Where(item => !item.IsDeleted))
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a <see cref="TaskList"/> by its ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="TaskList"/>.</param>
        /// <returns>The <see cref="TaskList"/> with the specified ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified ID is not found or is deleted.</exception>
        public async Task<TaskList?> GetById(int id)
        {
            TaskList? site = await dbSet
            .FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == id);

            if (site == null) throw new KeyNotFoundException($"TaskList with ID {id} not found.");

            return site;
        }

        /// <summary>
        /// Updates an existing <see cref="TaskList"/> entity in the database.
        /// </summary>
        /// <param name="modifiedItem">The modified <see cref="TaskList"/> entity.</param>
        /// <returns>The updated <see cref="TaskList"/> entity.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the entity to update is not found.</exception>
        public TaskList Update(TaskList modifiedItem)
        {
            TaskList? existingEntity = dbSet.Find(modifiedItem.Id);

            if (existingEntity == null) throw new KeyNotFoundException($"TaskList with ID {modifiedItem.Id} not found.");

            dbSet.Entry(existingEntity).CurrentValues.SetValues(modifiedItem);

            return existingEntity;
        }
    }
}
