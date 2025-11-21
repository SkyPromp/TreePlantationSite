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
        /// <param name="builder">The <see cref="EntityTypeBuilder{TEntity}"/> used to configure the entity.</param>
        /// <remarks>
        /// Each seeded <see cref="Tree"/> will have:
        /// <list type="bullet">
        /// <item><description>An <see cref="Tree.Id"/> from 1 to 50</description></item>
        /// <item><description>Unique <see cref="Tree.Species"/> names</description></item>
        /// <item><description>Unique <see cref="Tree.MaintenancePlan"/> strings</description></item>
        /// <item><description><see cref="Tree.IsDeleted"/> set to <c>false</c></description></item>
        /// </list>
        /// This method uses <see cref="HasData(IEnumerable{T})"/> to insert the data when migrating or creating the database.
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