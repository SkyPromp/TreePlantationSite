using AP.BTP.Application.CQRS.User;
using AP.BTP.Application.CQRS.Auth0User;
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

        [HttpPost("{auth0Id}/approve")]
        public async Task<IActionResult> Approve(string auth0Id)
        {
            await _mediator.Send(new ApproveUserCommand() { UserId = auth0Id });
            return Ok(new { message = "User approved." });
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetAllUnapprovedUsersPaged([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 6, [FromQuery] string search = "")
        {
            return Ok(await _mediator.Send(new GetAllUnapprovedUsersPagedQuery() { PageNr = pageNr, PageSize = pageSize, Search = search }));
        }

        [HttpPost("{auth0Id}/sites")]
        public async Task<IActionResult> LinkUserToPlantationSites(
            string auth0Id,
            [FromBody] List<int> plantationSiteIds)
        {
            Console.WriteLine($"plantationSiteIds is: {plantationSiteIds.Count}");

            await _mediator.Send(new LinkUserToPlantationSitesCommand
            {
                Auth0Id = auth0Id,
                PlantationSiteIds = plantationSiteIds
            });

            return Ok(new { message = "User successfully linked to plantation sites." });
        }
    }
}
