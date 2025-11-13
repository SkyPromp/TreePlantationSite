using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="TaskItem"/> entities in the database.
    /// Implements <see cref="ITaskItemRepository"/>.
    /// </summary>
    public class TaskItemRepository: ITaskItemRepository
    {
        private readonly DbSet<TaskItem> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskItemRepository"/> class.
        /// </summary>
        /// <param name="context">The <see cref="BTPContext"/> used to access the database.</param>
        public TaskItemRepository(BTPContext context)
        {
            dbSet = context.Set<TaskItem>();
        }

        /// <summary>
        /// Creates a new <see cref="TaskItem"/> in the database.
        /// </summary>
        /// <param name="item">The <see cref="TaskItem"/> to create.</param>
        /// <returns>The created <see cref="TaskItem"/> entity.</returns>
        public Task<TaskItem> Create(TaskItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a <see cref="TaskItem"/> from the database.
        /// </summary>
        /// <param name="item">The <see cref="TaskItem"/> to delete.</param>
        public void Delete(TaskItem item)
        {
            item.IsDeleted = true;
            this.dbSet.Update(item);
        }

        /// <summary>
        /// Deletes a <see cref="TaskItem"/> from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the task item to delete.</param>
        public async Task Delete(int id)
        {
            TaskItem? taskItem = await this.dbSet.FindAsync(id);

            if (taskItem != null) this.Delete(taskItem);
        }

        /// <summary>
        /// Retrieves all <see cref="TaskItem"/> entities from the database.
        /// </summary>
        /// <returns>A collection of <see cref="TaskItem"/> entities.</returns>
        public async Task<IEnumerable<TaskItem>> GetAll()
        {
            IQueryable<TaskItem> tasks = this.dbSet
                .Where(task => !task.IsDeleted);

            return await tasks.ToListAsync();
        }

        /// <summary>
        /// Retrieves a <see cref="TaskItem"/> by its ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="TaskItem"/>.</param>
        /// <returns>The <see cref="TaskItem"/> entity, or <c>null</c> if not found.</returns>
        public async Task<TaskItem?> GetById(int id)
        {
            TaskItem? taskItem = await this.dbSet.FindAsync(id);

            return (taskItem?.IsDeleted ?? true) ? null : taskItem;
        }

        /// <summary>
        /// Updates an existing <see cref="TaskItem"/> entity in the database.
        /// </summary>
        /// <param name="modifiedItem">The modified <see cref="TaskItem"/> entity.</param>
        /// <returns>The updated <see cref="TaskItem"/> entity.</returns>
        public TaskItem Update(TaskItem modifiedItem)
        {
            return this.dbSet.Update(modifiedItem).Entity;
        }
    }
}
