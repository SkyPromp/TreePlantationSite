using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    /// <summary>
    /// Repository interface for managing <see cref="TaskItem"/> entities, 
    /// providing standard data access operations through <see cref="IGenericRepository{T}"/>.
    /// </summary>
    public interface ITaskItemRepository : IGenericRepository<TaskItem>
    {
    }
}
