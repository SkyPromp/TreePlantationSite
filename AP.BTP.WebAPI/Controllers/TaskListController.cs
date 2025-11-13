using AP.BTP.Application.CQRS.TaskList;
using AP.BTP.Contracts.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing task lists associated with users.
    /// </summary>
    /// <remarks>
    /// Provides endpoints under "api/v1/tasklist" for retrieving task lists by user and week.
    /// Inherits from <see cref="APIv1Controller"/>.
    /// Uses <see cref="IMediator"/> to send queries for handling business logic.
    /// </remarks>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskListController : APIv1Controller
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskListController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance used to send queries.</param>
        public TaskListController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Retrieves all task lists for a specific user within a given ISO week and year.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="year">The year to filter the task lists.</param>
        /// <param name="weekNumber">The ISO week number to filter the task lists.</param>
        /// <returns>A list of <see cref="TaskListDTO"/> objects for the specified user and week.</returns>
        [HttpGet]
        public async Task<IActionResult> GetByUserAndWeek([FromQuery] int userId, [FromQuery] int year, [FromQuery] int weekNumber)
        {
            return Ok(await mediator.Send(new GetAllTaskListsByUserIdAndWeekQuery { UserId = userId, Year = year, WeekNumber = weekNumber }));
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> AddTaskList([FromBody] TaskListDTO taskList)
        {
            return Ok(await mediator.Send(new AddTaskListCommand() { TaskList = taskList}));
        }
    }
}
