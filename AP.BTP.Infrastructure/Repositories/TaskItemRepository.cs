using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Infrastructure.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly DbSet<TaskItem> dbSet;
        public TaskItemRepository(BTPContext context)
        {
            dbSet = context.Set<TaskItem>();
        }
        public Task<TaskItem> Create(TaskItem item)
        {
            throw new NotImplementedException();
        }

        public void Delete(TaskItem item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TaskItem?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TaskItem Update(TaskItem modifiedItem)
        {
            throw new NotImplementedException();
        }
    }
}
