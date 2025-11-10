using AP.BTP.Application.Interfaces;
using MediatR;

namespace AP.BTP.Application.CQRS.Auth0User
{
    public class DeleteAuth0UserCommand : IRequest
    {
        public string UserId { get; }

        public DeleteAuth0UserCommand(string userId)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        }
    }

    public class DeleteAuth0UserCommandHandler : IRequestHandler<DeleteAuth0UserCommand>
    {
        private readonly IAuth0ManagementService _auth0;

        public DeleteAuth0UserCommandHandler(IAuth0ManagementService auth0)
        {
            _auth0 = auth0;
        }

        public async Task Handle(DeleteAuth0UserCommand request, CancellationToken cancellationToken)
        {
            await _auth0.DeleteUserAsync(request.UserId);
        }
    }
}
