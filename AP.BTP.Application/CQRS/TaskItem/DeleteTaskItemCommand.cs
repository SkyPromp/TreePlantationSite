using AP.BTP.Application.Interfaces;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TaskItem
{
    /// <summary>
    /// Represents a command to delete a task item from the system by its unique identifier.
    /// </summary>
    public class DeleteTaskItemCommand: IRequest
    {
        /// <summary>
        /// The unique identifier of the task item to be deleted.
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="DeleteTaskItemCommand"/>.
    /// Currently no specific validation rules are applied, but the class is available for future validation needs.
    /// </summary>
    public class DeleteTaskItemCommandValidator: AbstractValidator<DeleteTaskItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTaskItemCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation logic.</param>
        public DeleteTaskItemCommandValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="DeleteTaskItemCommand"/> by deleting the specified task item from the database.
    /// </summary>
    public class DeleteTaskItemCommandHandler: IRequestHandler<DeleteTaskItemCommand>
    {
        private readonly IUnitOfWork uow;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTaskItemCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        public DeleteTaskItemCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Handles the <see cref="DeleteTaskItemCommand"/> by removing the task item with the specified Id from the repository and committing the change.
        /// </summary>
        /// <param name="request">The command containing the Id of the task item to delete.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        public async Task Handle(DeleteTaskItemCommand request, CancellationToken cancellationToken)
        {
            await this.uow.TaskItemRepository.Delete(request.Id);
            await this.uow.Commit();
        }
    }
}
