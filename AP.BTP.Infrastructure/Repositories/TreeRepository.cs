using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Infrastructure.Repositories
{
    public class TreeRepository: ITreeRepository
    {
        private readonly DbSet<Tree> dbSet;

        public TreeRepository(BTPContext context)
        {
            this.dbSet = context.Set<Tree>();
        }

        public async Task<Tree> Create(Tree tree)
        {
            await this.dbSet.AddAsync(tree);

            return tree;
        }

        public void Delete(Tree item)
        {
            item.IsDeleted = true;
            this.dbSet.Update(item);
        }

        public async void Delete(int id)
        {
            Tree? tree = await this.dbSet.FindAsync(id);

            if (tree != null) Delete(tree);
        }

        public void HardDelete(Tree item)
        {
            this.HardDelete(item.Id);
        }

        public void HardDelete(int id)
        {
            this.dbSet.Where(t => t.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Tree>> GetAll()
        {
            return await this.dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Tree>> GetAll(int pageNr, int pageSize)
        {
            return await this.dbSet.Where(tree => !tree.IsDeleted).Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Tree?> GetById(int id)
        {
            Tree? tree = await this.dbSet.FindAsync(id);

            return (tree?.IsDeleted ?? true) ? null : tree;
        }

        public Tree Update(Tree modifiedItem)
        {
            return this.dbSet.Update(modifiedItem).Entity;
        }

        public async Task<int> GetTotalPages(int pageSize)
        {
            return (int)(await dbSet.CountAsync() / (double)pageSize);
        }
    }
}
