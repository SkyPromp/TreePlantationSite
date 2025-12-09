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
        /// Seeds the <see cref="PlantationSite"/> entity with 10 sample records.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="EntityTypeBuilder{TEntity}"/> used to configure the entity.</param>
        /// <remarks>
        /// Each seeded <see cref="PlantationSite"/> will have:
        /// <list type="bullet">
        /// <item><description>An <see cref="PlantationSite.Id"/> from 1 to 100</description></item>
        /// <item><description>Unique <see cref="PlantationSite.Name"/>, <see cref="PlantationSite.Street"/>, <see cref="PlantationSite.HouseNumber"/>, and <see cref="PlantationSite.City"/></description></item>
        /// <item><description>Postal codes incrementing from 1000 to 9999</description></item>
        /// <item><description>Country set to "Belgium"</description></item>
        /// <item><description>Size is in square meters</description></item>
        /// <item><description>GroundPlan set to a unique string per site</description></item>
        /// <item><description>IsDeleted set to <c>false</c></description></item>
        /// </list>
        /// This method uses <see cref="HasData(IEnumerable{T})"/> to insert the data when migrating or creating the database.
        /// </remarks>
        public static void Seed(this EntityTypeBuilder<PlantationSite> modelBuilder)
        {
            List<PlantationSite> sites = new List<PlantationSite>();

            sites.Add(new PlantationSite
            {
                Id = 1,
                Name = "Kwekerij Groenvallei",
                Street = "Beukenlaan",
                HouseNumber = "12",
                City = "Leuven",
                PostalCode = 3000,
                Country = "Belgium",
                Size = 5300.0,
                GroundPlan = "",
                IsDeleted = false,
            });

            sites.Add(new PlantationSite
            {
                Id = 2,
                Name = "Arborium Noordhaven",
                Street = "Noordkaai",
                HouseNumber = "5B",
                City = "Antwerpen",
                PostalCode = 2000,
                Country = "Belgium",
                Size = 7600.0,
                GroundPlan = "",
                IsDeleted = false,
            });

            sites.Add(new PlantationSite
            {
                Id = 3,
                Name = "Boomgaard Zilverbos",
                Street = "Zilverbosstraat",
                HouseNumber = "44",
                City = "Mechelen",
                PostalCode = 2800,
                Country = "Belgium",
                Size = 6900.0,
                GroundPlan = "",
                IsDeleted = false,
            });

            sites.Add(new PlantationSite
            {
                Id = 4,
                Name = "Plantcentrum Vlaanderweide",
                Street = "Vlaanderweideweg",
                HouseNumber = "7A",
                City = "Kortrijk",
                PostalCode = 8500,
                Country = "Belgium",
                Size = 5100.0,
                GroundPlan = "",
                IsDeleted = false,
            });

            sites.Add(new PlantationSite
            {
                Id = 5,
                Name = "Kweeksite Ardennenpark",
                Street = "Ardennenparklaan",
                HouseNumber = "91",
                City = "Marche-en-Famenne",
                PostalCode = 6900,
                Country = "Belgium",
                Size = 14000.0,
                GroundPlan = "",
                IsDeleted = false,
            });

            sites.Add(new PlantationSite
            {
                Id = 6,
                Name = "Arboretum Scheldedreef",
                Street = "Scheldedreef",
                HouseNumber = "3C",
                City = "Gent",
                PostalCode = 9000,
                Country = "Belgium",
                Size = 8700.0,
                GroundPlan = "",
                IsDeleted = false,
            });

            sites.Add(new PlantationSite
            {
                Id = 7,
                Name = "Groenpunt Kempenveld",
                Street = "Kempenveldsteenweg",
                HouseNumber = "28",
                City = "Hasselt",
                PostalCode = 3500,
                Country = "Belgium",
                Size = 6700.0,
                GroundPlan = "",
                IsDeleted = false,
            });

            sites.Add(new PlantationSite
            {
                Id = 8,
                Name = "Boomkwekerij Zonnewoud",
                Street = "Zonnewoudlaan",
                HouseNumber = "16",
                City = "Brugge",
                PostalCode = 8000,
                Country = "Belgium",
                Size = 8400.0,
                GroundPlan = "",
                IsDeleted = false,
            });

            sites.Add(new PlantationSite
            {
                Id = 9,
                Name = "EcoKweek Haspengouw",
                Street = "Haspengouwsebaan",
                HouseNumber = "77",
                City = "Sint-Truiden",
                PostalCode = 3800,
                Country = "Belgium",
                Size = 9200.0,
                GroundPlan = "",
                IsDeleted = false,
            });

            sites.Add(new PlantationSite
            {
                Id = 10,
                Name = "Bosrand Groeihoeve",
                Street = "Bosrandweg",
                HouseNumber = "10D",
                City = "Turnhout",
                PostalCode = 2300,
                Country = "Belgium",
                Size = 12500.0,
                GroundPlan = "",
                IsDeleted = false,
            });

            modelBuilder.HasData(sites);
        }
    }
}
