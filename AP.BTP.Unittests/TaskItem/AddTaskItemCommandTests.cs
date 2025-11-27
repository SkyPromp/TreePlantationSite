using System.ComponentModel.DataAnnotations;
using AP.BTP.Application.CQRS.TaskItem;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AP.BTP.Infrastructure.Migrations;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.TaskItem
{
    [TestClass]
    public class AddTaskItemCommandValidatorTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<ITaskListRepository> taskListRepoMock;
        private AddTaskItemCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            taskListRepoMock = new Mock<ITaskListRepository>();

            uowMock.Setup(u => u.TaskListRepository).Returns(taskListRepoMock.Object);

            validator = new AddTaskItemCommandValidator(uowMock.Object);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(-10)]
        public async Task Should_Have_Error_When_Id_Is_Not_Zero(int id)
        {
            AddTaskItemCommand command = new AddTaskItemCommand
            {
                TaskItem = new TaskItemDTO { Id = id, Title = "Test", Description = "Beschrijving", DurationInMinutes = 30, TaskListId = 1 }
            };

            TestValidationResult<AddTaskItemCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(c => c.TaskItem.Id)
                .WithErrorMessage("Id should be zero when adding a task item.") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Id_Is_Zero()
        {
            AddTaskItemCommand command = new AddTaskItemCommand
            {
                TaskItem = new TaskItemDTO { Id = 0, Title = "Test", Description = "Beschrijving", DurationInMinutes = 30, TaskListId = 1 }
            };

            TestValidationResult<AddTaskItemCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveValidationErrorFor(c => c.TaskItem.Id);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-5)]
        public async Task Should_Have_Error_When_Duration_Not_Greater_Than_Zero(int duration)
        {
            AddTaskItemCommand command = new AddTaskItemCommand
            {
                TaskItem = new TaskItemDTO { Id = 0, Title = "Test", Description = "Beschrijving", DurationInMinutes = duration, TaskListId = 1 }
            };

            TestValidationResult<AddTaskItemCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(c => c.TaskItem.DurationInMinutes)
                .WithErrorMessage("Duration must be greater than 0 minutes") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Duration_Exceeds_480()
        {
            AddTaskItemCommand command = new AddTaskItemCommand
            {
                TaskItem = new TaskItemDTO { Id = 0, Title = "Test", Description = "Beschrijving", DurationInMinutes = 600, TaskListId = 1 }
            };

            TestValidationResult<AddTaskItemCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(c => c.TaskItem.DurationInMinutes)
                .WithErrorMessage("Duration cannot exceed 8 hours (480 minutes)") != null);
        }


        [TestMethod]
        public async Task Should_Have_Error_When_Total_Duration_Exceeds_480()
        {
            // Arrange
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

            AddTaskItemCommand command = new AddTaskItemCommand
            {
                TaskItem = new TaskItemDTO { Id = 0, Title = "Test", Description="Test", TaskListId = 1, DurationInMinutes = 100 }
            };

            // Act
            TestValidationResult<AddTaskItemCommand> result = await validator.TestValidateAsync(command);

            // Assert
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

            AddTaskItemCommand command = new AddTaskItemCommand
            {
                TaskItem = new TaskItemDTO { Id = 0, TaskListId = 1, Title = "Test", Description = "Beschrijving", DurationInMinutes = 100 }
            };

            TestValidationResult<AddTaskItemCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
