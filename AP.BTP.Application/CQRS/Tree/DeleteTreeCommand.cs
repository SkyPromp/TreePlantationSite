using AP.BTP.Application.Interfaces;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Tree
{
    /// <summary>
    /// Represents a command to delete a tree from the system by its unique identifier.
    /// </summary>
    public class DeleteTreeCommand: IRequest
    {
        /// <summary>
        /// The unique identifier of the tree to be deleted.
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="DeleteTreeCommand"/>.
    /// Currently no specific validation rules are applied, but the class is available for future validation needs.
    /// </summary>
    public class DeleteTreeCommandValidator: AbstractValidator<DeleteTreeCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTreeCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation logic.</param>
        public DeleteTreeCommandValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="DeleteTreeCommand"/> by deleting the specified tree from the database.
    /// </summary>
    public class DeleteTreeCommandHandler: IRequestHandler<DeleteTreeCommand>
    {
        private readonly IUnitOfWork uow;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTreeCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        public DeleteTreeCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Handles the <see cref="DeleteTreeCommand"/> by removing the tree with the specified Id from the repository and committing the change.
        /// </summary>
        /// <param name="request">The command containing the Id of the tree to delete.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        public async Task Handle(DeleteTreeCommand request, CancellationToken cancellationToken)
        {
            await this.uow.TreeRepository.Delete(request.Id);
            await this.uow.Commit();
        }
    }
}
