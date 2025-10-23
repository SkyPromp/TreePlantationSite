using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Infrastructure.Repositories
{
    public class ZoneRepository: IZoneRepository
    {
        private readonly DbSet<Zone> dbSet;

        public ZoneRepository(BTPContext context)
        {
            this.dbSet = context.Set<Zone>();
        }

        public async Task<Zone> Create(Zone item)
        {
            await this.dbSet.AddAsync(item);

            return item;
        }

        public void Delete(Zone item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Zone>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Zone?> GetById(int id)
        {
            Zone? zone = await this.dbSet.FindAsync(id);

            return (zone?.IsDeleted ?? true) ? null : zone;
        }

        public Zone Update(Zone modifiedItem)
        {
            throw new NotImplementedException();
        }
    }
}
