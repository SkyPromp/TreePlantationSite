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
            item.IsDeleted = true;
            this.dbSet.Update(item);
        }

        public async void Delete(int id)
        {
            Zone? zone = await this.dbSet.FindAsync(id);

            if (zone != null) Delete(zone);
        }

        public void HardDelete(Zone item)
        {
            this.HardDelete(item.Id);
        }

        public void HardDelete(int id)
        {
            this.dbSet.Where(t => t.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Zone>> GetAll()
        {
            return await this.dbSet.Where(zone => !zone.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Zone>> GetAll(int pageNr, int pageSize)
        {
            return await this.dbSet.Where(zone => !zone.IsDeleted).Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Zone?> GetById(int id)
        {
            Zone? zone = await this.dbSet.FindAsync(id);

            return (zone?.IsDeleted ?? true) ? null : zone;
        }

        public Zone Update(Zone modifiedItem)
        {
            return this.dbSet.Update(modifiedItem).Entity;
        }
    }
}
