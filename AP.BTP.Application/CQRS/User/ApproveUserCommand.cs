using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AP.BTP.Contracts.Enums;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    /// <summary>
    /// Represents a command to approve a user in the system by assigning a specified role.
    /// </summary>
    /// <remarks>
    /// This command requires the <see cref="UserId"/> of the user to be approved and the <see cref="Role"/> to assign.
    /// </remarks>
    public class ApproveUserCommand : IRequest<UserDto?>
    {
        /// <summary>
        /// The unique identifier of the user to approve.
        /// </summary>
        public required int UserId { get; set; }

        /// <summary>
        /// The role to assign to the approved user.
        /// </summary>
        public required string Role { get; set; }
    }

    /// <summary>
    /// Handles the <see cref="ApproveUserCommand"/> by approving the user in Auth0 and ensuring a corresponding domain user exists.
    /// </summary>
    public class ApproveUserCommandHandler : IRequestHandler<ApproveUserCommand, UserDto?>
    {
        private readonly IAuth0ManagementService auth0;
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
            this.auth0 = auth0;
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="ApproveUserCommand"/> by approving the user and assigning the specified role.
        /// </summary>
        /// <param name="request">The command containing user approval details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="UserDto"/> representing the approved user, or <c>null</c>.
        /// </returns>
        public async Task<UserDto?> Handle(ApproveUserCommand request, CancellationToken cancellationToken)
        {
            Domain.User? user = await uow.UserRepository.GetById(request.UserId);

            if (user == null)
                return null;

           await auth0.AssignRoleToUserAsync(user.Auth0Id, request.Role);

            user.IsApproved = true;
            user.Role = Enum.Parse<UserRole>(request.Role, true);

            uow.UserRepository.Update(user);

            await uow.Commit();

            return mapper.Map<UserDto>(user);
        }
    }
}
