using AP.BTP.Application.CQRS.TaskItem;
using AP.BTP.Contracts.DTOs;
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
        [Authorize(Roles = "Manager")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTaskById(int id)
        {
            await mediator.Send(new DeleteTaskItemCommand() { Id = id });

            return NoContent();
        }

        /// <summary>
        /// Adds a new task item to the system.
        /// </summary>
        /// <param name="taskItem">The <see cref="TaskItemDTO"/> object containing the details of the task item to add.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> containing the created <see cref="TaskItemDTO"/> if successful.
        /// Returns HTTP 200 (OK) with the created task item.
        /// </returns>
        /// <remarks>
        /// Only users with the <c>Manager</c> role are authorized to perform this action.
        /// </remarks>
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> AddTaskItem([FromBody] TaskItemDTO taskItem)
        {
            TaskItemDTO newTaskItem = await mediator.Send(new AddTaskItemCommand() { TaskItem=taskItem });

            return Ok(newTaskItem);
        }

        /// <summary>
        /// Updates an existing task item.
        /// </summary>
        /// <param name="taskItem">The <see cref="TaskItemDTO"/> object containing the updated task details.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> containing the updated <see cref="TaskItemDTO"/> if successful.
        /// Returns HTTP 200 (OK) with the updated task item.
        /// </returns>
        /// <remarks>
        /// Only users with the <c>Manager</c> role are authorized to perform this action.
        /// </remarks>
        [Authorize(Roles = "Manager")]
        [HttpPut]
        public async Task<IActionResult> EditTaskItem([FromBody] TaskItemDTO taskItem)
        {
            TaskItemDTO newTaskItem = await mediator.Send(new EditTaskItemCommand() { TaskItem=taskItem });

            return Ok(newTaskItem);
        }

        [Authorize(Roles = "Operator")]
        [HttpPatch("started")]
        public async Task<IActionResult> StartTaskItem([FromBody] TaskItemDTO taskItem)
        {
            TaskItemDTO newTaskItem = await mediator.Send(new StartTaskCommand() { TaskItem=taskItem });

            return Ok(newTaskItem);
        }

        [Authorize(Roles = "Operator")]
        [HttpPatch("ended")]
        public async Task<IActionResult> EndTaskItem([FromBody] TaskItemDTO taskItem)
        {
            TaskItemDTO newTaskItem = await mediator.Send(new EndTaskCommand() { TaskItem=taskItem });

            return Ok(newTaskItem);
        }
    }
}
