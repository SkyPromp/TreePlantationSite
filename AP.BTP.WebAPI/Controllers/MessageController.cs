using Microsoft.AspNetCore.Mvc;
using MediatR;
using AP.BTP.Application.CQRS.Message;

namespace AP.BTP.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MessageController: APIv1Controller
    {
        private readonly IMediator mediator;

        public MessageController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            return Ok(await mediator.Send(new GetAllMessagesQuery() { PageNr = 1, PageSize = 10 }));
        }
    }
}
