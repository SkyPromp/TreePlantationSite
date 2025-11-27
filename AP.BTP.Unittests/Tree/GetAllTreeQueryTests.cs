using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AP.BTP.Infrastructure.Context;
using AP.BTP.Infrastructure.Repositories;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace AP.BTP.Unittests.Tree
{
    [TestClass]
    public class GetAllTreeQueryTests
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
        public async Task When_Tree_Is_Disabled_Do_Not_Return_It()
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
    }
}
