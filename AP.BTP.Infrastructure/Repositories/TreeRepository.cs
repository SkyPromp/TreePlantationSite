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

        public async Task Delete(int id)
        {
            Tree? tree = await this.dbSet.FindAsync(id);

            if (tree != null) Delete(tree);
        }

        public async Task HardDelete(Tree item)
        {
            await this.HardDelete(item.Id);
        }

        public async Task HardDelete(int id)
        {
            await this.dbSet.Where(t => t.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Tree>> GetAll()
        {
            return await this.dbSet.Where(tree => !tree.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Tree>> GetAll(int pageNr, int pageSize, string? search)
        {
            return await this.dbSet
                .Where(tree => !tree.IsDeleted).Skip((pageNr - 1) * pageSize)
                .Where(tree => ((search ?? "") != "")? tree.Species.ToLower().Contains(search!.ToLower()): true)  // This is delegated, 1 Where() is less readable than 2
                .Take(pageSize)
                .ToListAsync();
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
