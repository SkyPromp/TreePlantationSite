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
            await dbSet.AddAsync(tree);

            return tree;
        }

        public void Delete(Tree item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tree>> GetAll(int pageNr, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Tree> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Tree Update(Tree modifiedItem)
        {
            throw new NotImplementedException();
        }
    }
}
