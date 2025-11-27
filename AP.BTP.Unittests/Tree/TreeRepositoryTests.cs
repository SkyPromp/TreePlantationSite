using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Context;
using AP.BTP.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AP.BTP.Unittests.Tree
{
    [TestClass]
    public class TreeRepositoryTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<ITreeRepository> treeRepoMock;
        private GetAllTreeQueryValidator validator;

        private DbContextOptions<BTPContext> _options;


        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            treeRepoMock = new Mock<ITreeRepository>();

            uowMock.Setup(u => u.TreeRepository).Returns(treeRepoMock.Object);

            validator = new GetAllTreeQueryValidator(uowMock.Object);

            _options = new DbContextOptionsBuilder<BTPContext>()
           .UseInMemoryDatabase("TestDb")
           .Options;

        }

        [TestMethod]
        public async Task When_Tree_Is_Disabled_Do_Not_Return_It_With_GetAll()
        {
            this._options = new DbContextOptionsBuilder<BTPContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (BTPContext context = new BTPContext(_options))
            {
                DbSet<Domain.Tree> dbSet = context.Set<Domain.Tree>();

                dbSet.Add(new Domain.Tree() { Species="Oak" });
                dbSet.Add(new Domain.Tree() { Species="Birch", IsDeleted=true });

                context.SaveChanges();
            }

            using (BTPContext context = new BTPContext(_options))
            {
                ITreeRepository treeRepo = new TreeRepository(context);

                IEnumerable<Domain.Tree> result = await treeRepo.GetAll(search:"");

                Assert.AreEqual(1, result.Count());
            }
        }

        [TestMethod]
        public async Task When_Search_Is_Not_Null_Return_Only_Matches()
        {
             this._options = new DbContextOptionsBuilder<BTPContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (BTPContext context = new BTPContext(_options))
            {
                DbSet<Domain.Tree> dbSet = context.Set<Domain.Tree>();

                dbSet.Add(new Domain.Tree() { Species="Oak" });
                dbSet.Add(new Domain.Tree() { Species="Birch" });

                context.SaveChanges();
            }

            using (BTPContext context = new BTPContext(_options))
            {
                ITreeRepository treeRepo = new TreeRepository(context);

                IEnumerable<Domain.Tree> result = await treeRepo.GetAll(search:"o");

                Assert.AreEqual(1, result.Count());
            }
        }

        [TestMethod]
        public async Task When_Tree_Is_Disabled_Do_Not_Return_It_With_GetById()
        {
             this._options = new DbContextOptionsBuilder<BTPContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            int treeId = 0;

            using (BTPContext context = new BTPContext(_options))
            {
                DbSet<Domain.Tree> dbSet = context.Set<Domain.Tree>();

                Domain.Tree tree = new Domain.Tree() { Species = "Birch", IsDeleted = true };

                dbSet.Add(tree);
                context.SaveChanges();

                treeId = tree.Id;
            }

            using (BTPContext context = new BTPContext(_options))
            {
                ITreeRepository treeRepo = new TreeRepository(context);

                Domain.Tree? result = await treeRepo.GetById(treeId);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task When_Tree_Is_Not_Disabled_Do_Return_It_With_GetById()
        {
             this._options = new DbContextOptionsBuilder<BTPContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            int treeId = 0;

            using (BTPContext context = new BTPContext(_options))
            {
                DbSet<Domain.Tree> dbSet = context.Set<Domain.Tree>();

                Domain.Tree tree = new Domain.Tree() { Species = "Birch" };

                dbSet.Add(tree);
                context.SaveChanges();

                treeId = tree.Id;
            }

            using (BTPContext context = new BTPContext(_options))
            {
                ITreeRepository treeRepo = new TreeRepository(context);

                Domain.Tree? result = await treeRepo.GetById(treeId);

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task When_GetAllPages_Size_Is_Correct()
        {
             this._options = new DbContextOptionsBuilder<BTPContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            const int totalTrees = 10;
            const int pageSize = 6;

            using (BTPContext context = new BTPContext(_options))
            {
                DbSet<Domain.Tree> dbSet = context.Set<Domain.Tree>();

                for(int i = 0; i < totalTrees; i++) dbSet.Add(new Domain.Tree() { Species=$"Tree {i}" });

                context.SaveChanges();
            }

            using (BTPContext context = new BTPContext(_options))
            {
                ITreeRepository treeRepo = new TreeRepository(context);

                (IEnumerable<Domain.Tree> Items, int totalCount) = await treeRepo.GetAllPaged(pageNr:1, pageSize:pageSize, search:null, sortAscending:false);

                Assert.AreEqual(totalCount, totalTrees);
                Assert.AreEqual(Items.Count(), pageSize);
            }
        }

        [TestMethod]
        public async Task When_GetAllPages_Size_Is_Correct_On_Last_Page()
        {
             this._options = new DbContextOptionsBuilder<BTPContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            const int totalTrees = 10;
            const int pageSize = 6;
            const int pageNr = 2;

            using (BTPContext context = new BTPContext(_options))
            {
                DbSet<Domain.Tree> dbSet = context.Set<Domain.Tree>();

                for(int i = 0; i < totalTrees; i++) dbSet.Add(new Domain.Tree() { Species=$"Tree {i}" });

                context.SaveChanges();
            }

            using (BTPContext context = new BTPContext(_options))
            {
                ITreeRepository treeRepo = new TreeRepository(context);

                (IEnumerable<Domain.Tree> Items, int totalCount) = await treeRepo.GetAllPaged(pageNr:pageNr, pageSize:pageSize, search:null, sortAscending:false);

                Assert.AreEqual(totalCount, totalTrees);
                Assert.AreEqual(Items.Count(), 4);
            }
        }
    }
}
