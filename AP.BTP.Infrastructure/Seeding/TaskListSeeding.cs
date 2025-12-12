using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

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
            DateTime middleDate = DateTime.ParseExact(
                "2026-01-16",
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture
            );
            int daysToSetDayToMonday = 4;
            List<TaskList> taskLists = new List<TaskList>();

            const int totalDates = 101;

            for (int userIdOffset = 0; userIdOffset < 3; userIdOffset++)
            {
                int dayoffset = 0;

                for (int i = 1; i <= totalDates + 1; i++)
                {
                    int weekday = i % 7;

                    if ((weekday + dayoffset) % 7 == 5) dayoffset += 2;

                    int plantationSiteBaseId = ((i - daysToSetDayToMonday + dayoffset) / 7) % 2 + 1;

                    taskLists.Add(new TaskList() {
                        Id = userIdOffset * (totalDates + 1) + i, 
                        Date = middleDate.AddDays(i - totalDates / 2 + dayoffset).Date, 
                        IsDeleted = false, 
                        UserId = 3 + userIdOffset, 
                        PlantationSiteId = plantationSiteBaseId + userIdOffset * 2,
                        ZoneId = (plantationSiteBaseId == 1? random.Next(1, 11) + userIdOffset * 20: random.Next(11, 21) + userIdOffset * 20)
                    });
                }
            }

            modelBuilder.HasData(taskLists);
        }
    }
}
