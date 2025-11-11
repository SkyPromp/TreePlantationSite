using Microsoft.AspNetCore.Mvc;
using MediatR;
using AP.BTP.Application.CQRS.PlantationSite;
using Microsoft.AspNetCore.Authorization;
using AP.BTP.Application.CQRS.Zone;
using AP.BTP.Contracts.DTOs;

namespace AP.BTP.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing plantation sites and their related zones.
    /// </summary>
    /// <remarks>
    /// Provides endpoints under "api/v1/plantationsite" for CRUD operations on plantation sites.
    /// Only accessible to users with the "Admin" role.
    /// Inherits from <see cref="APIv1Controller"/>.
    /// Uses <see cref="IMediator"/> to send commands and queries for handling business logic.
    /// </remarks>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlantationSiteController: APIv1Controller
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlantationSiteController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance for sending commands and queries.</param>
        public PlantationSiteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Retrieves a paginated list of plantation sites.
        /// </summary>
        /// <param name="pageNr">The page number (default is 1).</param>
        /// <param name="pageSize">The number of items per page (default is 6).</param>
        /// <param name="search">Optional search string to filter plantation sites by name.</param>
        /// <returns>A paginated list of plantation sites.</returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllPlantationSitesPaged([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 6, [FromQuery] string search = "")
        {
            return Ok(await mediator.Send(new GetAllPlantationSitesPagedQuery() { PageNr = pageNr, PageSize = pageSize, Search = search }));
        }

        /// <summary>
        /// Retrieves a specific plantation site by its ID.
        /// </summary>
        /// <param name="id">The ID of the plantation site.</param>
        /// <returns>The requested <see cref="PlantationSiteDTO"/> if found.</returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllPlantationSitesPaged(int id)
        {
            return Ok(await mediator.Send(new GetPlantationSiteByIdQuery() { Id = id }));
        }

        /// <summary>
        /// Creates a new plantation site along with its zones.
        /// </summary>
        /// <param name="plantationSiteDTO">The plantation site data transfer object.</param>
        /// <returns>The created <see cref="PlantationSiteDTO"/> along with its zones.</returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePlantationSite([FromBody] PlantationSiteDTO plantationSiteDTO)
        {
            ICollection<ZoneDTO>? zones = plantationSiteDTO.Zones;
            plantationSiteDTO.Zones = null; // avoid duplicated instances in database

            PlantationSiteDTO newPlantationSite = await mediator.Send(new AddPlantationSiteCommand() { PlantationSite = plantationSiteDTO });

            Console.WriteLine($"- zones amount: {zones?.Count() ?? -1}");
            Console.WriteLine($"- newPlantationSiteId: {newPlantationSite.Id}");

            if (zones != null)
            {
                foreach (ZoneDTO zone in zones) zone.PlantationSiteId = newPlantationSite.Id;

                await mediator.Send(new AddZonesManyCommand() { Zones = zones });
            }

            newPlantationSite.Zones = zones;

            return Created("", newPlantationSite);
        }

        /// <summary>
        /// Updates an existing plantation site and its associated zones.
        /// </summary>
        /// <param name="id">The ID of the plantation site to update.</param>
        /// <param name="plantationSiteDTO">The updated plantation site data transfer object.</param>
        /// <returns>The updated <see cref="PlantationSiteDTO"/>.</returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlantationSite(int id, [FromBody] PlantationSiteDTO plantationSiteDTO)
        {
            if (plantationSiteDTO == null) return BadRequest("Missing parameter: plantationSite");
            if (id != plantationSiteDTO.Id) return BadRequest("Mismatched ID.");

            List<ZoneDTO> zones = plantationSiteDTO.Zones?.ToList() ?? new List<ZoneDTO>();

            PlantationSiteDTO newPlantationSite = await mediator.Send(new UpdatePlantationSiteCommand() { UpdatedSite = plantationSiteDTO });

            foreach (ZoneDTO zone in zones ?? [])
            {
                if (zone.Id == 0) await mediator.Send(new AddZoneCommand() { Zone = zone });
                else await mediator.Send(new UpdateZoneCommand() { Zone = zone });
            }

            return Ok(newPlantationSite);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantationSite(int id)
        {
            await mediator.Send(new DeletePlantationSiteCommand() { Id = id });
            return NoContent();
        }     
    }
}
