using System.Collections.ObjectModel;
using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    /// <summary>
    /// Provides extension methods to seed <see cref="Tree"/> entities into the database.
    /// </summary>
    public static class TreeSeeding
    {
        /// <summary>
        /// Seeds the <see cref="Tree"/> entity with 50 sample records.
        /// </summary>
        /// <param name="builder">
        /// The <see cref="EntityTypeBuilder{Tree}"/> used to configure the <see cref="Tree"/> entity.
        /// </param>
        /// <remarks>
        /// Each seeded <see cref="Tree"/> entity will have:
        /// <list type="bullet">
        /// <item><description>An <see cref="Tree.Id"/> from 1 to 50.</description></item>
        /// <item><description>A unique <see cref="Tree.Species"/> name, e.g., "Tree 1", "Tree 2", etc.</description></item>
        /// <item><description>Empty strings for all seasonal <see cref="Tree.MaintenancePlan"/> fields (<see cref="Tree.MaintenancePlanSpring"/>, <see cref="Tree.MaintenancePlanSummer"/>, <see cref="Tree.MaintenancePlanAutumn"/>, <see cref="Tree.MaintenancePlanWinter"/>).</description></item>
        /// <item><description><see cref="Tree.IsDeleted"/> set to <c>false</c>.</description></item>
        /// </list>
        /// The method uses <see cref="HasData(IEnumerable{Tree})"/> to insert the data
        /// during database creation or migrations.
        /// </remarks>
        public static void Seed(this EntityTypeBuilder<Tree> builder)
        {
            List<Tree> trees = new List<Tree>();

            for (int i = 1; i <= 50; i++)
            {
                trees.Add(new Tree
                {
                    Id = i,
                    Species = $"Tree {i}",
                    MaintenancePlanSpring = $"",
                    MaintenancePlanSummer = $"",
                    MaintenancePlanAutumn = $"",
                    MaintenancePlanWinter = $"",
                    IsDeleted = false
                });
            }

            builder.HasData(trees);
        }
    }
}