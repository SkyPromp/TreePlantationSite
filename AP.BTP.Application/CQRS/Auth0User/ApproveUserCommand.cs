using AP.BTP.Application.CQRS.User;
using AP.BTP.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.Auth0User
{
    /// <summary>
    /// Represents a command to approve a user in the system by assigning a specified role.
    /// </summary>
    /// <remarks>
    /// This command requires the <see cref="UserId"/> of the user to be approved and the <see cref="Role"/> to assign.
    /// </remarks>
    public class ApproveUserCommand : IRequest<UserDTO?>
    {
        /// <summary>
        /// The unique identifier of the user to approve.
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// The role to assign to the approved user.
        /// </summary>
        public required string Role { get; set; }
    }

    /// <summary>
    /// Handles the <see cref="ApproveUserCommand"/> by approving the user in Auth0 and ensuring a corresponding domain user exists.
    /// </summary>
    public class ApproveUserCommandHandler : IRequestHandler<ApproveUserCommand, UserDTO?>
    {
        private readonly IAuth0ManagementService _auth0;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApproveUserCommandHandler"/> class.
        /// </summary>
        /// <param name="auth0">The Auth0 management service used to approve users.</param>
        /// <param name="uow">The unit of work for database operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public ApproveUserCommandHandler(IAuth0ManagementService auth0, IUnitOfWork uow, IMapper mapper)
        {
            _auth0 = auth0;
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="ApproveUserCommand"/> by approving the user in Auth0,
        /// creating a new domain user if one does not already exist, and returning the corresponding <see cref="UserDTO"/>.
        /// </summary>
        /// <param name="request">The command containing user approval details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="UserDTO"/> representing the approved user, or <c>null</c> if the user already exists.
        /// </returns>
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

            return null;
        }
    }
}
