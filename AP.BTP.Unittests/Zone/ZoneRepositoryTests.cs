using AP.BTP.Infrastructure.Context;
using AP.BTP.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Unittests.Zone
{
    [TestClass]
    public class ZoneRepositoryTests
    {
        private DbContextOptions<BtpContext> _options = null!;


        [TestInitialize]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<BtpContext>()
           .UseInMemoryDatabase("TestDb")
           .Options;

        }

        [TestMethod]
        public async Task When_Zone_Is_Disabled_Do_Not_Return_It_With_GetAll()
        {
            this._options = new DbContextOptionsBuilder<BtpContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (BtpContext context = new BtpContext(_options))
            {
                DbSet<Domain.Zone> dbSet = context.Set<Domain.Zone>();
                DbSet<Domain.PlantationSite> dbSetPlantationSite = context.Set<Domain.PlantationSite>();
                DbSet<Domain.Tree> dbSetTree = context.Set<Domain.Tree>();

                Domain.PlantationSite plantationSite = new Domain.PlantationSite() { City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "" };
                Domain.Tree tree = new Domain.Tree() { Species = "" };

                dbSetPlantationSite.Add(plantationSite);
                dbSetTree.Add(tree);

                context.SaveChanges();

                dbSet.Add(new Domain.Zone() { PlantationSite=plantationSite, Tree=tree });
                dbSet.Add(new Domain.Zone() { PlantationSite=plantationSite, Tree=tree, IsDeleted=true });

                context.SaveChanges();
            }

            using (BtpContext context = new BtpContext(_options))
            {
                ZoneRepository zoneRepo = new ZoneRepository(context);

                IEnumerable<Domain.Zone> result = await zoneRepo.GetAll();

                Assert.AreEqual(1, result.Count());
            }
        }

        [TestMethod]
        public async Task When_Zone_Is_Disabled_Do_Not_Return_It_With_GetById()
        {
             this._options = new DbContextOptionsBuilder<BtpContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            int zoneId = 0;

            using (BtpContext context = new BtpContext(_options))
            {
                DbSet<Domain.Zone> dbSet = context.Set<Domain.Zone>();
                DbSet<Domain.PlantationSite> dbSetPlantationSite = context.Set<Domain.PlantationSite>();
                DbSet<Domain.Tree> dbSetTree = context.Set<Domain.Tree>();

                Domain.PlantationSite plantationSite = new Domain.PlantationSite() { City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "" };
                Domain.Tree tree = new Domain.Tree() { Species = "" };

                dbSetPlantationSite.Add(plantationSite);
                dbSetTree.Add(tree);

                context.SaveChanges();

                Domain.Zone zone = new Domain.Zone() { PlantationSite = plantationSite, Tree = tree, IsDeleted = true };

                dbSet.Add(zone);
                context.SaveChanges();
                zoneId = zone.Id;
            }

            using (BtpContext context = new BtpContext(_options))
            {
                ZoneRepository zoneRepo = new ZoneRepository(context);

                Domain.Zone? result = await zoneRepo.GetById(zoneId);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task When_Zone_Is_Not_Disabled_Do_Return_It_With_GetById()
        {
             this._options = new DbContextOptionsBuilder<BtpContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            int zoneId = 0;

            using (BtpContext context = new BtpContext(_options))
            {
                DbSet<Domain.Zone> dbSet = context.Set<Domain.Zone>();
                DbSet<Domain.PlantationSite> dbSetPlantationSite = context.Set<Domain.PlantationSite>();
                DbSet<Domain.Tree> dbSetTree = context.Set<Domain.Tree>();

                Domain.PlantationSite plantationSite = new Domain.PlantationSite() { City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "" };
                Domain.Tree tree = new Domain.Tree() { Species = "" };

                dbSetPlantationSite.Add(plantationSite);
                dbSetTree.Add(tree);

                context.SaveChanges();

                Domain.Zone zone = new Domain.Zone() { PlantationSite = plantationSite, Tree = tree };

                dbSet.Add(zone);
                context.SaveChanges();
                zoneId = zone.Id;
            }

            using (BtpContext context = new BtpContext(_options))
            {
                ZoneRepository zoneRepo = new ZoneRepository(context);

                Domain.Zone? result = await zoneRepo.GetById(zoneId);

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task When_Zone_Is_Not_Disabled_And_Has_PlantationSiteId_Do_Return_It_With_GetByPlantationSiteId()
        {
             this._options = new DbContextOptionsBuilder<BtpContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            int plantationSiteId = 0;

            using (BtpContext context = new BtpContext(_options))
            {
                DbSet<Domain.Zone> dbSet = context.Set<Domain.Zone>();
                DbSet<Domain.PlantationSite> dbSetPlantationSite = context.Set<Domain.PlantationSite>();
                DbSet<Domain.Tree> dbSetTree = context.Set<Domain.Tree>();

                Domain.PlantationSite plantationSite = new Domain.PlantationSite() { City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "" };
                Domain.PlantationSite plantationSite2 = new Domain.PlantationSite() { City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "" };
                Domain.Tree tree = new Domain.Tree() { Species = "" };

                dbSetPlantationSite.Add(plantationSite);
                dbSetPlantationSite.Add(plantationSite2);
                dbSetTree.Add(tree);

                context.SaveChanges();

                plantationSiteId = plantationSite.Id;

                Domain.Zone zone = new Domain.Zone() { PlantationSite = plantationSite, Tree = tree };
                Domain.Zone zone2 = new Domain.Zone() { PlantationSite = plantationSite, Tree = tree };
                Domain.Zone zone3 = new Domain.Zone() { PlantationSite = plantationSite2, Tree = tree };

                dbSet.Add(zone);
                dbSet.Add(zone2);
                context.SaveChanges();
            }

            using (BtpContext context = new BtpContext(_options))
            {
                ZoneRepository zoneRepo = new ZoneRepository(context);

                ICollection<Domain.Zone> result = await zoneRepo.GetAllByPlantationSiteId(plantationSiteId);

                Assert.AreEqual(2, result.Count);
            }
        }

        [TestMethod]
        public async Task When_GetAll_With_Pages_Size_Is_Correct()
        {
             this._options = new DbContextOptionsBuilder<BtpContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            const int totalItems = 10;
            const int pageSize = 6;

            using (BtpContext context = new BtpContext(_options))
            {
                DbSet<Domain.Zone> dbSet = context.Set<Domain.Zone>();
                DbSet<Domain.PlantationSite> dbSetPlantationSite = context.Set<Domain.PlantationSite>();
                DbSet<Domain.Tree> dbSetTree = context.Set<Domain.Tree>();

                Domain.PlantationSite plantationSite = new Domain.PlantationSite() { City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "" };
                Domain.Tree tree = new Domain.Tree() { Species = "" };

                dbSetPlantationSite.Add(plantationSite);
                dbSetTree.Add(tree);

                context.SaveChanges();

                for (int i = 0; i < totalItems; i++)
                {
                    dbSet.Add(new Domain.Zone() { PlantationSite = plantationSite, Tree = tree });
                }

                context.SaveChanges();
            }

            using (BtpContext context = new BtpContext(_options))
            {
                ZoneRepository zoneRepo = new ZoneRepository(context);

                ICollection<Domain.Zone> result = await zoneRepo.GetAll(pageNr:1, pageSize:pageSize);

                Assert.AreEqual(pageSize, result.Count());
            }
        }

        [TestMethod]
        public async Task When_GetAll_With_Pages_Size_Is_Correct_At_Last_Page()
        {
             this._options = new DbContextOptionsBuilder<BtpContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            const int totalItems = 10;
            const int pageSize = 6;

            using (BtpContext context = new BtpContext(_options))
            {
                DbSet<Domain.Zone> dbSet = context.Set<Domain.Zone>();
                DbSet<Domain.PlantationSite> dbSetPlantationSite = context.Set<Domain.PlantationSite>();
                DbSet<Domain.Tree> dbSetTree = context.Set<Domain.Tree>();

                Domain.PlantationSite plantationSite = new Domain.PlantationSite() { City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "" };
                Domain.Tree tree = new Domain.Tree() { Species = "" };

                dbSetPlantationSite.Add(plantationSite);
                dbSetTree.Add(tree);

                context.SaveChanges();

                for (int i = 0; i < totalItems; i++)
                {
                    dbSet.Add(new Domain.Zone() { PlantationSite = plantationSite, Tree = tree });
                }

                context.SaveChanges();
            }

            using (BtpContext context = new BtpContext(_options))
            {
                ZoneRepository zoneRepo = new ZoneRepository(context);

                ICollection<Domain.Zone> result = await zoneRepo.GetAll(pageNr:2, pageSize:pageSize);

                Assert.AreEqual(4, result.Count());
            }
        }
    }
}
