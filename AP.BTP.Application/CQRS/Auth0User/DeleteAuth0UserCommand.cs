using AP.BTP.Application.Interfaces;
using MediatR;

namespace AP.BTP.Application.CQRS.Auth0User
{
    /// <summary>
    /// Represents a command to delete a user from Auth0 by their unique identifier.
    /// </summary>
    /// <param name="UserId">The unique identifier of the Auth0 user to delete.</param>
    public class DeleteAuth0UserCommand : IRequest
    {
        /// <summary>
        /// The unique identifier of the Auth0 user to delete.
        /// </summary>
        public string UserId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAuth0UserCommand"/> class.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to delete.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="userId"/> is <c>null</c>.</exception>

        public DeleteAuth0UserCommand(string userId)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        }
    }

    /// <summary>
    /// Handles the <see cref="DeleteAuth0UserCommand"/> by removing the specified user from Auth0.
    /// </summary>
    public class DeleteAuth0UserCommandHandler : IRequestHandler<DeleteAuth0UserCommand>
    {
        private readonly IAuth0ManagementService _auth0;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAuth0UserCommandHandler"/> class.
        /// </summary>
        /// <param name="auth0">The Auth0 management service used to perform user deletion.</param>
        public DeleteAuth0UserCommandHandler(IAuth0ManagementService auth0)
        {
            _auth0 = auth0;
        }

        /// <summary>
        /// Handles the <see cref="DeleteAuth0UserCommand"/> by invoking the Auth0 API to delete the user.
        /// </summary>
        /// <param name="request">The command containing the ID of the user to delete.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>

        public async Task Handle(DeleteAuth0UserCommand request, CancellationToken cancellationToken)
        {
            await _auth0.DeleteUserAsync(request.UserId);
        }
    }
}
