using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Infrastructure.Repositories
{
    public class TreePictureRepository : ITreePictureRepository
    {
        private readonly DbSet<TreePicture> dbSet;

        public TreePictureRepository(BTPContext context)
        {
            dbSet = context.Set<TreePicture>();
        }

        public async Task<TreePicture> Create(TreePicture item)
        {
            await dbSet.AddAsync(item);
            return item;
        }

        public void Delete(TreePicture item)
        {
            item.IsDeleted = true;
            dbSet.Update(item);
        }

        public Task<IEnumerable<TreePicture>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<TreePicture?> GetById(int id)
        {
            TreePicture? treePicture = await dbSet.FindAsync(id);

            return (treePicture?.IsDeleted ?? true) ? null : treePicture;
        }

        public async Task<ICollection<TreePicture>> GetAllByTreeId(int treeId)
        {
            return await dbSet
                .Where(tp => tp.TreeId == treeId && tp.IsDeleted != true)
                .ToListAsync();        
        }

        public TreePicture Update(TreePicture modifiedItem)
        {
            TreePicture? existingEntity = dbSet.Find(modifiedItem.Id);

            if (existingEntity == null) throw new KeyNotFoundException($"TreePicture with ID {modifiedItem.Id} not found.");

            dbSet.Entry(existingEntity).CurrentValues.SetValues(modifiedItem);

            return existingEntity;
        }
    }
}