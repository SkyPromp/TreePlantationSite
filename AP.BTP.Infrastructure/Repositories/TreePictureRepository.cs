using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="TreePicture"/> entities in the database.
    /// Implements <see cref="ITreePictureRepository"/>.
    /// </summary>
    public class TreePictureRepository : ITreePictureRepository
    {
        private readonly DbSet<TreePicture> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreePictureRepository"/> class.
        /// </summary>
        /// <param name="context">The database context used for accessing <see cref="TreePicture"/> entities.</param>
        public TreePictureRepository(BTPContext context)
        {
            dbSet = context.Set<TreePicture>();
        }

        /// <summary>
        /// Adds a new <see cref="TreePicture"/> to the database.
        /// </summary>
        /// <param name="item">The tree picture to create.</param>
        /// <returns>The created <see cref="TreePicture"/> entity.</returns>
        public async Task<TreePicture> Create(TreePicture item)
        {
            await dbSet.AddAsync(item);
            return item;
        }

        /// <summary>
        /// Marks an existing <see cref="TreePicture"/> as deleted (soft delete).
        /// </summary>
        /// <param name="item">The tree picture to delete.</param>
        public void Delete(TreePicture item)
        {
            item.IsDeleted = true;
            dbSet.Update(item);
        }

        /// <summary>
        /// Gets all <see cref="TreePicture"/> entities.
        /// </summary>
        /// <returns>An enumerable of all tree pictures.</returns>
        /// <remarks>This method is not implemented.</remarks>
        public Task<IEnumerable<TreePicture>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a <see cref="TreePicture"/> by its ID, excluding deleted entities.
        /// </summary>
        /// <param name="id">The ID of the tree picture.</param>
        /// <returns>The tree picture if found and not deleted; otherwise, <c>null</c>.</returns>
        public async Task<TreePicture?> GetById(int id)
        {
            TreePicture? treePicture = await dbSet.FindAsync(id);

            return (treePicture?.IsDeleted ?? true) ? null : treePicture;
        }

        /// <summary>
        /// Retrieves all <see cref="TreePicture"/> entities associated with a specific tree ID, excluding deleted entities.
        /// </summary>
        /// <param name="treeId">The ID of the tree.</param>
        /// <returns>A collection of tree pictures for the given tree.</returns>
        public async Task<ICollection<TreePicture>> GetAllByTreeId(int treeId)
        {
            return await dbSet
                .Where(tp => tp.TreeId == treeId && tp.IsDeleted != true)
                .ToListAsync();        
        }

        /// <summary>
        /// Updates an existing <see cref="TreePicture"/> entity in the database.
        /// </summary>
        /// <param name="modifiedItem">The tree picture containing updated values.</param>
        /// <returns>The updated <see cref="TreePicture"/> entity.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified ID does not exist.</exception>
        public TreePicture Update(TreePicture modifiedItem)
        {
            TreePicture? existingEntity = dbSet.Find(modifiedItem.Id);

            if (existingEntity == null) throw new KeyNotFoundException($"TreePicture with ID {modifiedItem.Id} not found.");

            dbSet.Entry(existingEntity).CurrentValues.SetValues(modifiedItem);

            return existingEntity;
        }
    }
}