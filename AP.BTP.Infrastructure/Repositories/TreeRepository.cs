using AP.BTP.Application.CQRS;
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

        public async Task<Paged<Tree>> GetAll(int pageNr, int pageSize, string? search)
        {
            IQueryable<Tree> trees = this.dbSet
                .Where(tree => !tree.IsDeleted)
                .Where(tree => ((search ?? "") != "") ? tree.Species.ToLower().Contains(search!.ToLower()) : true);  // This is delegated, 1 Where() is less readable than 2

            if (pageSize == 0) pageSize = trees.Count();  //  Avoid divide by 0 exception

            return new Paged<Tree> { PageNr=pageNr, PageSize=pageSize, PageCount=(int)Math.Ceiling(trees.Count() / (double) pageSize), Data = await trees.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync()};
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
    }
}
