using AP.BTP.Application.CQRS.TaskItem;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.TaskItem
{
    [TestClass]
    public class EditTaskItemCommandValidatorTests
    {
        private Mock<IUnitOfWork> uowMock = null!;
        private Mock<ITaskListRepository> taskListRepoMock = null!;
        private EditTaskItemCommandValidator validator = null!;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            taskListRepoMock = new Mock<ITaskListRepository>();

            uowMock.Setup(u => u.TaskListRepository).Returns(taskListRepoMock.Object);

            validator = new EditTaskItemCommandValidator(uowMock.Object);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        public async Task Should_Not_Have_Error_When_Id_Is_Not_Zero(int id)
        {
            EditTaskItemCommand command = new EditTaskItemCommand
            {
                TaskItem = new TaskItemDto { Id = id, Title = "Test", Description = "Beschrijving", DurationInMinutes = 30, TaskListId = 1 }
            };

            TestValidationResult<EditTaskItemCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveValidationErrorFor(c => c.TaskItem.Id);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Id_Is_Zero()
        {
            EditTaskItemCommand command = new EditTaskItemCommand
            {
                TaskItem = new TaskItemDto { Id = 0, Title = "Test", Description = "Beschrijving", DurationInMinutes = 30, TaskListId = 1 }
            };

            TestValidationResult<EditTaskItemCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(c => c.TaskItem.Id)
                .WithErrorMessage("Id should not be zero when editing a task item.") != null);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-5)]
        public async Task Should_Have_Error_When_Duration_Not_Greater_Than_Zero(int duration)
        {
            EditTaskItemCommand command = new EditTaskItemCommand
            {
                TaskItem = new TaskItemDto { Id = 0, Title = "Test", Description = "Beschrijving", DurationInMinutes = duration, TaskListId = 1 }
            };

            TestValidationResult<EditTaskItemCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(c => c.TaskItem.DurationInMinutes)
                .WithErrorMessage("Duration must be greater than 0 minutes") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Duration_Exceeds_480()
        {
            EditTaskItemCommand command = new EditTaskItemCommand
            {
                TaskItem = new TaskItemDto { Id = 0, Title = "Test", Description = "Beschrijving", DurationInMinutes = 600, TaskListId = 1 }
            };

            TestValidationResult<EditTaskItemCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(c => c.TaskItem.DurationInMinutes)
                .WithErrorMessage("Duration cannot exceed 8 hours (480 minutes)") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Total_Duration_Exceeds_480()
        {
            Domain.User user = new Domain.User() { Auth0Id = "Auth0", Id = 1};
            Domain.TaskList taskList = new Domain.TaskList() { Id = 1, UserId = user.Id, Date = DateTime.Now, User = user };
            
            List<Domain.TaskItem> existingTasks = new List<Domain.TaskItem>
            {
                new Domain.TaskItem { Id = 1, Title = "Test", Description = "Beschrijving", DurationInMinutes = 300, IsDeleted = false, TaskList = taskList, TaskListId = taskList.Id },
                new Domain.TaskItem { Id = 2, Title = "Test", Description = "Beschrijving", DurationInMinutes = 150, IsDeleted = false, TaskList = taskList, TaskListId = taskList.Id },
            };

            taskList.TaskItems = existingTasks;

            taskListRepoMock.Setup(r => r.GetById(1))
                .ReturnsAsync(taskList);

            EditTaskItemCommand command = new EditTaskItemCommand
            {
                TaskItem = new TaskItemDto { Id = 0, Title = "Test", Description="Test", TaskListId = 1, DurationInMinutes = 100 }
            };

            TestValidationResult<EditTaskItemCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(c => c.TaskItem)
                .WithErrorMessage("Total task duration for this day cannot exceed 8 hours (480 minutes)") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Total_Duration_Is_Valid()
        {
            Domain.User user = new Domain.User() { Auth0Id = "Auth0", Id = 1};
            Domain.TaskList taskList = new Domain.TaskList() { Id = 1, UserId = user.Id, Date = DateTime.Now, User = user };

            List<Domain.TaskItem> existingTasks = new List<Domain.TaskItem>
            {
                new Domain.TaskItem { Id = 1, Title = "Test", Description = "Test", DurationInMinutes = 200, IsDeleted = false, TaskList = taskList, TaskListId = taskList.Id },
            };

            taskList.TaskItems = existingTasks;

            taskListRepoMock.Setup(r => r.GetById(1))
                .ReturnsAsync(taskList);

            EditTaskItemCommand command = new EditTaskItemCommand
            {
                TaskItem = new TaskItemDto { Id = 1, TaskListId = 1, Title = "Test", Description = "Beschrijving", DurationInMinutes = 100 }
            };

            TestValidationResult<EditTaskItemCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}