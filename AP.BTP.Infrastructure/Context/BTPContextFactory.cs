using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AP.BTP.Infrastructure.Context
{
    /// <summary>
    /// Factory class used by Entity Framework Core at design-time to create instances of <see cref="BTPContext"/>.
    /// </summary>
    /// <remarks>
    /// This class is primarily used for design-time services such as migrations. 
    /// It reads the connection string from the environment variable "ConnectionStrings__Default" 
    /// and configures the DbContext to use SQL Server.
    /// </remarks>
    public class BTPContextFactory : IDesignTimeDbContextFactory<BTPContext>
    {
        /// <summary>
        /// Creates a new instance of <see cref="BTPContext"/> with the configuration specified.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        /// <returns>A configured <see cref="BTPContext"/> instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the connection string environment variable is not set.</exception>
        public BTPContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<BTPContext> optionsBuilder = new DbContextOptionsBuilder<BTPContext>();
            string? connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__Default");

            if (string.IsNullOrEmpty(connectionString)) throw new InvalidOperationException("Connection string not set in environment variables.");

            optionsBuilder.UseSqlServer(connectionString);

            return new BTPContext(optionsBuilder.Options);
        }
    }
}
