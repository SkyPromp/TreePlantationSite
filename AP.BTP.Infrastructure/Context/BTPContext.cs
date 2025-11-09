using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Seeding;

namespace AP.BTP.Infrastructure.Context
{
    public class BTPContext : DbContext
    {
        public BTPContext(DbContextOptions<BTPContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Tree>();
            modelBuilder.Entity<PlantationSite>().Seed();
            modelBuilder.Entity<Zone>();
            modelBuilder.Entity<User>().Seed();
            modelBuilder.Entity<TaskList>().Seed();
            modelBuilder.Entity<TaskItem>().Seed();
        }
    }
}
