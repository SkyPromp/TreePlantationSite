using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    /// <summary>
    /// Provides extension methods to seed <see cref="PlantationSite"/> entities into the database.
    /// </summary>
    public static class PlantationSiteSeeding
    {
        /// <summary>
        /// Seeds the <see cref="PlantationSite"/> entity with 100 sample records.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="EntityTypeBuilder{TEntity}"/> used to configure the entity.</param>
        /// <remarks>
        /// Each seeded <see cref="PlantationSite"/> will have:
        /// <list type="bullet">
        /// <item><description>An <see cref="PlantationSite.Id"/> from 1 to 100</description></item>
        /// <item><description>Unique <see cref="PlantationSite.Name"/>, <see cref="PlantationSite.Street"/>, <see cref="PlantationSite.HouseNumber"/>, and <see cref="PlantationSite.City"/></description></item>
        /// <item><description>Postal codes incrementing from 1001 to 1100</description></item>
        /// <item><description>Country set to "Belgium"</description></item>
        /// <item><description>Size set to 200.0</description></item>
        /// <item><description>GroundPlan set to a unique string per site</description></item>
        /// <item><description>IsDeleted set to <c>false</c></description></item>
        /// </list>
        /// This method uses <see cref="HasData(IEnumerable{T})"/> to insert the data when migrating or creating the database.
        /// </remarks>
        public static void Seed(this EntityTypeBuilder<PlantationSite> modelBuilder)
        {
            List<PlantationSite> sites = new List<PlantationSite>();


            for (int i = 1; i <= 100; i++)
            {
                sites.Add(new PlantationSite
                {
                    Id = i,
                    Name = $"Site{i}",
                    Street = $"Street Site{i}",
                    HouseNumber = $"{i}A",
                    City = $"City Site{i}",
                    PostalCode = 1000 + i,
                    Country = "Belgium",
                    Size = 200.0,
                    GroundPlan = $"Groundplan Site{i}",
                    IsDeleted = false,
                });
            }

            modelBuilder.HasData(sites);
        }
    }
}
