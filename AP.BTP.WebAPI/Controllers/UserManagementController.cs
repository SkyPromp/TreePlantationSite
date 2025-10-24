using AP.BTP.Application.CQRS.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserManagementController : APIv1Controller
    {
        private readonly IMediator _mediator;

        public UserManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{id}/approve")]
        public async Task<IActionResult> Approve(string id)
        {
            await _mediator.Send(new ApproveUserCommand() { UserId = id});
            return Ok(new { message = "User approved." });
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetAllUnapprovedUsersPaged([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 6, [FromQuery] string search = "")
        {
            return Ok(await _mediator.Send(new GetAllUnapprovedUsersPagedQuery() { PageNr = pageNr, PageSize = pageSize, Search = search }));
        }
    }
}
