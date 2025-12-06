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
            var command = new SubmitWeekScheduleCommand();

            DateTime startDate = new DateTime(2025, 1, 6);

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
            var command = new SubmitWeekScheduleCommand();

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.TaskLists)
                .WithErrorMessage("De week moet minstens één takenlijst bevatten.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Not_All_Same_Site()
        {
            var command = CreateValidCommand();
            command.TaskLists[0].PlantationSiteId = 1;
            command.TaskLists[1].PlantationSiteId = 2;

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.TaskLists)
                .WithErrorMessage("Een medewerker moet de volledige week in dezelfde site werken.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Working_More_Than_5_Days()
        {
            var command = CreateValidCommand(dayCount: 6);

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.TaskLists)
                .WithErrorMessage("Een medewerker mag maximaal 5 dagen per week werken.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_More_Than_4_Tasks_In_A_Day()
        {
            var command = CreateValidCommand(tasksPerDay: 5);

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor("TaskLists[0]")
                .WithErrorMessage("Een medewerker mag maximaal 4 taken per dag hebben.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Total_Minutes_Exceed_480()
        {
            var command = CreateValidCommand(tasksPerDay: 9, taskDuration: 60);

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor("TaskLists[0]")
                .WithErrorMessage("Een takenlijst mag maximaal 8 uur bevatten.");
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Command_Is_Valid()
        {
            var command = CreateValidCommand();

            var result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
