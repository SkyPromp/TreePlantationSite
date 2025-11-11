using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="Zone"/> entities in the database.
    /// Implements <see cref="IZoneRepository"/>.
    /// </summary>
    public class ZoneRepository: IZoneRepository
    {
        private readonly DbSet<Zone> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneRepository"/> class.
        /// </summary>
        /// <param name="context">The <see cref="BTPContext"/> used to access the database.</param>
        public ZoneRepository(BTPContext context)
        {
            this.dbSet = context.Set<Zone>();
        }

        /// <summary>
        /// Creates a new <see cref="Zone"/> entity in the database.
        /// </summary>
        /// <param name="item">The <see cref="Zone"/> to create.</param>
        /// <returns>The created <see cref="Zone"/> entity.</returns>
        public async Task<Zone> Create(Zone item)
        {
            await this.dbSet.AddAsync(item);

            return item;
        }

        /// <summary>
        /// Soft-deletes a <see cref="Zone"/> by setting <see cref="Zone.IsDeleted"/> to <c>true</c>.
        /// </summary>
        /// <param name="item">The <see cref="Zone"/> entity to soft-delete.</param>
        public void Delete(Zone item)
        {
            item.IsDeleted = true;
            this.dbSet.Update(item);
        }

        /// <summary>
        /// Soft-deletes a <see cref="Zone"/> by its ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Zone"/> to delete.</param>
        public async Task Delete(int id)
        {
            Zone? zone = await this.dbSet.FindAsync(id);

            if (zone != null) Delete(zone);
        }

        /// <summary>
        /// Permanently deletes a <see cref="Zone"/> entity from the database.
        /// </summary>
        /// <param name="item">The <see cref="Zone"/> entity to permanently delete.</param>
        public async Task HardDelete(Zone item)
        {
            await this.HardDelete(item.Id);
        }

        /// <summary>
        /// Permanently deletes a <see cref="Zone"/> entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Zone"/> to delete.</param>
        public async Task HardDelete(int id)
        {
            await this.dbSet.Where(t => t.Id == id).ExecuteDeleteAsync();
        }

        /// <summary>
        /// Retrieves all <see cref="Zone"/> entities belonging to a specified plantation site.
        /// </summary>
        /// <param name="plantationSiteId">The ID of the plantation site to filter by.</param>
        /// <returns>A collection of <see cref="Zone"/> entities associated with the plantation site.</returns>
        public async Task<IEnumerable<Zone>> GetAllByPlantationSiteId(int plantationSiteId)
        {
            return await this.dbSet.Where(zone => !zone.IsDeleted && zone.PlantationSite.Id == plantationSiteId).ToListAsync();
        }

        /// <summary>
        /// Retrieves all non-deleted <see cref="Zone"/> entities.
        /// </summary>
        /// <returns>A collection of all active <see cref="Zone"/> entities.</returns>
        public async Task<IEnumerable<Zone>> GetAll()
        {
            return await this.dbSet.Where(zone => !zone.IsDeleted).ToListAsync();
        }

        /// <summary>
        /// Retrieves a paged list of <see cref="Zone"/> entities.
        /// </summary>
        /// <param name="pageNr">The page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A paginated collection of non-deleted <see cref="Zone"/> entities.</returns>
        public async Task<IEnumerable<Zone>> GetAll(int pageNr, int pageSize)
        {
            return await this.dbSet.Where(zone => !zone.IsDeleted).Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        /// <summary>
        /// Retrieves a <see cref="Zone"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Zone"/> to retrieve.</param>
        /// <returns>
        /// The <see cref="Zone"/> entity if found and not soft-deleted; otherwise, <c>null</c>.
        /// </returns>
        public async Task<Zone?> GetById(int id)
        {
            Zone? zone = await this.dbSet.FindAsync(id);

            return (zone?.IsDeleted ?? true) ? null : zone;
        }

        /// <summary>
        /// Updates an existing <see cref="Zone"/> entity in the database.
        /// </summary>
        /// <param name="modifiedItem">The modified <see cref="Zone"/> entity.</param>
        /// <returns>The updated <see cref="Zone"/> entity.</returns>
        public Zone Update(Zone modifiedItem)
        {
            return this.dbSet.Update(modifiedItem).Entity;
        }
    }
}
