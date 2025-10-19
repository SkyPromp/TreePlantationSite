namespace AP.BTP.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
        IPlantationSiteRepository PlantationSiteRepository { get; }
    }
}