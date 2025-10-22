using AP.BTP.Application.CQRS.Tree;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TreeController: APIv1Controller
    {
        private readonly IMediator mediator;

        public TreeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AddTree([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string searchString)
        {
            return Created("", await mediator.Send(new GetTreeQuery() { Page=page, PageSize=pageSize, searchString=searchString }));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddTree([FromBody] TreeDTO tree)
        {
            return Created("", await mediator.Send(new AddTreeCommand() { Tree = tree }));
        }
    }
}
