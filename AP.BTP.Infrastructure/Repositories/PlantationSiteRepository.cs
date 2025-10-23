using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class PlantationSiteRepository: IPlantationSiteRepository
{
    private readonly DbSet<PlantationSite> dbSet;

	public PlantationSiteRepository(BTPContext context)
	{
        this.dbSet = context.Set<PlantationSite>();
	}

    public async Task<PlantationSite> Create(PlantationSite plantationSite)
    {
        await dbSet.AddAsync(plantationSite);
        return plantationSite;
        // FIXME does ef core auto remap plantationSite to the saved entity (for ID)
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
        var query = dbSet.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();

            query = query.Where(ps =>
                ps.Name.ToLower().Contains(search));
        }

        var totalCount = await query.CountAsync();

        var items = await query.Skip((pageNr - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();
                            
        return (items, totalCount);
    }

    public async Task<PlantationSite> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public PlantationSite Update(PlantationSite modifiedItem)
    {
        throw new NotImplementedException();
    }
}
