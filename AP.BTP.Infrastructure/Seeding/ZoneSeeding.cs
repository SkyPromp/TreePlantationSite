using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    /// <summary>
    /// Provides extension methods to seed <see cref="Zone"/> entities into the database.
    /// </summary>
    public static class ZoneSeeding
    {
        /// <summary>
        /// Seeds the <see cref="Zone"/> entity with some sample records.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="EntityTypeBuilder{TEntity}"/> used to configure the entity.</param>
        /// <remarks>
        /// Each seeded <see cref="Zone"/> will have:
        /// <list type="bullet">
        /// </list>
        /// This method uses <see cref="HasData(IEnumerable{T})"/> to insert the data when migrating or creating the database.
        /// </remarks>
        public static void Seed(this EntityTypeBuilder<Zone> modelBuilder)
        {
            Random random = new Random(1);
            List<Zone> zones = new List<Zone>();

            int totalZonesAmount = 0;
            string[] zoneLabels = {"A", "B", "C"};

            for(int plantationSiteId = 1; plantationSiteId <= 10; plantationSiteId++)
            {
                int zonesAmount = random.Next(11, 15);

                for(int zoneId = 1; zoneId <= zonesAmount; zoneId++)
                {
                    zones.Add(new Zone() { Id = ++totalZonesAmount, Name = $"Zone {1 + zoneId / zoneLabels.Length}{zoneLabels[(zoneId - 1) % zoneLabels.Length]}", PlantationSiteId = plantationSiteId, TreeId = random.Next(1, 280), Size = random.Next(80, 333), IsDeleted = false });
                }
            }

            modelBuilder.HasData(zones);
        }
    }
}
