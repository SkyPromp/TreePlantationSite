using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Context;
using AP.BTP.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AP.BTP.Unittests.TaskItem
{
    [TestClass]
    public class TaskItemRepositoryTests
    {
        private DbContextOptions<BTPContext> _options;


        [TestInitialize]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<BTPContext>()
           .UseInMemoryDatabase("TestDb")
           .Options;

        }

        [TestMethod]
        public async Task When_TaskItem_Is_Disabled_Do_Not_Return_It_With_GetAll()
        {
            this._options = new DbContextOptionsBuilder<BTPContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (BTPContext context = new BTPContext(_options))
            {
                DbSet<Domain.TaskItem> dbSet = context.Set<Domain.TaskItem>();
                DbSet<Domain.TaskList> dbSetTaskList = context.Set<Domain.TaskList>();
                DbSet<Domain.User> dbSetUser = context.Set<Domain.User>();

                Domain.User user = new Domain.User() { Auth0Id="" };

                context.SaveChanges();

                Domain.TaskList taskList = new Domain.TaskList() { Date=DateTime.Now, User=user, UserId=user.Id };

                context.SaveChanges();

                dbSet.Add(new Domain.TaskItem() { Description="", TaskList=taskList, TaskListId=taskList.Id, Title="" });
                dbSet.Add(new Domain.TaskItem() { Description="", TaskList=taskList, TaskListId=taskList.Id, Title="", IsDeleted=true });

                context.SaveChanges();
            }

            using (BTPContext context = new BTPContext(_options))
            {
                ITaskItemRepository taskItemRepo = new TaskItemRepository(context);

                IEnumerable<Domain.TaskItem> result = await taskItemRepo.GetAll();

                Assert.AreEqual(1, result.Count());
            }
        }

        [TestMethod]
        public async Task When_TaskItem_Is_Disabled_Do_Not_Return_It_With_GetById()
        {
            this._options = new DbContextOptionsBuilder<BTPContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            int taskItemId = 0;

            using (BTPContext context = new BTPContext(_options))
            {
                DbSet<Domain.TaskItem> dbSet = context.Set<Domain.TaskItem>();
                DbSet<Domain.TaskList> dbSetTaskList = context.Set<Domain.TaskList>();
                DbSet<Domain.User> dbSetUser = context.Set<Domain.User>();

                Domain.User user = new Domain.User() { Auth0Id="" };

                context.SaveChanges();

                Domain.TaskList taskList = new Domain.TaskList() { Date=DateTime.Now, User=user, UserId=user.Id };

                context.SaveChanges();

                Domain.TaskItem taskItem = new Domain.TaskItem() { Description = "", TaskList = taskList, TaskListId = taskList.Id, Title = "", IsDeleted = true };

                dbSet.Add(taskItem);

                context.SaveChanges();

                taskItemId = taskItem.Id;
            }

            using (BTPContext context = new BTPContext(_options))
            {
                ITaskItemRepository taskItemRepo = new TaskItemRepository(context);

                Domain.TaskItem? result = await taskItemRepo.GetById(taskItemId);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task When_TaskItem_Is_Not_Disabled_Do_Return_It_With_GetById()
        {
            this._options = new DbContextOptionsBuilder<BTPContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            int taskItemId = 0;

            using (BTPContext context = new BTPContext(_options))
            {
                DbSet<Domain.TaskItem> dbSet = context.Set<Domain.TaskItem>();
                DbSet<Domain.TaskList> dbSetTaskList = context.Set<Domain.TaskList>();
                DbSet<Domain.User> dbSetUser = context.Set<Domain.User>();

                Domain.User user = new Domain.User() { Auth0Id="" };

                context.SaveChanges();

                Domain.TaskList taskList = new Domain.TaskList() { Date=DateTime.Now, User=user, UserId=user.Id };

                context.SaveChanges();

                Domain.TaskItem taskItem = new Domain.TaskItem() { Description = "", TaskList = taskList, TaskListId = taskList.Id, Title = "" };

                dbSet.Add(taskItem);

                context.SaveChanges();

                taskItemId = taskItem.Id;
            }

            using (BTPContext context = new BTPContext(_options))
            {
                ITaskItemRepository taskItemRepo = new TaskItemRepository(context);

                Domain.TaskItem? result = await taskItemRepo.GetById(taskItemId);

                Assert.IsNotNull(result);
            }
        }
    }
}
