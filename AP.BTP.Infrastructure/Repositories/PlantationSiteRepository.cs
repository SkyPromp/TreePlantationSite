using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class PlantationSiteRepository: IPlantationSiteRepository
{
    private readonly DbSet<PlantationSite> dbSet;

	public PlantationSiteRepository(BTPContext context)
	{
        dbSet = context.Set<PlantationSite>();
	}

    public async Task<PlantationSite> Create(PlantationSite plantationSite)
    {
        await dbSet.AddAsync(plantationSite);
        return plantationSite;
    }

    public void Delete(PlantationSite item)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PlantationSite>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<(IEnumerable<PlantationSite> Items, int TotalCount)> GetAllPaged(int pageNr, int pageSize, string search)
    {
        IQueryable<PlantationSite> query = dbSet
            .Where(ps => !ps.IsDeleted)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();

            query = query.Where(ps =>
                ps.Name.ToLower().Contains(search));
        }

        int totalCount = await query.CountAsync();

        List<PlantationSite> items = await query.Skip((pageNr - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();
                            
        return (items, totalCount);
    }

    public async Task<PlantationSite> GetById(int id)
    {
        PlantationSite? site = await dbSet
            .Where(ps => !ps.IsDeleted)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (site == null)
            throw new KeyNotFoundException($"PlantationSite with ID {id} not found.");

        return site;
    }

    public PlantationSite Update(PlantationSite modifiedItem)
    {
        PlantationSite? existingEntity = dbSet.Find(modifiedItem.Id);
        if (existingEntity == null)
            throw new KeyNotFoundException($"PlantationSite with ID {modifiedItem.Id} not found.");

        dbSet.Entry(existingEntity).CurrentValues.SetValues(modifiedItem);

        return existingEntity;
    }
}
