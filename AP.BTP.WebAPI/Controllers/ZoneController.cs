using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Application.CQRS.Zone;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ZoneController: APIv1Controller
    {
        private readonly IMediator mediator;

        public ZoneController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddZoneByParams([FromBody] ZoneDTO? zone, [FromQuery] int? treeId, int? plantationSiteId)
        {
            if(zone != null)
            {
                return Created("", await mediator.Send(new AddZoneCommand() { Zone = zone }));
            } else if(treeId != null && plantationSiteId != null)
            {
                TreeDTO? tree = await mediator.Send(new GetTreeByIdQuery() { Id=treeId.Value });
                PlantationSiteDTO? plantationSite = await mediator.Send(new GetPlantationSiteByIdQuery() { Id=plantationSiteId.Value });

                return Created("", await mediator.Send(new AddZoneCommand() { Zone = new ZoneDTO() { PlantationSiteId = plantationSite.Id, TreeId = tree.Id } }));
            }

            return BadRequest("Incorrect parameters given");
        }
    }
}
