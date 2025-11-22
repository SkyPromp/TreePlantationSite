using AP.BTP.Application.CQRS.User;
using AP.BTP.Contracts.DTOs;
using MediatR;
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
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="user">The <see cref="RegisterUserDTO"/> representing the user to add.</param>
        /// <returns>The newly created <see cref="UserDTO"/>.</returns>

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO user)
        {
            return Created("", await _mediator.Send(new AddUserCommand() { User = user }));
        }
    }
}
