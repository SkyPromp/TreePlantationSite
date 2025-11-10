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
            item.IsDeleted = true;
            this.dbSet.Update(item);
        }

        public async Task Delete(int id)
        {
            User? user = await this.dbSet.FindAsync(id);

            if (user != null) Delete(user);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<(IEnumerable<User> Items, int TotalCount)> GetAllPaged(int pageNr, int pageSize, string search)
        {
            IQueryable<User> query = dbSet
                .Include(u => u.PlantationSites)
                .Where(u => !u.IsDeleted)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();

                query = query.Where(u =>
                    u.Name.ToLower().Contains(search) || u.Email.ToLower().Contains(search));
            }

            int totalCount = await query.CountAsync();

            List<User> items = await query.Skip((pageNr - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<(IEnumerable<User> Items, int TotalCount)> GetAllOperatorsPaged(int pageNr, int pageSize, string search)
        {
            IQueryable<User> query = dbSet
                .Include(u => u.PlantationSites)
                .Where(u => !u.IsDeleted && u.PlantationSites.Any())
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();

                query = query.Where(u =>
                    u.Name.ToLower().Contains(search) || u.Email.ToLower().Contains(search));
            }

            int totalCount = await query.CountAsync();

            List<User> items = await query.Skip((pageNr - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<User?> GetById(int id)
        {
            User? user = await this.dbSet
                .Include(u => u.PlantationSites.Where(p => !p.IsDeleted))
                    .ThenInclude(p => p.Zones.Where(z => !z.IsDeleted))
                .Include(u => u.TaskLists.Where(tl => !tl.IsDeleted))
                .FirstOrDefaultAsync(u => u.Id == id);

            return (user?.IsDeleted ?? true) ? null : user;
        }

        public async Task<User?> GetUserByAuth0Id(string Auth0Id)
        {
            User? user = await this.dbSet.Include(u => u.PlantationSites.Where(p => !p.IsDeleted)).FirstOrDefaultAsync(u => u.Auth0Id == Auth0Id);

            return (user?.IsDeleted ?? true) ? null : user;
        }

        public User Update(User modifiedItem)
        {
            return this.dbSet.Update(modifiedItem).Entity;
        }
    }
}
