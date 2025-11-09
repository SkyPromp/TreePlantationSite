using AP.BTP.Application.CQRS.Auth0User;
using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.CQRS.User;
using AP.BTP.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
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

        [HttpPost("users/auth/{auth0Id}/approval")]
        public async Task<IActionResult> Approve(string auth0Id, [FromBody] ApproveUserDTO approveUserDTO)
        {
            try
            {
                Console.WriteLine($"auth0id: {auth0Id}, approveUserDTO: {approveUserDTO.Role}");
                UserDTO? user = await _mediator.Send(new ApproveUserCommand() { UserId = auth0Id, Role = approveUserDTO.Role });
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return Ok();
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetAllUnapprovedUsersPaged([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 6, [FromQuery] string search = "")
        {
            return Ok(await _mediator.Send(new GetAllUnapprovedUsersPagedQuery() { PageNr = pageNr, PageSize = pageSize, Search = search }));
        }

        [HttpPut("users/{userId}/sites")]
        public async Task<IActionResult> LinkUserToPlantationSites(
            int userId,
            [FromBody] LinkUserToPlantationSitesDto linkUserToPlantationSitesDto)
        {
            UserDTO user = await _mediator.Send(new LinkUserToPlantationSitesCommand
            {
                UserId = userId,
                PlantationSiteIds = linkUserToPlantationSitesDto.PlantationSiteIds
            });

            return Ok(user);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _mediator.Send(new GetAllRolesQuery()));
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllApprovedUsersPaged([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 6, [FromQuery] string search = "")
        {
            return Ok(await _mediator.Send(new GetAllUsersPagedQuery() { PageNr = pageNr, PageSize = pageSize, Search = search }));
        }

        [HttpDelete("users/auth/{auth0Id}")]
        public async Task<IActionResult> DeleteAuth0User(string auth0Id)
        {
            try
            {
                await _mediator.Send(new DeleteAuth0UserCommand(auth0Id));
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"User with Auth0 ID '{auth0Id}' not found.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while deleting the Auth0 user.");
            }
        }

        [HttpDelete("users/{userId}")]
        public async Task<IActionResult> DeleteLocalUser(int userId)
        {
            await _mediator.Send(new DeleteUserCommand() { Id = userId });
            return NoContent();
        }
    }
}
