using Microsoft.AspNetCore.Mvc;
using MediatR;
using AP.BTP.Application.CQRS.PlantationSite;
using Microsoft.AspNetCore.Authorization;

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
    }
}
