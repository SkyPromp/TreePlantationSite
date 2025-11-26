using AP.BTP.Application.CQRS.TaskList;
using AP.BTP.Application.Interfaces;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.TaskList
{
    [TestClass]
    public class PatchTaskListZoneCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<ITaskListRepository> taskListRepoMock;
        private Mock<IZoneRepository> zoneRepoMock;
        private PatchTaskListZoneCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            taskListRepoMock = new Mock<ITaskListRepository>();
            zoneRepoMock = new Mock<IZoneRepository>();

            uowMock.Setup(u => u.TaskListRepository).Returns(taskListRepoMock.Object);
            uowMock.Setup(u => u.ZoneRepository).Returns(zoneRepoMock.Object);

            validator = new PatchTaskListZoneCommandValidator(uowMock.Object);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-100)]
        public async Task Should_Have_Error_When_TaskListId_Not_Greater_Than_Zero(int taskListId)
        {
            // Arrange
            PatchTaskListZoneCommand command = new PatchTaskListZoneCommand
            {
                TaskListId = taskListId,
                ZoneId = 1
            };

            // Act
            TestValidationResult<PatchTaskListZoneCommand> result = await validator.TestValidateAsync(command);

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

            PatchTaskListZoneCommand command = new PatchTaskListZoneCommand
            {
                TaskListId = 1,
                ZoneId = 1
            };

            // Act
            TestValidationResult<PatchTaskListZoneCommand> result = await validator.TestValidateAsync(command);

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

            PatchTaskListZoneCommand command = new PatchTaskListZoneCommand
            {
                TaskListId = 1,
                ZoneId = 1
            };

            // Act
            TestValidationResult<PatchTaskListZoneCommand> result = await validator.TestValidateAsync(command);

            // Assert
            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.TaskListId)
                .WithErrorMessage("Task list does not exist or has been deleted") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_ZoneId_Is_Null()
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

            PatchTaskListZoneCommand command = new PatchTaskListZoneCommand
            {
                TaskListId = 1,
                ZoneId = null
            };

            // Act
            TestValidationResult<PatchTaskListZoneCommand> result = await validator.TestValidateAsync(command);

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

            zoneRepoMock.Setup(r => r.GetById(1))
                .ReturnsAsync(new Domain.Zone 
                { 
                    Name = "Zone test",
                    PlantationSite = new Domain.PlantationSite() { Name = "Test", Street = "Test", HouseNumber = "14", PostalCode = 2000, City = "City test", Country = "Belgium", GroundPlan = "Test"},
                    Tree = new Domain.Tree() { Species = "Test "}
                });

            PatchTaskListZoneCommand command = new PatchTaskListZoneCommand
            {
                TaskListId = 1,
                ZoneId = 1
            };

            // Act
            TestValidationResult<PatchTaskListZoneCommand> result = await validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}