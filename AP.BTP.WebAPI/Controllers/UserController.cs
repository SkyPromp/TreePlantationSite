using AP.BTP.Application.CQRS.User;
using AP.BTP.Contracts.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing users within the system and auth0.
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
        [HttpPost]
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
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDetails)
        {
            return Ok(await _mediator.Send(new LoginUserCommand
            {
                Email = userDetails.Email,
                Password = userDetails.Password
            }));
        }
    }
}
