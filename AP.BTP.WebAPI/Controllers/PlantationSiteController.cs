using Microsoft.AspNetCore.Mvc;
using MediatR;
using AP.BTP.Application.CQRS.PlantationSite;

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

        [HttpGet]
        public async Task<IActionResult> GetAllPlantationSites([FromQuery] int pageNr = 1)
        {
            return Ok(await mediator.Send(new GetAllPlantationSitesQuery() { PageNr = pageNr, PageSize = 6 }));
        }
    }
}
