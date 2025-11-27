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
    public class EndTaskCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<ITaskListRepository> taskListRepoMock;
        private Mock<ITaskItemRepository> taskItemRepoMock;
        private EndTaskCommandValidator validator;
        private IMapper mapper;

        public EndTaskCommandTests()
        {
            uowMock = new Mock<IUnitOfWork>();
            taskListRepoMock = new Mock<ITaskListRepository>();
            taskItemRepoMock = new Mock<ITaskItemRepository>();

            uowMock.Setup(u => u.TaskListRepository).Returns(taskListRepoMock.Object);
            uowMock.Setup(u => u.TaskItemRepository).Returns(taskItemRepoMock.Object);

            validator = new EndTaskCommandValidator(uowMock.Object);

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.TaskList, TaskListDTO>().ReverseMap();
                cfg.CreateMap<Domain.TaskItem, TaskItemDTO>().ReverseMap();
            });

            this.mapper = config.CreateMapper();
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Not_Started()
        {
            TaskItemDTO taskItem = new TaskItemDTO() { Id = 1, Title = "", Description = "", TaskListId = 1 };
            EndTaskCommand command = new EndTaskCommand() { TaskItem=taskItem };
            TestValidationResult<EndTaskCommand> result = await validator.TestValidateAsync(command);

            EndTaskCommandHandler handler = new EndTaskCommandHandler(this.uowMock.Object, this.mapper);

            try
            {
                await handler.Handle(command, CancellationToken.None);
                throw new Exception();
            } catch (ValidationException ex)
            {
                Assert.AreEqual($"The task has not yet been started. taskItemId={taskItem.Id}", ex.Message);
            }
        }

        [TestMethod]
        public async Task Should_Have_Error_When_EndTime_Is_Not_Null()
        {
            TaskItemDTO taskItem = new TaskItemDTO() { Id = 1, Title = "", Description = "", TaskListId = 1, StartTime=DateTime.Now.AddMinutes(-1), EndTime = DateTime.Now };
            EndTaskCommand command = new EndTaskCommand() { TaskItem=taskItem };
            TestValidationResult<EndTaskCommand> result = await validator.TestValidateAsync(command);

            EndTaskCommandHandler handler = new EndTaskCommandHandler(this.uowMock.Object, this.mapper);

            try
            {
                await handler.Handle(command, CancellationToken.None);
                throw new Exception();
            } catch (ValidationException ex)
            {
                Assert.AreEqual($"The task has already been ended. taskItemId={taskItem.Id}", ex.Message);
            }
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Task_EndTime_Is_After_Task_StartTime()
        {
            TaskItemDTO taskItem = new TaskItemDTO() { Id = 1, Title = "", Description = "", TaskListId = 1 };
            EndTaskCommand command = new EndTaskCommand() { TaskItem=new TaskItemDTO() { Id=1, Title="", Description="", TaskListId=1, StartTime=DateTime.Now.AddMinutes(15) } };
            TestValidationResult<EndTaskCommand> result = await validator.TestValidateAsync(command);

            EndTaskCommandHandler handler = new EndTaskCommandHandler(this.uowMock.Object, this.mapper);

            try
            {
                await handler.Handle(command, CancellationToken.None);
                throw new Exception();
            } catch (ValidationException ex)
            {
                Assert.AreEqual($"The task start time is after the end time. taskItemId={taskItem.Id}", ex.Message);
            }
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Correctly_Filled_In()
        {
            TaskItemDTO taskItem = new TaskItemDTO() { Id = 1, Title = "", Description = "", TaskListId = 1 };
            EndTaskCommand command = new EndTaskCommand() { TaskItem=new TaskItemDTO() { Id=1, Title="", Description="", TaskListId=1, StartTime=DateTime.Now.AddMinutes(-15) } };
            TestValidationResult<EndTaskCommand> result = await validator.TestValidateAsync(command);

            EndTaskCommandHandler handler = new EndTaskCommandHandler(this.uowMock.Object, this.mapper);

            await handler.Handle(command, CancellationToken.None);
        }
    }
}
