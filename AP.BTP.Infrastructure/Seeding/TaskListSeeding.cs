using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    /// <summary>
    /// Provides extension methods to seed <see cref="TaskList"/> entities into the database.
    /// </summary>
    public static class TaskListSeeding
    {
        /// <summary>
        /// Seeds the <see cref="TaskList"/> entity with initial sample data.
        /// </summary>
        /// <param name="builder">The <see cref="EntityTypeBuilder{TaskList}"/> used to configure the entity.</param>
        /// <remarks>
        /// This method creates three sample <see cref="TaskList"/> records:
        /// <list type="bullet">
        /// <item><description>TaskList with Id = 1, Date = 2025-11-10, UserId = 1</description></item>
        /// <item><description>TaskList with Id = 2, Date = 2025-11-11, UserId = 2</description></item>
        /// <item><description>TaskList with Id = 3, Date = 2025-11-12, UserId = 1</description></item>
        /// </list>
        /// All task lists have <see cref="TaskList.IsDeleted"/> set to <c>false</c>.
        /// Uses <see cref="HasData(IEnumerable{T})"/> to insert data during EF Core migrations or database creation.
        /// </remarks>
        public static void Seed(this EntityTypeBuilder<TaskList> builder)
        {
            List<TaskList> taskLists = new List<TaskList>
            {
                new TaskList { Id = 1, Date = new DateTime(2025, 11, 10), UserId = 1, IsDeleted = false },
                new TaskList { Id = 2, Date = new DateTime(2025, 11, 11), UserId = 2, IsDeleted = false },
                new TaskList { Id = 3, Date = new DateTime(2025, 11, 12), UserId = 1, IsDeleted = false }
            };

            builder.HasData(taskLists);
        }
    }
}