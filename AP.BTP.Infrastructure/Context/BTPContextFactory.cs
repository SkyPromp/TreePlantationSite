using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AP.BTP.Infrastructure.Context
{
    public class BTPContextFactory : IDesignTimeDbContextFactory<BTPContext>
    {
        public BTPContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<BTPContext> optionsBuilder = new DbContextOptionsBuilder<BTPContext>();

            // Read connection string from environment variable
            string? connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__Default");
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string not set in environment variables.");

            optionsBuilder.UseSqlServer(connectionString);

            return new BTPContext(optionsBuilder.Options);
        }
    }
}
