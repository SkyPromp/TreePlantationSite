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
            this.Delete(item.Id);
        }

        public void Delete(int id)
        {
            this.dbSet.Where(t => t.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Tree>> GetAll()
        {
            return await this.dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Tree>> GetAll(int pageNr, int pageSize)
        {
            return await this.dbSet.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Tree?> GetById(int id)
        {
            return await this.dbSet.FindAsync(id);
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
