using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    public static class PlantationSiteSeeding
    {
        public static void Seed(this EntityTypeBuilder<PlantationSite> modelBuilder)
        {
            List<PlantationSite> sites = new List<PlantationSite>();


            for (int i = 0; i < 11; i++)
            {
                sites.Add(new PlantationSite
                {
                    Id = -(i + 1),
                    Name = $"Site {i}",
                    Street = $"Street Site {i}",
                    HouseNumber = i,
                    City = $"City Site {i}",
                    PostalCode = 1000 + i,
                    Country = "Belgium",
                    GroundPlan = $"Groundplan Site {i}"
                });
            }
            
            modelBuilder.HasData(sites);
        }
    }
}
