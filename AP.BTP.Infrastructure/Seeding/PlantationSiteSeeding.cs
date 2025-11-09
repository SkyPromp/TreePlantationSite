using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    public static class PlantationSiteSeeding
    {
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
