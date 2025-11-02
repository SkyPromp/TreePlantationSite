using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> dbSet;

        public UserRepository(BTPContext context)
        {
            this.dbSet = context.Set<User>();
        }
        public async Task<User> Create(User item)
        {
            await this.dbSet.AddAsync(item);

            return item;
        }

        public void Delete(User item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUserByAuth0Id(string Auth0Id)
        {
            User? user = await this.dbSet.Include(u => u.PlantationSites).FirstOrDefaultAsync(u => u.Auth0Id == Auth0Id);

            return (user?.IsDeleted ?? true) ? null : user;
        }

        public User Update(User modifiedItem)
        {
            return this.dbSet.Update(modifiedItem).Entity;
        }
    }
}
