using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    public interface IPlantationSiteRepository: IGenericRepository<PlantationSite>
    {
        Task<(IEnumerable<PlantationSite> Items, int TotalCount)> GetAllPaged(int pageNr, int pageSize, string search);
    }
}
