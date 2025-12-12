using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="Tree"/> entities in the database.
    /// Implements <see cref="ITreeRepository"/>.
    /// </summary>
    public class TreeRepository : ITreeRepository
    {
        private readonly DbSet<Tree> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeRepository"/> class.
        /// </summary>
        /// <param name="context">The <see cref="BtpContext"/> used to access the database.</param>
        public TreeRepository(BtpContext context)
        {
            this.dbSet = context.Set<Tree>();
        }

        /// <summary>
        /// Creates a new <see cref="Tree"/> in the database.
        /// </summary>
        /// <param name="tree">The <see cref="Tree"/> entity to create.</param>
        /// <returns>The created <see cref="Tree"/> entity.</returns>
        public async Task<Tree> Create(Tree tree)
        {
            await this.dbSet.AddAsync(tree);

            return tree;
        }

        /// <summary>
        /// Soft-deletes the specified <see cref="Tree"/> by setting <see cref="Tree.IsDeleted"/> to <c>true</c>.
        /// </summary>
        /// <param name="item">The <see cref="Tree"/> to soft-delete.</param>
        public void Delete(Tree item)
        {
            item.IsDeleted = true;
            this.dbSet.Update(item);
        }

        /// <summary>
        /// Soft-deletes a <see cref="Tree"/> by its ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Tree"/> to soft-delete.</param>
        public async Task Delete(int id)
        {
            Tree? tree = await this.dbSet.FindAsync(id);

            if (tree != null) Delete(tree);
        }

        /// <summary>
        /// Permanently deletes the specified <see cref="Tree"/> from the database.
        /// </summary>
        /// <param name="item">The <see cref="Tree"/> to delete.</param>
        public async Task HardDelete(Tree item)
        {
            await this.HardDelete(item.Id);
        }

        /// <summary>
        /// Permanently deletes a <see cref="Tree"/> from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Tree"/> to delete.</param>
        public async Task HardDelete(int id)
        {
            await this.dbSet.Where(t => t.Id == id).ExecuteDeleteAsync();
        }

        /// <summary>
        /// Retrieves all <see cref="Tree"/> entities that are not soft-deleted.
        /// <param name="search">Optional search string to filter by species name.</param>
        /// </summary>
        public async Task<IEnumerable<Tree>> GetAll()
        {
            return await this.dbSet
                .Where(tree => !tree.IsDeleted)
                .OrderBy(tree => tree.Species).ToListAsync();
        }

        /// <summary>
        /// Retrieves all <see cref="Tree"/> entities that are not soft-deleted.
        /// <param name="search">Optional search string to filter by species name.</param>
        /// </summary>
        public async Task<IEnumerable<Tree>> GetAll(string? search)
        {
            return await this.dbSet
                .Where(tree => !tree.IsDeleted)
                .Where(tree => string.IsNullOrWhiteSpace(search) || EF.Functions.Like(tree.Species, $"%{search}%"))
                .OrderBy(tree => tree.Species).ToListAsync();
        }

        /// <summary>
        /// Retrieves a paged list of <see cref="Tree"/> entities, optionally filtered by species name.
        /// </summary>
        /// <param name="pageNr">The page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">Optional search string to filter by species name.</param>
        /// <param name="sortAscending">An optional sorting bool to sort trees by species.</param>
        /// <returns>A tuple containing the collection of <see cref="Tree"/> items and the total count.</returns>        
        public async Task<(IEnumerable<Tree> Items, int totalCount)> GetAllPaged(int pageNr, int pageSize, string? search, bool sortAscending)
        {
            IQueryable<Tree> query = dbSet
                .Where(tree => !tree.IsDeleted)
                .Where(tree => string.IsNullOrEmpty(search) || EF.Functions.Like(tree.Species, $"%{search}%"));

            query = sortAscending
                ? query.OrderBy(tree => tree.Species)
                : query.OrderByDescending(tree => tree.Species);

            int totalCount = await query.CountAsync();

            List<Tree> items = await query
                                .Skip((pageNr - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return (items, totalCount);
        }

        /// <summary>
        /// Retrieves a <see cref="Tree"/> by its ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Tree"/>.</param>
        /// <returns>The <see cref="Tree"/> entity if found and not soft-deleted; otherwise, <c>null</c>.</returns>
        public async Task<Tree?> GetById(int id)
        {
            Tree? tree = await this.dbSet.FindAsync(id);

            return (tree?.IsDeleted ?? true) ? null : tree;
        }

        /// <summary>
        /// Updates an existing <see cref="Tree"/> entity in the database.
        /// </summary>
        /// <param name="modifiedItem">The modified <see cref="Tree"/> entity.</param>
        /// <returns>The updated <see cref="Tree"/> entity.</returns>
        public Tree Update(Tree modifiedItem)
        {
            Tree? existingEntity = dbSet.Find(modifiedItem.Id);

            if (existingEntity == null) throw new KeyNotFoundException($"Tree with ID {modifiedItem.Id} not found.");

            dbSet.Entry(existingEntity).CurrentValues.SetValues(modifiedItem);

            return existingEntity;
        }
    }
}
