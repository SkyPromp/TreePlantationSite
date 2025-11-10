using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.Auth0User
{
    public class ApproveUserCommand : IRequest<UserDTO?>
    {
        public required string UserId { get; set; }
        public required string Role { get; set; }
    }

    public class ApproveUserCommandHandler : IRequestHandler<ApproveUserCommand, UserDTO?>
    {
        private readonly IAuth0ManagementService _auth0;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ApproveUserCommandHandler(IAuth0ManagementService auth0, IUnitOfWork uow, IMapper mapper)
        {
            _auth0 = auth0;
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<UserDTO?> Handle(ApproveUserCommand request, CancellationToken cancellationToken)
        {
            await _auth0.ApproveUserAsync(request.UserId, request.Role);

            Domain.User? user = await uow.UserRepository.GetUserByAuth0Id(request.UserId);
            if (user == null)
            {
                Domain.User newUser = new Domain.User { Auth0Id = request.UserId };
                await uow.UserRepository.Create(newUser);
                await uow.Commit();
                return mapper.Map<UserDTO>(newUser);
            }
            Console.WriteLine($"user: {user.Id}");
            return null;
        }
    }
}
