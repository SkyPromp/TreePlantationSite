using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    public static class TaskItemSeeding
    {
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
