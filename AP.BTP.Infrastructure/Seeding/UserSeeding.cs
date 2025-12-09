using AP.BTP.Contracts.Enums;
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
        /// <item><description>User with Id = 1, Auth0Id = "auth0|user1", FirstName = "Alice", Email = "alice@example.com"</description></item>
        /// <item><description>User with Id = 2, Auth0Id = "auth0|user2", FirstName = "Bob", Email = "bob@example.com"</description></item>
        /// </list>
        /// Both users have <see cref="User.IsDeleted"/> set to <c>false</c>.
        /// Uses <see cref="HasData(IEnumerable{T})"/> to insert data during EF Core migrations or database creation.
        /// </remarks>
        public static void Seed(this EntityTypeBuilder<User> builder)
        {
            List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Auth0Id = "auth0|68f5f3c8fa9e243c35508427",
                    FirstName = "Admin1",
                    LastName = "Lastname",
                    PhoneNumber = "0123456789",
                    Email = "admin123@admin.admin",
                    IsApproved = true,
                    Role = UserRole.Admin,
                    IsDeleted = false,
                },
                new User
                {
                    Id = 2,
                    Auth0Id = "auth0|690db2550eb8c001baeaeb22",
                    FirstName = "Manager1",
                    LastName = "Lastname",
                    PhoneNumber = "0123456789",
                    Email = "manager123@manager.manager",
                    IsApproved = true,
                    Role = UserRole.Manager,
                    IsDeleted = false,
                },
                new User
                {
                    Id = 3,
                    Auth0Id = "auth0|68f7f831f5bc833fc99fca15",
                    FirstName = "Operator1",
                    LastName = "Lastname",
                    PhoneNumber = "0123456789",
                    Email = "operator123@operator.operator",
                    IsApproved = true,
                    Role = UserRole.Operator,
                    IsDeleted = false,
                },
                new User
                {
                    Id = 4,
                    Auth0Id = "auth0|6934b29bb240dfc03ff39189",
                    FirstName = "Karl",
                    LastName = "Ross",
                    PhoneNumber = "0135456865",
                    Email = "karlross@gmail.com",
                    IsApproved = true,
                    Role = UserRole.Operator,
                    IsDeleted = false,
                },
                new User
                {
                    Id = 5,
                    Auth0Id = "auth0|6934b2f91654205a1e8f2152",
                    FirstName = "Bob",
                    LastName = "Ross",
                    PhoneNumber = "0535556913",
                    Email = "bobross@gmail.com",
                    IsApproved = true,
                    Role = UserRole.Operator,
                    IsDeleted = false,
                },
            };

            builder.HasData(users);
        }
    }
}