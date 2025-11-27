using AP.BTP.Application.CQRS.TaskItem;
using AP.BTP.Application.Interfaces;
using FluentValidation.TestHelper;
using Moq;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;

namespace AP.BTP.Unittests.TaskItem
{
    [TestClass]
    public class StartTaskCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<ITaskListRepository> taskListRepoMock;
        private Mock<ITaskItemRepository> taskItemRepoMock;
        private StartTaskCommandValidator validator;
        private IMapper mapper;

        public StartTaskCommandTests()
        {
            uowMock = new Mock<IUnitOfWork>();
            taskListRepoMock = new Mock<ITaskListRepository>();
            taskItemRepoMock = new Mock<ITaskItemRepository>();

            uowMock.Setup(u => u.TaskListRepository).Returns(taskListRepoMock.Object);
            uowMock.Setup(u => u.TaskItemRepository).Returns(taskItemRepoMock.Object);

            validator = new StartTaskCommandValidator(uowMock.Object);

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.TaskList, TaskListDTO>().ReverseMap();
                cfg.CreateMap<Domain.TaskItem, TaskItemDTO>().ReverseMap();
            });

            this.mapper = config.CreateMapper();
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Already_Started()
        {
            TaskItemDTO taskItem = new TaskItemDTO() { Id = 1, Title = "", Description = "", TaskListId = 1, StartTime = DateTime.Now };
            StartTaskCommand command = new StartTaskCommand() { TaskItem=taskItem };
            TestValidationResult<StartTaskCommand> result = await validator.TestValidateAsync(command);

            StartTaskCommandHandler handler = new StartTaskCommandHandler(this.uowMock.Object, this.mapper);

            try
            {
                await handler.Handle(command, CancellationToken.None);
                throw new Exception();
            } catch (ValidationException ex)
            {
                Assert.AreEqual($"The task has already been started. taskItemId={taskItem.Id}", ex.Message);
            }
        }

        [TestMethod]
        public async Task Should_Have_Error_When_EndTime_Is_Not_Null()
        {
            TaskItemDTO taskItem = new TaskItemDTO() { Id = 1, Title = "", Description = "", TaskListId = 1, EndTime = DateTime.Now };
            StartTaskCommand command = new StartTaskCommand() { TaskItem=taskItem };
            TestValidationResult<StartTaskCommand> result = await validator.TestValidateAsync(command);

            StartTaskCommandHandler handler = new StartTaskCommandHandler(this.uowMock.Object, this.mapper);

            try
            {
                await handler.Handle(command, CancellationToken.None);
                throw new Exception();
            } catch (ValidationException ex)
            {
                Assert.AreEqual($"Impossible state, the starttime is null and the endtime is not null. taskItemId={taskItem.Id}", ex.Message);
            }
        }

        [TestMethod]
        public async Task Should_Have_Error_When_TaskList_Is_Null()
        {
            TaskItemDTO taskItem = new TaskItemDTO() { Id = 1, Title = "", Description = "", TaskListId = 1 };
            this.taskListRepoMock.Setup(r => r.GetByIdUntracked(taskItem.TaskListId)).ReturnsAsync((Domain.TaskList?)null);

            StartTaskCommand command = new StartTaskCommand() { TaskItem=new TaskItemDTO() { Id=1, Title="", Description="", TaskListId=1 } };
            TestValidationResult<StartTaskCommand> result = await validator.TestValidateAsync(command);

            StartTaskCommandHandler handler = new StartTaskCommandHandler(this.uowMock.Object, this.mapper);

            try
            {
                await handler.Handle(command, CancellationToken.None);
                throw new Exception();
            } catch (ValidationException ex)
            {
                Assert.AreEqual($"Impossible state, the taskList of the current (taskItem {taskItem.Id}) is null. taskListId={taskItem.TaskListId}", ex.Message);
            }
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

            StartTaskCommand command = new StartTaskCommand() { TaskItem=new TaskItemDTO() { Id=1, Title="", Description="", TaskListId=1 } };
            TestValidationResult<StartTaskCommand> result = await validator.TestValidateAsync(command);

            StartTaskCommandHandler handler = new StartTaskCommandHandler(this.uowMock.Object, this.mapper);

            try
            {
                await handler.Handle(command, CancellationToken.None);
                throw new Exception();
            } catch (ValidationException ex)
            {
                Assert.AreEqual($"Cannot start multiple tasks at the same time from the same tasklist.", ex.Message);
            }
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

            StartTaskCommand command = new StartTaskCommand() { TaskItem=new TaskItemDTO() { Id=1, Title="", Description="", TaskListId=1 } };
            TestValidationResult<StartTaskCommand> result = await validator.TestValidateAsync(command);

            StartTaskCommandHandler handler = new StartTaskCommandHandler(this.uowMock.Object, this.mapper);

            await handler.Handle(command, CancellationToken.None);
        }
    }
}
