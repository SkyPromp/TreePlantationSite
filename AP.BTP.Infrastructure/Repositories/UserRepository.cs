using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.Enums;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="User"/> entities in the database.
    /// Implements <see cref="IUserRepository"/>.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The <see cref="BTPContext"/> used to access the database.</param>
        public UserRepository(BTPContext context)
        {
            this.dbSet = context.Set<User>();
        }

        /// <summary>
        /// Creates a new <see cref="User"/> in the database.
        /// </summary>
        /// <param name="item">The <see cref="User"/> entity to create.</param>
        /// <returns>The created <see cref="User"/> entity.</returns>
        public async Task<User> Create(User item)
        {
            await this.dbSet.AddAsync(item);

            return item;
        }

        /// <summary>
        /// Soft-deletes the specified <see cref="User"/> by setting <see cref="User.IsDeleted"/> to <c>true</c>.
        /// </summary>
        /// <param name="item">The <see cref="User"/> to soft-delete.</param>
        public void Delete(User item)
        {
            item.IsDeleted = true;
            this.dbSet.Update(item);
        }

        /// <summary>
        /// Soft-deletes a <see cref="User"/> by its ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="User"/> to soft-delete.</param>
        public async Task Delete(int id)
        {
            User? user = await this.dbSet.FindAsync(id);

            if (user != null) Delete(user);
        }

        /// <summary>
        /// Retrieves all <see cref="User"/> entities.
        /// </summary>
        /// <returns>A collection of <see cref="User"/> entities.</returns>
        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a paged list of approved <see cref="User"/> entities with optional search filtering.
        /// </summary>
        /// <param name="pageNr">The page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">Optional search string to filter by name or email.</param>
        /// <returns>A tuple containing the paged users and the total count.</returns>
        public async Task<(IEnumerable<User> Items, int TotalCount)> GetAllApprovedPaged(int pageNr, int pageSize, string search)
        {
            IQueryable<User> query = dbSet
                .Include(u => u.PlantationSites)
                .Where(u => !u.IsDeleted && u.IsApproved)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();

                query = query.Where(u =>
                    u.FirstName.ToLower().Contains(search) || u.Email.ToLower().Contains(search));
            }

            int totalCount = await query.CountAsync();

            List<User> items = await query.Skip((pageNr - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return (items, totalCount);
        }

        /// <summary>
        /// Retrieves a paged list of users who are operators (have associated plantation sites) with optional search filtering.
        /// </summary>
        /// <param name="pageNr">The page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">Optional search string to filter by name or email.</param>
        /// <returns>A tuple containing the paged operator users and the total count.</returns>
        public async Task<(IEnumerable<User> Items, int TotalCount)> GetAllOperatorsPaged(int pageNr, int pageSize, string search)
        {
            IQueryable<User> query = dbSet
                .Include(u => u.PlantationSites)
                .Where(u => !u.IsDeleted && u.Role == UserRole.Operator)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();

                query = query.Where(u =>
                    u.FirstName.ToLower().Contains(search) || u.Email.ToLower().Contains(search));
            }

            int totalCount = await query.CountAsync();

            List<User> items = await query.Skip((pageNr - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return (items, totalCount);
        }

        /// <summary>
        /// Retrieves a paged list of unapproved <see cref="User"/> entities with optional search filtering.
        /// </summary>
        /// <param name="pageNr">The page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">Optional search string to filter by name or email.</param>
        /// <returns>A tuple containing the paged users and the total count.</returns>
        public async Task<(IEnumerable<User> Items, int TotalCount)> GetAllUnapprovedUsersPaged(int pageNr, int pageSize, string search)
        {
            IQueryable<User> query = dbSet
                .Where(u => !u.IsDeleted && !u.IsApproved)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();

                query = query.Where(u =>
                    u.FirstName.ToLower().Contains(search) || u.Email.ToLower().Contains(search));
            }

            int totalCount = await query.CountAsync();

            List<User> items = await query.Skip((pageNr - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return (items, totalCount);
        }

        /// <summary>
        /// Retrieves a <see cref="User"/> by its ID, including related plantation sites and task lists.
        /// </summary>
        /// <param name="id">The ID of the <see cref="User"/>.</param>
        /// <returns>The <see cref="User"/> entity if found and not soft-deleted; otherwise, <c>null</c>.</returns>
        public async Task<User?> GetById(int id)
        {
            User? user = await this.dbSet  // TODO read warning
                .Include(u => u.PlantationSites.Where(p => !p.IsDeleted))
                    .ThenInclude(p => p.Zones.Where(z => !z.IsDeleted))
                .Include(u => u.TaskLists.Where(tl => !tl.IsDeleted))
                .FirstOrDefaultAsync(u => u.Id == id);

            return (user?.IsDeleted ?? true) ? null : user;
        }

        /// <summary>
        /// Retrieves a <see cref="User"/> by its Auth0 ID.
        /// </summary>
        /// <param name="Auth0Id">The Auth0 ID of the user.</param>
        /// <returns>The <see cref="User"/> entity if found and not soft-deleted; otherwise, <c>null</c>.</returns>
        public async Task<User?> GetUserByAuth0Id(string Auth0Id)
        {
            User? user = await this.dbSet.Include(u => u.PlantationSites.Where(p => !p.IsDeleted)).FirstOrDefaultAsync(u => u.Auth0Id == Auth0Id);

            return (user?.IsDeleted ?? true) ? null : user;
        }

        /// <summary>
        /// Updates an existing <see cref="User"/> entity in the database.
        /// </summary>
        /// <param name="modifiedItem">The modified <see cref="User"/> entity.</param>
        /// <returns>The updated <see cref="User"/> entity.</returns>
        public User Update(User modifiedItem)
        {
            return this.dbSet.Update(modifiedItem).Entity;
        }
    }
}
