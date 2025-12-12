using AP.BTP.Application.CQRS.TaskItem;
using AP.BTP.Application.Exceptions;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using Moq;

namespace AP.BTP.Unittests.TaskItem
{
    [TestClass]
    public class EndTaskCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<ITaskListRepository> taskListRepoMock;
        private Mock<ITaskItemRepository> taskItemRepoMock;
        private IMapper mapper;

        public EndTaskCommandTests()
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
        public async Task Should_Have_Error_When_Not_Started()
        {
            TaskItemDto taskItem = new TaskItemDto() { Id = 1, Title = "", Description = "", TaskListId = 1 };
            EndTaskCommand command = new EndTaskCommand() { TaskItem = taskItem };
            EndTaskCommandHandler handler = new EndTaskCommandHandler(uowMock.Object, mapper);

            StartStopTaskFailedException ex = await Assert.ThrowsExceptionAsync<StartStopTaskFailedException>(
                () => handler.Handle(command, CancellationToken.None)
            );

            Assert.AreEqual("TASK_NOT_STARTED", ex.ErrorCode);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_EndTime_Is_Not_Null()
        {
            TaskItemDto taskItem = new TaskItemDto() { Id = 1, Title = "", Description = "", TaskListId = 1, StartTime = DateTime.Now.AddMinutes(-1), EndTime = DateTime.Now };
            EndTaskCommand command = new EndTaskCommand() { TaskItem = taskItem };
            EndTaskCommandHandler handler = new EndTaskCommandHandler(uowMock.Object, mapper);

            StartStopTaskFailedException ex = await Assert.ThrowsExceptionAsync<StartStopTaskFailedException>(
                () => handler.Handle(command, CancellationToken.None)
            );

            Assert.AreEqual("TASK_ALREADY_ENDED", ex.ErrorCode);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_StartTime_In_Future()
        {
            TaskItemDto taskItem = new TaskItemDto { Id = 1, Title = "", Description = "", TaskListId = 1, StartTime = DateTime.Now.AddMinutes(15) };
            EndTaskCommand command = new EndTaskCommand { TaskItem = taskItem };

            EndTaskCommandHandler handler = new EndTaskCommandHandler(uowMock.Object, mapper);

            StartStopTaskFailedException ex = await Assert.ThrowsExceptionAsync<StartStopTaskFailedException>(
                () => handler.Handle(command, CancellationToken.None)
            );

            Assert.AreEqual("TASK_INVALID_TIME", ex.ErrorCode);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_TaskList_Is_Null()
        {
            TaskItemDto taskItem = new TaskItemDto { Id = 1, Title = "", Description = "", TaskListId = 1, StartTime = DateTime.Now.AddMinutes(-1) };
            taskListRepoMock.Setup(r => r.GetByIdUntracked(taskItem.TaskListId)).ReturnsAsync((Domain.TaskList?)null);

            EndTaskCommand command = new EndTaskCommand { TaskItem = taskItem };
            EndTaskCommandHandler handler = new EndTaskCommandHandler(uowMock.Object, mapper);

            NotFoundException ex = await Assert.ThrowsExceptionAsync<NotFoundException>(
                () => handler.Handle(command, CancellationToken.None)
            );

            StringAssert.Contains(ex.Message, "TaskList niet gevonden");
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

            TaskItemDto taskItem = new TaskItemDto { Id = 1, Title = "", Description = "", TaskListId = 1, StartTime = DateTime.Now.AddMinutes(-1) };
            EndTaskCommand command = new EndTaskCommand { TaskItem = taskItem };
            EndTaskCommandHandler handler = new EndTaskCommandHandler(uowMock.Object, mapper);

            StartStopTaskFailedException ex = await Assert.ThrowsExceptionAsync<StartStopTaskFailedException>(
                () => handler.Handle(command, CancellationToken.None)
            );

            Assert.AreEqual("TASK_END_INVALID_DATE", ex.ErrorCode);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Correctly_Filled_In()
        {
            Domain.TaskList taskList = new Domain.TaskList
            {
                Id = 1,
                UserId = 1,
                User = null!,
                Date = DateTime.Now,
                TaskItems = new List<Domain.TaskItem>()
            };
            taskListRepoMock.Setup(r => r.GetByIdUntracked(taskList.Id)).ReturnsAsync(taskList);

            TaskItemDto taskItem = new TaskItemDto { Id = 1, Title = "", Description = "", TaskListId = 1, StartTime = DateTime.Now.AddMinutes(-15) };
            EndTaskCommand command = new EndTaskCommand { TaskItem = taskItem };

            EndTaskCommandHandler handler = new EndTaskCommandHandler(this.uowMock.Object, this.mapper);

            TaskItemDto result = await handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result.EndTime);
        }
    }
}
