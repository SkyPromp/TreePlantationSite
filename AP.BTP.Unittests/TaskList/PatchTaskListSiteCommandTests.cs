using AP.BTP.Application.CQRS.TaskList;
using AP.BTP.Application.Interfaces;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.TaskList
{
    [TestClass]
    public class PatchTaskListSiteCommandTests
    {
        private Mock<IUnitOfWork> uowMock = null!;
        private Mock<ITaskListRepository> taskListRepoMock = null!;
        private Mock<IPlantationSiteRepository> plantationSiteRepoMock = null!;
        private PatchTaskListSiteCommandValidator validator = null!;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            taskListRepoMock = new Mock<ITaskListRepository>();
            plantationSiteRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.TaskListRepository).Returns(taskListRepoMock.Object);
            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationSiteRepoMock.Object);

            validator = new PatchTaskListSiteCommandValidator(uowMock.Object);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-100)]
        public async Task Should_Have_Error_When_TaskListId_Not_Greater_Than_Zero(int taskListId)
        {
            // Arrange
            PatchTaskListSiteCommand command = new PatchTaskListSiteCommand
            {
                TaskListId = taskListId,
                PlantationSiteId = 1
            };

            // Act
            TestValidationResult<PatchTaskListSiteCommand> result = await validator.TestValidateAsync(command);

            // Assert
            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.TaskListId)
                .WithErrorMessage("Task list ID must be greater than 0") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_TaskList_Does_Not_Exist()
        {
            // Arrange
            taskListRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync((Domain.TaskList?)null);

            PatchTaskListSiteCommand command = new PatchTaskListSiteCommand
            {
                TaskListId = 1,
                PlantationSiteId = 1
            };

            // Act
            TestValidationResult<PatchTaskListSiteCommand> result = await validator.TestValidateAsync(command);

            // Assert
            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.TaskListId)
                .WithErrorMessage("Task list does not exist or has been deleted") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_TaskList_Is_Deleted()
        {
            // Arrange
            Domain.User user = new Domain.User() {Id = 1, Auth0Id = "1", FirstName = "Test"};

            taskListRepoMock.Setup(r => r.GetById(1))
                .ReturnsAsync(new Domain.TaskList 
                { 
                    Id = 1, 
                    Date = DateTime.Now,
                    User = user, 
                    UserId = user.Id, 
                    IsDeleted = true 
                });

            PatchTaskListSiteCommand command = new PatchTaskListSiteCommand
            {
                TaskListId = 1,
                PlantationSiteId = 1
            };

            // Act
            TestValidationResult<PatchTaskListSiteCommand> result = await validator.TestValidateAsync(command);

            // Assert
            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.TaskListId)
                .WithErrorMessage("Task list does not exist or has been deleted") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_PlantationSiteId_Is_Null()
        {
            // Arrange
            Domain.User user = new Domain.User() {Id = 1, Auth0Id = "1", FirstName = "Test"};

            taskListRepoMock.Setup(r => r.GetById(1))
                .ReturnsAsync(new Domain.TaskList 
                { 
                    Id = 1, 
                    Date = DateTime.Now, 
                    User = user,
                    UserId = user.Id, 
                    IsDeleted = false 
                });

            PatchTaskListSiteCommand command = new PatchTaskListSiteCommand
            {
                TaskListId = 1,
                PlantationSiteId = null
            };

            // Act
            TestValidationResult<PatchTaskListSiteCommand> result = await validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Valid_Command()
        {
            // Arrange
            Domain.User user = new Domain.User() {Id = 1, Auth0Id = "1", FirstName = "Test"};

            taskListRepoMock.Setup(r => r.GetById(1))
                .ReturnsAsync(new Domain.TaskList 
                { 
                    Id = 1, 
                    Date = DateTime.Now,
                    User = user,
                    UserId = user.Id, 
                    IsDeleted = false 
                });

            plantationSiteRepoMock.Setup(r => r.GetById(1))
                .ReturnsAsync(new Domain.PlantationSite 
                { 
                    Name = "Site1",
                    Street = "Street",
                    HouseNumber = "1",
                    City = "City",
                    Country = "Country",
                    GroundPlan = "Plan",
                    IsDeleted = false 
                });

            PatchTaskListSiteCommand command = new PatchTaskListSiteCommand
            {
                TaskListId = 1,
                PlantationSiteId = 1
            };

            // Act
            TestValidationResult<PatchTaskListSiteCommand> result = await validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}