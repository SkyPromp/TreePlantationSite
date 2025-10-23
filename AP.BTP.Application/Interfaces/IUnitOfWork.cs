namespace AP.BTP.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public ITreeRepository TreeRepository { get; }
        Task Commit();
        IPlantationSiteRepository PlantationSiteRepository { get; }
    }
}