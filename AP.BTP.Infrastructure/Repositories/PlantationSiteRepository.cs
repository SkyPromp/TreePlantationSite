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
        throw new NotImplementedException();
    }

    public void Delete(PlantationSite item)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PlantationSite>> GetAll(int pageNr, int pageSize)
    {
        return await dbSet.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
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
