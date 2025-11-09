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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTreeById(int id)
        {
            return Ok(await mediator.Send(new GetTreeByIdQuery() { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetTrees([FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string? search = null)
        {
            if(page != null && pageSize != null) return Ok(await mediator.Send(new GetTreeQuery() { Page=page.Value, PageSize=pageSize.Value, SearchString=search }));

            return Ok(await mediator.Send(new GetAllTreeQuery() { }));
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddTree([FromBody] TreeDTO tree)
        {
            return Created("", await mediator.Send(new AddTreeCommand() { Tree = tree }));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> EditTree([FromBody] TreeDTO tree)
        {
            return Ok(await mediator.Send(new EditTreeCommand() { Tree = tree }));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTree(int id)
        {
            Console.WriteLine($"Delete tree controller, delete: {id}");

            await mediator.Send(new DeleteTreeCommand() { Id = id });

            return NoContent();
        }
    }
}
