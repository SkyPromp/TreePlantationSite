using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Seeding;

namespace AP.BTP.Infrastructure.Context
{
    /// <summary>
    /// Represents the Entity Framework Core database context for the BTP application.
    /// </summary>
    public class BtpContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BtpContext"/> class using the specified options.
        /// </summary>
        /// <param name="options">The options to configure the database context.</param>
        public BtpContext(DbContextOptions<BtpContext> options) : base(options)
        {
        }

        /// <summary>
        /// Configures the entity mappings and seeds initial data into the database.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/> used to configure the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Relations
            modelBuilder.Entity<PlantationSite>()
                .HasMany(p => p.Zones)
                .WithOne(z => z.PlantationSite)
                .HasForeignKey(z => z.PlantationSiteId);

            modelBuilder.Entity<Tree>()
                .HasMany(tp => tp.TreePictures)
                .WithOne(t => t.Tree)
                .HasForeignKey(t => t.TreeId);

            modelBuilder.Entity<TaskList>()
                .HasOne(ps => ps.PlantationSite)
                .WithMany(tl => tl.TaskLists)
                .HasForeignKey(p => p.PlantationSiteId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TaskList>()
                .HasOne(zo => zo.Zone)
                .WithMany(ti => ti.TaskLists)
                .HasForeignKey(zo => zo.ZoneId);

            modelBuilder.Entity<Zone>()
                .HasOne(t => t.Tree)
                .WithMany(z => z.Zones)
                .HasForeignKey(t => t.TreeId);

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            // Seeding
            modelBuilder.Entity<PlantationSite>().Seed();
            modelBuilder.Entity<Tree>().Seed();
            modelBuilder.Entity<Zone>().Seed();
            modelBuilder.Entity<User>().Seed();
            modelBuilder.Entity<TaskList>().Seed();
            modelBuilder.Entity<TaskItem>().Seed();

            modelBuilder.Entity("PlantationSiteUser").HasData(
                new { PlantationSitesId = 1, UsersId = 3 },
                new { PlantationSitesId = 2, UsersId = 3 },
                new { PlantationSitesId = 3, UsersId = 4 },
                new { PlantationSitesId = 4, UsersId = 4 },
                new { PlantationSitesId = 5, UsersId = 5 },
                new { PlantationSitesId = 6, UsersId = 5 }
            );
        }
    }
}
