using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    /// <summary>
    /// Provides extension methods to seed <see cref="TaskItem"/> entities into the database.
    /// </summary>
    public static class TaskItemSeeding
    {
        /// <summary>
        /// Seeds the <see cref="TaskItem"/> entity with initial sample data.
        /// </summary>
        /// <param name="builder">The <see cref="EntityTypeBuilder{TaskItem}"/> used to configure the entity.</param>
        /// <remarks>
        /// This method creates three sample <see cref="TaskItem"/> records:
        /// <list type="bullet">
        /// <item><description>TaskItem with Id = 1, Title = "Task 1", Description = "Description 1", TaskListId = 1</description></item>
        /// <item><description>TaskItem with Id = 2, Title = "Task 2", Description = "Description 2", TaskListId = 1</description></item>
        /// <item><description>TaskItem with Id = 3, Title = "Task 3", Description = "Description 3", TaskListId = 2</description></item>
        /// </list>
        /// All tasks have <see cref="TaskItem.IsDeleted"/> set to <c>false</c>.
        /// Uses <see cref="HasData(IEnumerable{T})"/> to insert data when migrating or creating the database.
        /// </remarks>
        public static void Seed(this EntityTypeBuilder<TaskItem> builder)
        {
            List<TaskItem> tasks = new List<TaskItem>
            {
                new TaskItem { Id = 1, Title = "Task 1", Description = "Description 1", TaskListId = 1, IsDeleted = false },
                new TaskItem { Id = 2, Title = "Task 2", Description = "Description 2", TaskListId = 1, IsDeleted = false },
                new TaskItem { Id = 3, Title = "Task 3", Description = "Description 3", TaskListId = 2, IsDeleted = false }
            };

            builder.HasData(tasks);
        }
    }
}
