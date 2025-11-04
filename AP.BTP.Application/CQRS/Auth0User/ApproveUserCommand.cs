using AP.BTP.Application.Interfaces;
using MediatR;

namespace AP.BTP.Application.CQRS.Auth0User
{
    public class ApproveUserCommand : IRequest
    {
        public required string UserId { get; set; }
        public required string Role { get; set; }
    }

    public class ApproveUserCommandHandler : IRequestHandler<ApproveUserCommand>
    {
        private readonly IAuth0ManagementService _auth0;
        private readonly IUnitOfWork uow;

        public ApproveUserCommandHandler(IAuth0ManagementService auth0, IUnitOfWork uow)
        {
            _auth0 = auth0;
            this.uow = uow;
        }

        public async Task Handle(ApproveUserCommand request, CancellationToken cancellationToken)
        {
            await _auth0.ApproveUserAsync(request.UserId, request.Role);

            Domain.User? user = await uow.UserRepository.GetUserByAuth0Id(request.UserId);
            if (user == null)
            {
                user = new Domain.User { Auth0Id = request.UserId };
                await uow.UserRepository.Create(user);
                await uow.Commit();
            }
        }
    }
}
