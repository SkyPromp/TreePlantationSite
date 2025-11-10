using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    public static class TaskListSeeding
    {
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