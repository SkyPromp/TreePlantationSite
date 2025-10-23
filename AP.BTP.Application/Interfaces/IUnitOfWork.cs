namespace AP.BTP.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public ITreeRepository TreeRepository { get; }
        public IZoneRepository ZoneRepository { get; }
        public IPlantationSiteRepository PlantationSiteRepository { get; }
        Task Commit();
    }
}