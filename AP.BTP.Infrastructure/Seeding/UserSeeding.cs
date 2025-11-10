using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    /// <summary>
    /// Provides extension methods to seed <see cref="User"/> entities into the database.
    /// </summary>
    public static class UserSeeding
    {
        /// <summary>
        /// Seeds the <see cref="User"/> entity with initial sample data.
        /// </summary>
        /// <param name="builder">The <see cref="EntityTypeBuilder{User}"/> used to configure the entity.</param>
        /// <remarks>
        /// This method creates two sample <see cref="User"/> records:
        /// <list type="bullet">
        /// <item><description>User with Id = 1, Auth0Id = "auth0|user1", Name = "Alice", Email = "alice@example.com"</description></item>
        /// <item><description>User with Id = 2, Auth0Id = "auth0|user2", Name = "Bob", Email = "bob@example.com"</description></item>
        /// </list>
        /// Both users have <see cref="User.IsDeleted"/> set to <c>false</c>.
        /// Uses <see cref="HasData(IEnumerable{T})"/> to insert data during EF Core migrations or database creation.
        /// </remarks>
        public static void Seed(this EntityTypeBuilder<User> builder)
        {
            List<User> users = new List<User>
            {
                new User { Id = 1, Auth0Id = "auth0|user1", Name = "Alice", Email = "alice@example.com", IsDeleted = false },
                new User { Id = 2, Auth0Id = "auth0|user2", Name = "Bob", Email = "bob@example.com", IsDeleted = false }
            };

            builder.HasData(users);
        }
    }
}