using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    public interface IZoneRepository: IGenericRepository<Zone>
    {
        public Task<IEnumerable<Zone>> GetAllByPlantationSiteId(int plantationSiteId);
        public Task<IEnumerable<Zone>> GetAll(int pageNr, int pageSize);
        public void Delete(int id);
        public void HardDelete(int id);
        public void HardDelete(Zone item);
    }
}
