using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Contracts.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing trees within the system.
    /// </summary>
    /// <remarks>
    /// Provides endpoints under "api/v1/tree" for creating, updating, retrieving, and deleting trees.
    /// Inherits from <see cref="APIv1Controller"/> and uses <see cref="IMediator"/> to handle requests.
    /// </remarks>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TreeController: APIv1Controller
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator used to send commands and queries.</param>
        public TreeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Retrieves a tree by its unique ID.
        /// </summary>
        /// <param name="id">The ID of the tree to retrieve.</param>
        /// <returns>The <see cref="TreeDTO"/> matching the given ID, or 404 if not found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTreeById(int id)
        {
            return Ok(await mediator.Send(new GetTreeByIdQuery() { Id = id }));
        }

        /// <summary>
        /// Retrieves a list of trees with optional paging and search parameters.
        /// </summary>
        /// <param name="page">The page number for paged results (optional).</param>
        /// <param name="pageSize">The number of items per page (optional).</param>
        /// <param name="search">Optional search string to filter trees by species.</param>
        /// <param name"sortAscending"> An optional sorting bool to sort trees by species. Defaults to sort ascending.
        /// <returns>A paginated list of trees.</returns>
        [HttpGet]
        public async Task<IActionResult> GetTrees([FromQuery] int pageNr, [FromQuery] int pageSize, [FromQuery] string? search = null, [FromQuery] bool sortAscending = true)
        {
            return Ok(await mediator.Send(new GetAllTreesPagedQuery() { PageNr = pageNr, PageSize = pageSize, Search = search, SortAscending = sortAscending }));
        }

        /// <summary>
        /// Retrieves a list of trees with optional paging and search parameters.
        /// </summary>
        /// <param name="page">The page number for paged results (optional).</param>
        /// <param name="pageSize">The number of items per page (optional).</param>
        /// <param name="search">Optional search string to filter trees by species.</param>
        /// <param name"sortAscending"> An optional sorting bool to sort trees by species. Defaults to sort ascending.
        /// <returns>A paginated list of trees.</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllTrees([FromQuery] string? search)
        {
            return Ok(await mediator.Send(new GetAllTreeQuery() { Search = search }));
        }

        /// <summary>
        /// Adds a new tree to the system.
        /// </summary>
        /// <param name="tree">The <see cref="TreeDTO"/> representing the tree to add.</param>
        /// <returns>The newly created <see cref="TreeDTO"/>.</returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddTree([FromBody] TreeDTO tree)
        {
            return Created("", await mediator.Send(new AddTreeCommand() { Tree = tree }));
        }

        /// <summary>
        /// Updates an existing tree.
        /// </summary>
        /// <param name="tree">The <see cref="TreeDTO"/> containing updated tree data.</param>
        /// <returns>The updated <see cref="TreeDTO"/>.</returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> EditTree([FromBody] TreeDTO tree)
        {
            return Ok(await mediator.Send(new EditTreeCommand() { Tree = tree }));
        }

        /// <summary>
        /// Deletes a tree by its ID.
        /// </summary>
        /// <param name="id">The ID of the tree to delete.</param>
        /// <returns>No content on successful deletion.</returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTree(int id)
        {
            Console.WriteLine($"Delete tree controller, delete: {id}");

            await mediator.Send(new DeleteTreeCommand() { Id = id });

            return NoContent();
        }
    }
}
