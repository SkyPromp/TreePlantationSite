using AP.BTP.Application.Interfaces;
using MediatR;

namespace AP.BTP.Application.CQRS.Auth0User
{
    public class ApproveUserCommand : IRequest
    {
        public required string UserId { get; set; }
    }

    public class ApproveUserCommandHandler : IRequestHandler<ApproveUserCommand>
    {
        private readonly IAuth0ManagementService _auth0;

        public ApproveUserCommandHandler(IAuth0ManagementService auth0)
        {
            _auth0 = auth0;
        }

        public async Task Handle(ApproveUserCommand request, CancellationToken cancellationToken)
        {
            await _auth0.ApproveUserAsync(request.UserId);
        }
    }
}
