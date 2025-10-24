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
        [HttpPost]
        public async Task<IActionResult> CreatePlantationSite([FromBody] PlantationSiteDTO plantationSiteDTO)
        {
            IEnumerable<ZoneDTO>? zones = plantationSiteDTO.Zones;

            PlantationSiteDTO newPlantationSite = await mediator.Send(new AddPlantationSiteCommand() { PlantationSite = plantationSiteDTO });

            Console.WriteLine($"- zones amount: {zones?.Count() ?? -1}");
            Console.WriteLine($"- newPlantationSiteId: {newPlantationSite.Id}");

            if (zones != null)
            {
                foreach (ZoneDTO zone in zones) zone.PlantationSiteId = newPlantationSite.Id;
                foreach (ZoneDTO zone in zones) Console.WriteLine($"{zone.Id}, {zone.PlantationSiteId}, {zone.TreeId}");

                await mediator.Send(new AddZonesManyCommand() { Zones = zones });
            }

            newPlantationSite.Zones = zones;

            return Created("", newPlantationSite);
        }
    }
}
