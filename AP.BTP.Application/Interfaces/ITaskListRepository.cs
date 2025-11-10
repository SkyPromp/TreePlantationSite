using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    public interface ITaskListRepository : IGenericRepository<TaskList>
    {
        Task<IEnumerable<TaskList>> GetAllByUserIdAndWeek(int userId, int year, int weekNumber);
    }
}
