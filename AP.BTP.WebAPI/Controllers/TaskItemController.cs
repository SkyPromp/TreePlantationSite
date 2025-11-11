using AP.BTP.Application.CQRS.TaskItem;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing task items associated with task lists.
    /// </summary>
    /// <remarks>
    /// Provides endpoints under "api/v1/taskitem" for retrieving task items by task list;
    /// Inherits from <see cref="APIv1Controller"/>.
    /// Uses <see cref="IMediator"/> to send queries for handling business logic.
    /// </remarks>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskItemController : APIv1Controller
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskItemController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance used to send queries.</param>
        public TaskItemController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Deletes a task item by its ID.
        /// </summary>
        /// <param name="id">The ID of the task item to delete.</param>
        /// <returns>No content on successful deletion.</returns>
        //[Authorize(Roles = "Manager")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTaskById(int id)
        {
            await mediator.Send(new DeleteTaskItemCommand() { Id = id });

            return NoContent();
        }
    }
}
