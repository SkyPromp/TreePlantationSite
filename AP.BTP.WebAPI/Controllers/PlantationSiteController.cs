using Microsoft.AspNetCore.Mvc;
using MediatR;
using AP.BTP.Application.CQRS.PlantationSite;
using Microsoft.AspNetCore.Authorization;
using AP.BTP.Application.CQRS.Zone;
using Microsoft.Identity.Client;

namespace AP.BTP.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlantationSiteController: APIv1Controller
    {
        private readonly IMediator mediator;

        public PlantationSiteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllPlantationSitesPaged([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 6, [FromQuery] string search = "")
        {
            return Ok(await mediator.Send(new GetAllPlantationSitesPagedQuery() { PageNr = pageNr, PageSize = pageSize, Search = search }));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllPlantationSitesPaged(int id)
        {
            return Ok(await mediator.Send(new GetPlantationSiteByIdQuery() { Id = id }));
        }        

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePlantationSite([FromBody] PlantationSiteDTO plantationSiteDTO)
        {
            IEnumerable<ZoneDTO>? zones = plantationSiteDTO.Zones;
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
        
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlantationSite(int id, [FromBody] PlantationSiteDTO plantationSiteDTO)
        {
            if (plantationSiteDTO == null) return BadRequest("Missing parameter: plantationSite");
            if (id != plantationSiteDTO.Id) return BadRequest("Mismatched ID.");

            List<ZoneDTO> zones = plantationSiteDTO.Zones?.ToList() ?? new List<ZoneDTO>();

            PlantationSiteDTO newPlantationSite = await mediator.Send(new UpdatePlantationSiteCommand() { UpdatedSite = plantationSiteDTO });

            foreach(ZoneDTO zone in zones ?? []) await mediator.Send(new UpdateZoneCommand() { Zone = zone });

            return Ok(newPlantationSite);
        }        
    }
}
