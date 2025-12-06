using AP.BTP.Application.CQRS.TaskList;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.TaskList
{
    [TestClass]
    public class SubmitWeekScheduleCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private SubmitWeekScheduleCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            validator = new SubmitWeekScheduleCommandValidator(uowMock.Object);
        }

        private SubmitWeekScheduleCommand CreateValidCommand(
            int siteId = 1,
            int dayCount = 5,
            int tasksPerDay = 2,
            int taskDuration = 60)
        {
            SubmitWeekScheduleCommand command = new SubmitWeekScheduleCommand();

            DateTime startDate = DateTime.Today;

            for (int d = 0; d < dayCount; d++)
            {
                TaskListDTO list = new TaskListDTO
                {
                    Id = 0,
                    UserId = 123,
                    PlantationSiteId = siteId,
                    Date = startDate.AddDays(d),
                    TaskItems = new List<TaskItemDTO>()
                };

                for (int t = 0; t < tasksPerDay; t++)
                {
                    list.TaskItems.Add(new TaskItemDTO
                    {
                        Id = 0,
                        TaskListId = 0,
                        Title = $"Task {t + 1}",
                        Description = "Sample description",
                        DurationInMinutes = taskDuration,
                        IsDeleted = false
                    });
                }

                command.TaskLists.Add(list);
            }

            return command;
        }

        [TestMethod]
        public async Task Should_Have_Error_When_TaskLists_Empty()
        {
            SubmitWeekScheduleCommand command = new SubmitWeekScheduleCommand();

            TestValidationResult<SubmitWeekScheduleCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.TaskLists)
                .WithErrorMessage("De week moet minstens één takenlijst bevatten.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Not_All_Same_Site()
        {
            SubmitWeekScheduleCommand command = CreateValidCommand();
            command.TaskLists[0].PlantationSiteId = 1;
            command.TaskLists[1].PlantationSiteId = 2;

            TestValidationResult<SubmitWeekScheduleCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.TaskLists)
                .WithErrorMessage("Een medewerker moet de volledige week in dezelfde site werken.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Working_More_Than_5_Days()
        {
            SubmitWeekScheduleCommand command = CreateValidCommand(dayCount: 6);

            TestValidationResult<SubmitWeekScheduleCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.TaskLists)
                .WithErrorMessage("Een medewerker mag maximaal 5 dagen per week werken.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_More_Than_4_Tasks_In_A_Day()
        {
            SubmitWeekScheduleCommand command = CreateValidCommand(tasksPerDay: 5);

            TestValidationResult<SubmitWeekScheduleCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor("TaskLists[0]")
                .WithErrorMessage("Een medewerker mag maximaal 4 taken per dag hebben.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Total_Minutes_Exceed_480()
        {
            SubmitWeekScheduleCommand command = CreateValidCommand(tasksPerDay: 9, taskDuration: 60);

            TestValidationResult<SubmitWeekScheduleCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor("TaskLists[0]")
                .WithErrorMessage("Een takenlijst mag maximaal 8 uur bevatten.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Editing_Item_In_Past()
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);

            SubmitWeekScheduleCommand command = new SubmitWeekScheduleCommand
            {
                TaskLists = new List<TaskListDTO>
        {
            new TaskListDTO
            {
                Id = 1,
                UserId = 123,
                PlantationSiteId = 1,
                Date = yesterday,
                TaskItems = new List<TaskItemDTO>
                {
                    new TaskItemDTO
                    {
                        Id = 10,
                        TaskListId = 1,
                        Title = "Changed Title",
                        Description = "Changed",
                        DurationInMinutes = 120,
                        IsDeleted = false
                    }
                }
            }
        }
            };

            uowMock.Setup(x => x.TaskItemRepository.GetById(10))
                   .ReturnsAsync(new Domain.TaskItem
                   {
                       Id = 10,
                       TaskListId = 1,
                       TaskList = null,
                       Title = "Changed Title",
                       Description = "Original",
                       DurationInMinutes = 60,
                       IsDeleted = false
                   });

            TestValidationResult<SubmitWeekScheduleCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor("TaskLists[0]")
                  .WithErrorMessage("Taken van een dag in het verleden mogen niet gewijzigd worden.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Deleting_Item_In_Past()
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);

            SubmitWeekScheduleCommand command = new SubmitWeekScheduleCommand
            {
                TaskLists = new List<TaskListDTO>
        {
            new TaskListDTO
            {
                Id = 1,
                UserId = 123,
                PlantationSiteId = 1,
                Date = yesterday,
                TaskItems = new List<TaskItemDTO>
                {
                    new TaskItemDTO
                    {
                        Id = 10,
                        TaskListId = 1,
                        Title = "Original Title",
                        Description = "Original",
                        DurationInMinutes = 60,
                        IsDeleted = true
                    }
                }
            }
        }
            };

            uowMock.Setup(x => x.TaskItemRepository.GetById(10))
                   .ReturnsAsync(new Domain.TaskItem
                   {
                       Id = 10,
                       TaskListId = 1,
                       TaskList = null,
                       Title = "Original Title",
                       Description = "Original",
                       DurationInMinutes = 60,
                       IsDeleted = false
                   });

            TestValidationResult<SubmitWeekScheduleCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor("TaskLists[0]")
                .WithErrorMessage("Taken van een dag in het verleden mogen niet gewijzigd worden.");
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Editing_Item_Today()
        {
            DateTime today = DateTime.Today;

            SubmitWeekScheduleCommand command = new SubmitWeekScheduleCommand
            {
                TaskLists = new List<TaskListDTO>
        {
            new TaskListDTO
            {
                Id = 1,
                UserId = 123,
                PlantationSiteId = 1,
                Date = today,
                TaskItems = new List<TaskItemDTO>
                {
                    new TaskItemDTO
                    {
                        Id = 10,
                        TaskListId = 1,
                        Title = "Updated Title",
                        Description = "Updated",
                        DurationInMinutes = 200,
                        IsDeleted = false
                    }
                }
            }
        }
            };

            uowMock.Setup(x => x.TaskItemRepository.GetById(10))
                   .ReturnsAsync(new Domain.TaskItem
                   {
                       Id = 10,
                       TaskListId = 1,
                       TaskList = null,
                       Title = "Old Title",
                       Description = "Old",
                       DurationInMinutes = 100,
                       IsDeleted = false
                   });

            TestValidationResult<SubmitWeekScheduleCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Command_Is_Valid()
        {
            SubmitWeekScheduleCommand command = CreateValidCommand();

            TestValidationResult<SubmitWeekScheduleCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
