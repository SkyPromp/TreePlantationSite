using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    public static class UserSeeding
    {
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