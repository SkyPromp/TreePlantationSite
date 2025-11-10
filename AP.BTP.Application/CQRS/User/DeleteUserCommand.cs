using AP.BTP.Application.Interfaces;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    /// <summary>
    /// Represents a command to delete a user from the system by their unique identifier.
    /// </summary>
    public class DeleteUserCommand : IRequest
    {  
        /// <summary>
        /// The unique identifier of the user to be deleted.
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="DeleteUserCommand"/>.
    /// Currently no specific validation rules are applied, but the class exists for future extensibility.
    /// </summary>
    public class DeleteUserCommandValidator: AbstractValidator<DeleteUserCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation logic.</param>
        public DeleteUserCommandValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="DeleteUserCommand"/> by removing the user with the specified Id from the repository.
    /// </summary>
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUnitOfWork uow;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        public DeleteUserCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Handles the <see cref="DeleteUserCommand"/> by deleting the specified user from the repository and committing the change.
        /// </summary>
        /// <param name="request">The command containing the Id of the user to delete.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await uow.UserRepository.Delete(request.Id);
            await uow.Commit();
        }
    }
}
