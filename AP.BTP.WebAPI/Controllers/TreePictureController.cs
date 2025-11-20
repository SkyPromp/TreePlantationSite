using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Application.CQRS.TreePicture;
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
    public class TreePictureController: APIv1Controller
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreePictureController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator used to send commands and queries.</param>
        public TreePictureController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Retrieves picture by the unique tree ID.
        /// </summary>
        /// <param name="id">The ID of the tree to retrieve pictures for.</param>
        /// <returns>The List<TreePictureDTO> matching the given ID, or 404 if not found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPicturesByTreeId(int id)
        {
            return Ok(await mediator.Send(new GetAllTreePicturesByTreeIdQuery() { TreeId = id }));
        }

        /// <summary>
        /// Adds a new picture to the system.
        /// </summary>
        /// <param name="picture">The <see cref="TreePictureDTO"/> representing the picture to add.</param>
        /// <returns>The newly created <see cref="TreePictureDTO"/>.</returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddTree([FromBody] TreePictureDTO treePicture)
        {
            return Created("", await mediator.Send(new AddTreePictureCommand() { TreePicture = treePicture }));
        }

        /// <summary>
        /// Deletes a picture by its ID.
        /// </summary>
        /// <param name="id">The ID of the tree to delete.</param>
        /// <returns>No content on successful deletion.</returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePicture(int id)
        {
            await mediator.Send(new DeleteTreePictureCommand() { Id = id });

            return NoContent();
        }
    }
}
