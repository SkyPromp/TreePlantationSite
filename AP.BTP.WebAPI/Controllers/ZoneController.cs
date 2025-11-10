using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Application.CQRS.Zone;
using AP.BTP.Contracts.DTOs;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetZoneById(int id)
        {
            return Ok(await mediator.Send(new GetZoneByIdQuery() { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetZonesByPlantationSiteId([FromQuery] int? plantationSiteId)
        {
            if (plantationSiteId != null)
            {
                return Ok(await mediator.Send(new GetAllZonesByPlantationSiteIdQuery() { PlantationSiteId = plantationSiteId.Value }));
            }

            return BadRequest("Not implemented yet, must provide a plantationSiteId currently");
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

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTree(int id)
        {
            await mediator.Send(new DeleteZoneCommand() { Id = id });

            return NoContent();
        }
    }
}
