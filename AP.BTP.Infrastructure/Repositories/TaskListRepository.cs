using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Infrastructure.Repositories
{
    public class TaskListRepository : ITaskListRepository
    {
        private readonly DbSet<TaskList> dbSet;
        public TaskListRepository(BTPContext context)
        {
            dbSet = context.Set<TaskList>();
        }
        public Task<TaskList> Create(TaskList item)
        {
            throw new NotImplementedException();
        }

        public void Delete(TaskList item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskList>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TaskList?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TaskList Update(TaskList modifiedItem)
        {
            throw new NotImplementedException();
        }
    }
}
