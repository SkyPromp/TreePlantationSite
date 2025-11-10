using AP.BTP.Application.CQRS.TaskList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskListController : APIv1Controller
    {
        private readonly IMediator mediator;

        public TaskListController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetByUserAndWeek([FromQuery] int userId, [FromQuery] int year, [FromQuery] int weekNumber)
        {
            return Ok(await mediator.Send(new GetAllTaskListsByUserIdAndWeekQuery { UserId = userId, Year = year, WeekNumber = weekNumber }));
        }
    }
}
