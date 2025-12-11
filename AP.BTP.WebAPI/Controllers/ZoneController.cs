using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Application.CQRS.Zone;
using AP.BTP.Contracts.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing zones, including retrieval, creation, and deletion of zones.
    /// </summary>
    /// <remarks>
    /// Provides endpoints under "api/v1/zone" for operations related to <see cref="Zone"/> entities.
    /// Inherits from <see cref="APIv1Controller"/> and uses <see cref="IMediator"/> to handle commands and queries.
    /// </remarks>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ZoneController: APIv1Controller
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator used to send commands and queries.</param>
        public ZoneController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Retrieves a zone by its ID.
        /// </summary>
        /// <param name="id">The ID of the zone to retrieve.</param>
        /// <returns>The <see cref="ZoneDto"/> corresponding to the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetZoneById(int id)
        {
            return Ok(await mediator.Send(new GetZoneByIdQuery() { Id = id }));
        }

        // <summary>
        /// Retrieves all zones for a given plantation site.
        /// </summary>
        /// <param name="plantationSiteId">The ID of the plantation site to filter zones by.</param>
        /// <returns>
        /// A list of <see cref="ZoneDto"/> for the specified plantation site, 
        /// or a <see cref="BadRequestResult"/> if the plantationSiteId is not provided.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetZonesByPlantationSiteId([FromQuery] int? plantationSiteId)
        {
            if (plantationSiteId != null)
            {
                return Ok(await mediator.Send(new GetAllZonesByPlantationSiteIdQuery() { PlantationSiteId = plantationSiteId.Value }));
            }

            return BadRequest("Not implemented yet, must provide a plantationSiteId currently");
        }

        /// <summary>
        /// Adds a new zone either from a provided <see cref="ZoneDto"/> or by specifying a tree and plantation site ID.
        /// </summary>
        /// <param name="zone">Optional zone object to create.</param>
        /// <param name="treeId">Optional tree ID to associate with the new zone.</param>
        /// <param name="plantationSiteId">Optional plantation site ID to associate with the new zone.</param>
        /// <returns>The newly created <see cref="ZoneDto"/> or a <see cref="BadRequestResult"/> if parameters are invalid.</returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddZoneByParams([FromBody] ZoneDto? zone, [FromQuery] int? treeId, int? plantationSiteId)
        {
            if(zone != null)
            {
                return Created("", await mediator.Send(new AddZoneCommand() { Zone = zone }));
            } else if(treeId != null && plantationSiteId != null)
            {
                TreeDto? tree = await mediator.Send(new GetTreeByIdQuery() { Id=treeId.Value });
                PlantationSiteDto? plantationSite = await mediator.Send(new GetPlantationSiteByIdQuery() { Id=plantationSiteId.Value });

                return Created("", await mediator.Send(new AddZoneCommand() { Zone = new ZoneDto() { PlantationSiteId = plantationSite.Id, TreeId = tree.Id } }));
            }

            return BadRequest("Incorrect parameters given");
        }

        /// <summary>
        /// Deletes a zone by its ID.
        /// </summary>
        /// <param name="id">The ID of the zone to delete.</param>
        /// <returns>No content on success.</returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTree(int id)
        {
            await mediator.Send(new DeleteZoneCommand() { Id = id });

            return NoContent();
        }
    }
}
