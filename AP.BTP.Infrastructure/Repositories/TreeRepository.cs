using AP.BTP.Application.CQRS;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="Tree"/> entities in the database.
    /// Implements <see cref="ITreeRepository"/>.
    /// </summary>
    public class TreeRepository: ITreeRepository
    {
        private readonly DbSet<Tree> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeRepository"/> class.
        /// </summary>
        /// <param name="context">The <see cref="BTPContext"/> used to access the database.</param>
        public TreeRepository(BTPContext context)
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
        /// </summary>
        public async Task<IEnumerable<Tree>> GetAll()
        {
            return await this.dbSet.Where(tree => !tree.IsDeleted).ToListAsync();
        }

        /// <summary>
        /// Retrieves a paged list of <see cref="Tree"/> entities, optionally filtered by species name.
        /// </summary>
        /// <param name="pageNr">The page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">Optional search string to filter by species name.</param>
        /// <returns>A <see cref="Paged{Tree}"/> object containing the requested page of trees.</returns>
        public async Task<Paged<Tree>> GetAll(int pageNr, int pageSize, string? search)
        {
            IQueryable<Tree> trees = this.dbSet
                .Where(tree => !tree.IsDeleted)
                .Where(tree => ((search ?? "") != "") ? tree.Species.ToLower().Contains(search!.ToLower()) : true);  // This is delegated, 1 Where() is less readable than 2

            if (pageSize == 0) pageSize = trees.Count();  //  Avoid divide by 0 exception

            return new Paged<Tree> { PageNr=pageNr, PageSize=pageSize, PageCount=(int)Math.Ceiling(trees.Count() / (double) pageSize), Data = await trees.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync()};
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
            return this.dbSet.Update(modifiedItem).Entity;
        }
    }
}
