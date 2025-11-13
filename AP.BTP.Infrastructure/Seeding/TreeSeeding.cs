using System.Collections.ObjectModel;
using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    public static class TreeSeeding
    {
        public static void Seed(this EntityTypeBuilder<Tree> builder)
        {
            List<Tree> trees = new List<Tree>();

            for (int i = 1; i <= 50; i++)
            {
                trees.Add(new Tree
                {
                    Id = i,
                    Species = $"Tree {i}",
                    MaintenancePlan = $"Maintenance plan {i}",
                    IsDeleted = false
                });
            }

            builder.HasData(trees);
        }
    }
}