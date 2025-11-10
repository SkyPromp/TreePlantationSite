using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    /// <summary>
    /// Represents a query to retrieve a user by their unique identifier.
    /// </summary>
    public class GetUserByIdQuery: IRequest<UserDTO>
    {
        /// <summary>
        /// The unique identifier of the user to retrieve.
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="GetUserByIdQuery"/>.
    /// Currently no specific validation rules are applied, but the class is available for future use.
    /// </summary>
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByIdQueryValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation logic.</param>
        public GetUserByIdQueryValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="GetUserByIdQuery"/> by retrieving the specified user from the repository and mapping it to a <see cref="UserDTO"/>.
    /// </summary>
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetUserByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="GetUserByIdQuery"/> by fetching the user with the specified Id and returning it as a <see cref="UserDTO"/>.
        /// </summary>
        /// <param name="request">The query containing the Id of the user to retrieve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The <see cref="UserDTO"/> representing the requested user.</returns>
        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.User? user = await uow.UserRepository.GetById(id: request.Id);
            UserDTO userDTO = mapper.Map<UserDTO>(user);

            return userDTO;
        }
    }
}