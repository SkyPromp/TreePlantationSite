namespace AP.BTP.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public ITreeRepository TreeRepository { get; }
        public IZoneRepository ZoneRepository { get; }
        public IPlantationSiteRepository PlantationSiteRepository { get; }
        public IUserRepository UserRepository { get; }
        public ITaskListRepository TaskListRepository { get; }
        public ITaskItemRepository TaskItemRepository { get; }
        Task Commit();
    }
}