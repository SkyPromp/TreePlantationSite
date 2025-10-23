using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;

namespace AP.BTP.Infrastructure.Repositories
{
    public class ZoneRepository: IZoneRepository
    {
        public Task<Zone> Create(Zone item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Zone item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Zone>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Zone?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Zone Update(Zone modifiedItem)
        {
            throw new NotImplementedException();
        }
    }
}
