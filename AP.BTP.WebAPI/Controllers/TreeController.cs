using AP.BTP.Application.CQRS.Tree;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetTrees([FromQuery] int page = 1, [FromQuery] int pageSize = 6, [FromQuery] string? searchString = null)
        {
            return Ok(await mediator.Send(new GetTreeQuery() { Page=page, PageSize=pageSize, SearchString=searchString }));
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddTree([FromBody] TreeDTO tree)
        {
            return Created("", await mediator.Send(new AddTreeCommand() { Tree = tree }));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTree(int id)
        {
            await mediator.Send(new DeleteTreeCommand() { Id = id });

            return NoContent();
        }
    }
}
