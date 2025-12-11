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
        /// <param name="context">The <see cref="BtpContext"/> used to access the database.</param>
        public UserRepository(BtpContext context)
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
        /// Retrieves a paged list of approved <see cref="User"/> entities with optional search and sorting.
        /// </summary>
        /// <param name="pageNr">The page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">Optional search string to filter by name, email, phone, or role.</param>
        /// <param name="sortBy">Optional field to sort by.</param>
        /// <param name="sortDirection">Sort direction ("asc" or "desc").</param>
        /// <returns>A tuple containing the paged users and the total count.</returns>
        public async Task<(IEnumerable<User> Items, int TotalCount)> GetAllApprovedPaged(
            int pageNr,
            int pageSize,
            string search,
            string? sortBy,
            string? sortDirection)
        {
            IQueryable<User> query = BuildApprovedUsersQuery();

            query = ApplySearchFilter(query, search);
            query = ApplySorting(query, sortBy, sortDirection);

            return await ExecutePagedQuery(query, pageNr, pageSize);
        }

        /// <summary>
        /// Builds the base query for approved and non-deleted users,
        /// including non-deleted plantation sites.
        /// </summary>
        private IQueryable<User> BuildApprovedUsersQuery()
        {
            return dbSet
                .Include(u => u.PlantationSites.Where(site => !site.IsDeleted))
                .Where(u => !u.IsDeleted && u.IsApproved)
                .AsQueryable();
        }


        /// <summary>
        /// Retrieves a paged list of users who are operators 
        /// (have associated plantation sites) with optional search and sorting.
        /// </summary>
        /// <param name="pageNr">The page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">Optional search term.</param>
        /// <param name="sortBy">Field to sort by.</param>
        /// <param name="sortDirection">"asc" or "desc".</param>
        public async Task<(IEnumerable<User> Items, int TotalCount)> GetAllOperatorsPaged(
            int pageNr,
            int pageSize,
            string search,
            string? sortBy,
            string? sortDirection)
        {
            IQueryable<User> query = BuildOperatorsQuery();

            query = ApplySearchFilter(query, search);
            query = ApplySorting(query, sortBy, sortDirection);

            return await ExecutePagedQuery(query, pageNr, pageSize);
        }

        /// <summary>
        /// Retrieves a paged list of unapproved <see cref="User"/> entities 
        /// with optional search and sorting.
        /// </summary>
        /// <param name="pageNr">The page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="search">Optional search filter.</param>
        /// <param name="sortBy">Field to sort by.</param>
        /// <param name="sortDirection">"asc" or "desc".</param>
        public async Task<(IEnumerable<User> Items, int TotalCount)> GetAllUnapprovedUsersPaged(
            int pageNr,
            int pageSize,
            string search,
            string? sortBy,
            string? sortDirection)
        {
            IQueryable<User> query = BuildUnapprovedUsersQuery();

            query = ApplySearchFilter(query, search);
            query = ApplySorting(query, sortBy, sortDirection);

            return await ExecutePagedQuery(query, pageNr, pageSize);
        }

        /// <summary>
        /// Builds the base query for operator users with active plantation sites.
        /// </summary>
        private IQueryable<User> BuildOperatorsQuery()
        {
            return dbSet
                .Include(u => u.PlantationSites.Where(site => !site.IsDeleted))
                .Where(u => !u.IsDeleted && u.Role == UserRole.Operator)
                .AsQueryable();
        }

        /// <summary>
        /// Builds the base query for unapproved users.
        /// </summary>
        private IQueryable<User> BuildUnapprovedUsersQuery()
        {
            return dbSet
                .Where(u => !u.IsDeleted && !u.IsApproved)
                .AsQueryable();
        }

        /// <summary>
        /// Applies a search filter to the provided user query.
        /// </summary>
        /// <param name="query">The initial query.</param>
        /// <param name="search">The search keyword.</param>
        /// <returns>The filtered query.</returns>
        private static IQueryable<User> ApplySearchFilter(IQueryable<User> query, string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return query;

            search = search.ToLower();

            return query.Where(u =>
                EF.Functions.Like(u.FirstName, $"%{search}%") ||
                EF.Functions.Like(u.LastName, $"%{search}%") ||
                EF.Functions.Like(u.Email, $"%{search}%") ||
                EF.Functions.Like(u.PhoneNumber, $"%{search}%") ||
                (u.Role != null && EF.Functions.Like(u.Role.ToString(), $"%{search}%"))
            );
        }

        /// <summary>
        /// Applies sorting to a user query.
        /// </summary>
        /// <param name="query">The current query.</param>
        /// <param name="sortBy">The field to sort on.</param>
        /// <param name="sortDirection">The sort direction ("asc"/"desc").</param>
        /// <returns>The sorted query.</returns>
        private  static IQueryable<User> ApplySorting(
            IQueryable<User> query,
            string? sortBy,
            string? sortDirection)
        {
            if (string.IsNullOrWhiteSpace(sortBy))
                return query.OrderBy(u => u.FirstName);

            bool ascending = sortDirection?.ToLower() != "desc";

            return sortBy.ToLower() switch
            {
                "firstname" => ascending ? query.OrderBy(u => u.FirstName) : query.OrderByDescending(u => u.FirstName),
                "email" => ascending ? query.OrderBy(u => u.Email) : query.OrderByDescending(u => u.Email),
                "phonenumber" => ascending ? query.OrderBy(u => u.PhoneNumber) : query.OrderByDescending(u => u.PhoneNumber),
                "role" => ascending ? query.OrderBy(u => u.Role) : query.OrderByDescending(u => u.Role),
                _ => query.OrderBy(u => u.FirstName)
            };
        }

        /// <summary>
        /// Executes a paged query by applying Skip/Take and retrieving the total count.
        /// </summary>
        /// <param name="query">The query to paginate.</param>
        /// <param name="pageNr">The page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>Paged items and the total count.</returns>
        private static async Task<(IEnumerable<User> Items, int TotalCount)> ExecutePagedQuery(
            IQueryable<User> query,
            int pageNr,
            int pageSize)
        {
            int totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNr - 1) * pageSize)
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
        /// Retrieves a <see cref="User"/> by its Auth0 ID.
        /// </summary>
        /// <param name="Auth0Id">The Auth0 ID of the user.</param>
        /// <returns>The <see cref="User"/> entity if found; otherwise, <c>null</c>.</returns>
        public async Task<User?> GetUserByAuth0IdIncludingDeleted(string Auth0Id)
        {
            return await this.dbSet.FirstOrDefaultAsync(u => u.Auth0Id == Auth0Id);
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
