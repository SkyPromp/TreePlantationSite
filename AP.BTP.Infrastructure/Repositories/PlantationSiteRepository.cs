using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


/// <summary>
/// Repository for managing <see cref="PlantationSite"/> entities in the database.
/// Implements <see cref="IPlantationSiteRepository"/>.
/// </summary>
public class PlantationSiteRepository: IPlantationSiteRepository  // TODO: should have a namespace
{
    private readonly DbSet<PlantationSite> dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlantationSiteRepository"/> class.
    /// </summary>
    /// <param name="context">The <see cref="BTPContext"/> used to access the database.</param>
    public PlantationSiteRepository(BTPContext context)
	{
        dbSet = context.Set<PlantationSite>();
	}

    /// <summary>
    /// Creates a new <see cref="PlantationSite"/> in the database.
    /// </summary>
    /// <param name="plantationSite">The <see cref="PlantationSite"/> to create.</param>
    /// <returns>The created <see cref="PlantationSite"/> entity.</returns>
    public async Task<PlantationSite> Create(PlantationSite plantationSite)
    {
        await dbSet.AddAsync(plantationSite);

        return plantationSite;
    }

    /// <summary>
    /// Deletes a <see cref="PlantationSite"/> from the database.
    /// </summary>
    /// <param name="item">The <see cref="PlantationSite"/> to delete.</param>
    public void Delete(PlantationSite item)
    {
        item.IsDeleted = true;
        Update(item);
    }

    /// <summary>
    /// Retrieves all <see cref="PlantationSite"/> entities.
    /// </summary>
    /// <returns>A collection of <see cref="PlantationSite"/> entities.</returns>
    public async Task<IEnumerable<PlantationSite>> GetAll()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves a paginated list of <see cref="PlantationSite"/> entities, optionally filtered by a search string.
    /// </summary>
    /// <param name="pageNr">The page number (1-based).</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="search">An optional search string to filter by <see cref="PlantationSite.Name"/>.</param>
    /// <param name="sortAscending">An optional sorting bool to sort sites by name.</param>
    /// <returns>A tuple containing the collection of <see cref="PlantationSite"/> items and the total count.</returns>
    public async Task<(IEnumerable<PlantationSite> Items, int TotalCount)> GetAllPaged(int pageNr, int pageSize, string search, bool sortAscending)
    {
        IQueryable<PlantationSite> query = dbSet
            .Where(ps => !ps.IsDeleted)
            .AsQueryable();

        query = sortAscending 
            ? query.OrderBy(site => site.Name) 
            : query.OrderByDescending(site => site.Name);            

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

    /// <summary>
    /// Retrieves a list of <see cref="PlantationSite"/> entities, optionally filtered by a search string.
    /// </summary>
    /// <param name="search">An optional search string to filter by <see cref="PlantationSite.Name"/>.</param>
    /// <returns>A List containing the collection of <see cref="PlantationSite"/> items.</returns>
    public async Task<IEnumerable<PlantationSite>> GetAllSearched(string search)
    {
        IQueryable<PlantationSite> query = dbSet
            .Where(ps => !ps.IsDeleted)
            .AsQueryable();

        query = query.OrderBy(site => site.Name);

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();

            query = query.Where(ps =>
                ps.Name.ToLower().Contains(search));
        }

        List<PlantationSite> items = await query
                            .ToListAsync();

        return items;
    }

    /// <summary>
    /// Retrieves a <see cref="PlantationSite"/> by its ID.
    /// </summary>
    /// <param name="id">The ID of the <see cref="PlantationSite"/>.</param>
    /// <returns>The <see cref="PlantationSite"/> with the specified ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified ID is not found or is deleted.</exception>
    public async Task<PlantationSite?> GetById(int id)
    {
        PlantationSite? site = await dbSet
            .Include(p => p.Zones)
            .FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == id);

        if (site == null) throw new KeyNotFoundException($"PlantationSite with ID {id} not found.");

        return site;
    }

    /// <summary>
    /// Updates an existing <see cref="PlantationSite"/> entity in the database.
    /// </summary>
    /// <param name="modifiedItem">The modified <see cref="PlantationSite"/> entity.</param>
    /// <returns>The updated <see cref="PlantationSite"/> entity.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the entity to update is not found.</exception>
    public PlantationSite Update(PlantationSite modifiedItem)
    {
        PlantationSite? existingEntity = dbSet.Find(modifiedItem.Id);

        if (existingEntity == null) throw new KeyNotFoundException($"PlantationSite with ID {modifiedItem.Id} not found.");

        dbSet.Entry(existingEntity).CurrentValues.SetValues(modifiedItem);

        return existingEntity;
    }
}
