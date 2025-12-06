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
        /// Seeds the <see cref="TaskList"/> entity with some sample records.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="EntityTypeBuilder{TEntity}"/> used to configure the entity.</param>
        /// <remarks>
        /// Each seeded <see cref="TaskList"/> will have:
        /// <list type="bullet">
        /// </list>
        /// This method uses <see cref="HasData(IEnumerable{T})"/> to insert the data when migrating or creating the database.
        /// </remarks>
        public static void Seed(this EntityTypeBuilder<TaskList> modelBuilder)
        {
            Random random = new Random(1);
            DateTime middleDate = DateTime.Parse("2025-12-06");
            List<TaskList> taskLists = new List<TaskList>();

            const int totalDates = 201;

            for (int i = 1; i <= totalDates + 1; i++)
            {
                taskLists.Add(new TaskList() { Id = i, Date = middleDate.AddDays(i - totalDates / 2).Date, IsDeleted = false, UserId = 3, PlantationSiteId = i % 2 + 1, ZoneId = ((i % 2) == 0? random.Next(1, 11): random.Next(16, 22))});
            }

            modelBuilder.HasData(taskLists);
        }
    }
}
