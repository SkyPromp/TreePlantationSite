using AP.BTP.Application.CQRS.User;
using AP.BTP.Contracts.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing users within the system.
    /// </summary>
    /// <remarks>
    /// Provides endpoints under "api/v1/user" for creating, updating, retrieving, and deleting users.
    /// Inherits from <see cref="APIv1Controller"/> and uses <see cref="IMediator"/> to handle requests.
    /// </remarks>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : APIv1Controller
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator used to send commands and queries.</param>
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="user">The <see cref="RegisterUserDTO"/> containing the details of the user to register.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> containing the newly created <see cref="UserDTO"/> if successful.
        /// Returns HTTP 201 Created on success.
        /// </returns>
        /// <remarks>
        /// This endpoint is anonymous and does not require authentication.
        /// </remarks>
        [AllowAnonymous]
        [HttpPost("auth/register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO user)
        {
            return Created("", await _mediator.Send(new AddUserCommand() { User = user }));
        }


        /// <summary>
        /// Authenticates a user and returns authentication information.
        /// </summary>
        /// <param name="userDetails">The <see cref="LoginUserDTO"/> containing the user's email and password.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> containing the newly created <see cref="UserDTO"/> if successful.
        /// An <see cref="IActionResult"/> containing the auth0 response <see cref="TokenResponseDTO"/> if successful.
        /// Returns HTTP 200 OK on successful login.
        /// </returns>
        /// <remarks>
        /// This endpoint is anonymous and does not require authentication.
        /// </remarks>
        [AllowAnonymous]
        [HttpPost("auth/login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDetails)
        {
            return Ok(await _mediator.Send(new LoginUserCommand
            {
                Email = userDetails.Email,
                Password = userDetails.Password
            }));
        }

        /// <summary>
        /// Approves a user in and assigns a role.
        /// </summary>
        /// <param name="userId">The ID of the user to approve.</param>
        /// <param name="approveUserDTO">DTO containing the role to assign.</param>
        /// <returns>The approved <see cref="UserDTO"/>.</returns>
        [Authorize(Roles = "Admin")]
        [HttpPost("{userId}/approval")]
        public async Task<IActionResult> Approve(int userId, [FromBody] ApproveUserDTO approveUserDTO)
        {
            return Ok(await _mediator.Send(new ApproveUserCommand() { UserId = userId, Role = approveUserDTO.Role }));
        }

        /// <summary>
        /// Retrieves a paged list of all unapproved users.
        /// </summary>
        /// <param name="pageNr">Page number (default 1).</param>
        /// <param name="pageSize">Page size (default 6).</param>
        /// <param name="search">Optional search filter.</param>
        /// <returns>Paged list of unapproved users.</returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("pending")]
        public async Task<IActionResult> GetAllUnapprovedUsersPaged([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 6, [FromQuery] string search = "")
        {
            return Ok(await _mediator.Send(new GetAllUnapprovedUsersPagedQuery() { PageNr = pageNr, PageSize = pageSize, Search = search }));
        }

        /// Links a local user to multiple plantation sites.
        /// </summary>
        /// <param name="userId">The ID of the user to link.</param>
        /// <param name="linkUserToPlantationSitesDto">DTO containing plantation site IDs to link.</param>
        /// <returns>The updated <see cref="UserDTO"/>.</returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("{userId}/sites")]
        public async Task<IActionResult> LinkUserToPlantationSites(
            int userId,
            [FromBody] LinkUserToPlantationSitesDTO linkUserToPlantationSitesDto)
        {
            UserDTO user = await _mediator.Send(new LinkUserToPlantationSitesCommand
            {
                UserId = userId,
                PlantationSiteIds = linkUserToPlantationSitesDto.PlantationSiteIds
            });

            return Ok(user);
        }

        /// <summary>
        /// Retrieves a paged list of all approved users.
        /// </summary>
        /// <param name="pageNr">Page number (default 1).</param>
        /// <param name="pageSize">Page size (default 6).</param>
        /// <param name="search">Optional search filter.</param>
        /// <returns>Paged list of approved users.</returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("approved")]
        public async Task<IActionResult> GetAllApprovedUsersPaged([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 6, [FromQuery] string search = "")
        {
            return Ok(await _mediator.Send(new GetAllApprovedUsersPagedQuery() { PageNr = pageNr, PageSize = pageSize, Search = search }));
        }

        /// <summary>
        /// Retrieves a paged list of all operator users.
        /// </summary>
        /// <param name="pageNr">Page number (default 1).</param>
        /// <param name="pageSize">Page size (default 6).</param>
        /// <param name="search">Optional search filter.</param>
        /// <returns>Paged list of operators.</returns>
        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("operators")]
        public async Task<IActionResult> GetAllOperatorsPaged([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 6, [FromQuery] string search = "")
        {
            return Ok(await _mediator.Send(new GetAllOperatorsPagedQuery() { PageNr = pageNr, PageSize = pageSize, Search = search }));
        }

        /// <summary>
        /// Retrieves a single user by their local ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>The <see cref="UserDTO"/> or NotFound if the user does not exist.</returns>
        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery() { Id = userId }));
        }

        /// <summary>
        /// Deletes a local user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>No content on success.</returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteLocalUser(int userId)
        {
            await _mediator.Send(new DeleteUserCommand() { Id = userId });
            return NoContent();
        }
    }
}
