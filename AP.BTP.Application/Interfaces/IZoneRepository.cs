using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    public interface IZoneRepository: IGenericRepository<Zone>
    {
        public Task<IEnumerable<Zone>> GetAllByPlantationSiteId(int plantationSiteId);
        public Task<IEnumerable<Zone>> GetAll(int pageNr, int pageSize);
        public Task Delete(int id);
        public Task HardDelete(int id);
        public Task HardDelete(Zone item);
    }
}
