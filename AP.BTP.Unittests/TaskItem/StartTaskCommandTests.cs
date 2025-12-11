using AP.BTP.Application.CQRS.TaskItem;
using AP.BTP.Application.Exceptions;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using Moq;

namespace AP.BTP.Unittests.TaskItem
{
    [TestClass]
    public class StartTaskCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<ITaskListRepository> taskListRepoMock;
        private Mock<ITaskItemRepository> taskItemRepoMock;
        private IMapper mapper;

        public StartTaskCommandTests()
        {
            uowMock = new Mock<IUnitOfWork>();
            taskListRepoMock = new Mock<ITaskListRepository>();
            taskItemRepoMock = new Mock<ITaskItemRepository>();

            uowMock.Setup(u => u.TaskListRepository).Returns(taskListRepoMock.Object);
            uowMock.Setup(u => u.TaskItemRepository).Returns(taskItemRepoMock.Object);

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.TaskList, TaskListDto>().ReverseMap();
                cfg.CreateMap<Domain.TaskItem, TaskItemDto>().ReverseMap();
            });

            this.mapper = config.CreateMapper();
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Already_Started()
        {
            TaskItemDto taskItem = new TaskItemDto() { Id = 1, Title = "", Description = "", TaskListId = 1, StartTime = DateTime.Now };
            StartTaskCommand command = new StartTaskCommand() { TaskItem=taskItem };
            StartTaskCommandHandler handler = new StartTaskCommandHandler(this.uowMock.Object, this.mapper);

            StartStopTaskFailedException ex = await Assert.ThrowsExceptionAsync<StartStopTaskFailedException>(
                () => handler.Handle(command, CancellationToken.None)
            );

            Assert.AreEqual("TASK_ALREADY_STARTED", ex.ErrorCode);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_EndTime_Is_Not_Null()
        {
            TaskItemDto taskItem = new TaskItemDto() { Id = 1, Title = "", Description = "", TaskListId = 1, EndTime = DateTime.Now };
            StartTaskCommand command = new StartTaskCommand() { TaskItem=taskItem };
            StartTaskCommandHandler handler = new StartTaskCommandHandler(this.uowMock.Object, this.mapper);

            StartStopTaskFailedException ex = await Assert.ThrowsExceptionAsync<StartStopTaskFailedException>(
                () => handler.Handle(command, CancellationToken.None)
            );

            Assert.AreEqual("TASK_INVALID_STATE", ex.ErrorCode);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_TaskList_Is_Null()
        {
            TaskItemDto taskItem = new TaskItemDto() { Id = 1, Title = "", Description = "", TaskListId = 1 };
            this.taskListRepoMock.Setup(r => r.GetByIdUntracked(taskItem.TaskListId)).ReturnsAsync((Domain.TaskList?)null);

            StartTaskCommand command = new StartTaskCommand() { TaskItem=new TaskItemDto() { Id=1, Title="", Description="", TaskListId=1 } };
            StartTaskCommandHandler handler = new StartTaskCommandHandler(this.uowMock.Object, this.mapper);

            NotFoundException ex = await Assert.ThrowsExceptionAsync<NotFoundException>(
                () => handler.Handle(command, CancellationToken.None)
            );

            StringAssert.Contains(ex.Message, "TaskList not found");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Another_Task_Has_Already_Been_Started()
        {
            Domain.User user = new Domain.User() { Id=1, Auth0Id="AUTH" };
            Domain.TaskList taskList = new Domain.TaskList() { Id = 1, Date=DateTime.Now, User=user, UserId=user.Id };
            Domain.TaskItem taskItem1 = new Domain.TaskItem() { Id = 1, Title = "", Description = "", TaskListId = 1, TaskList=taskList };
            Domain.TaskItem taskItem2 = new Domain.TaskItem() { Id = 2, Title = "", Description = "", TaskListId = 1, TaskList=taskList, StartTime=DateTime.Now.AddMicroseconds(-10) };
            taskList.TaskItems = new List<Domain.TaskItem>()
            {
                taskItem1,
                taskItem2
            };

            this.taskListRepoMock.Setup(r => r.GetByIdUntracked(taskList.Id)).ReturnsAsync(taskList);

            StartTaskCommand command = new StartTaskCommand() { TaskItem=new TaskItemDto() { Id=1, Title="", Description="", TaskListId=1 } };
            StartTaskCommandHandler handler = new StartTaskCommandHandler(this.uowMock.Object, this.mapper);

            StartStopTaskFailedException ex = await Assert.ThrowsExceptionAsync<StartStopTaskFailedException>(
                () => handler.Handle(command, CancellationToken.None)
            );

            Assert.AreEqual("TASK_MULTIPLE_ACTIVE_NOT_ALLOWED", ex.ErrorCode);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_TaskList_Date_Is_Not_Today()
        {
            Domain.TaskList taskList = new Domain.TaskList
            {
                Id = 1,
                UserId = 1,
                User = null!,
                Date = DateTime.Now.AddDays(-1),
                TaskItems = new List<Domain.TaskItem>()
            };
            taskListRepoMock.Setup(r => r.GetByIdUntracked(taskList.Id)).ReturnsAsync(taskList);

            TaskItemDto taskItem = new TaskItemDto { Id = 1, Title = "", Description = "", TaskListId = 1 };
            StartTaskCommand command = new StartTaskCommand { TaskItem = taskItem };
            StartTaskCommandHandler handler = new StartTaskCommandHandler(uowMock.Object, mapper);

            StartStopTaskFailedException ex = await Assert.ThrowsExceptionAsync<StartStopTaskFailedException>(
                () => handler.Handle(command, CancellationToken.None)
            );

            Assert.AreEqual("TASK_START_INVALID_DATE", ex.ErrorCode);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Another_Task_Has_Been_Started_And_Stopped()
        {
            Domain.User user = new Domain.User() { Id=1, Auth0Id="AUTH" };
            Domain.TaskList taskList = new Domain.TaskList() { Id = 1, Date=DateTime.Now, User=user, UserId=user.Id };
            Domain.TaskItem taskItem1 = new Domain.TaskItem() { Id = 1, Title = "", Description = "", TaskListId = 1, TaskList=taskList };
            Domain.TaskItem taskItem2 = new Domain.TaskItem() { Id = 2, Title = "", Description = "", TaskListId = 1, TaskList=taskList, StartTime=DateTime.Now.AddMicroseconds(-10), EndTime=DateTime.Now.AddMicroseconds(-5) };
            taskList.TaskItems = new List<Domain.TaskItem>()
            {
                taskItem1,
                taskItem2
            };

            this.taskListRepoMock.Setup(r => r.GetByIdUntracked(taskList.Id)).ReturnsAsync(taskList);

            StartTaskCommand command = new StartTaskCommand() { TaskItem=new TaskItemDto() { Id=1, Title="", Description="", TaskListId=1 } };
            StartTaskCommandHandler handler = new StartTaskCommandHandler(this.uowMock.Object, this.mapper);

            await handler.Handle(command, CancellationToken.None);
        }
    }
}
