using AP.BTP.Application.Interfaces;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    /// <summary>
    /// Represents a command to delete a zone from the system.
    /// </summary>
    public class DeleteZoneCommand: IRequest
    {
        /// <summary>
        /// The unique identifier of the zone to delete.
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="DeleteZoneCommand"/>.
    /// Currently no specific validation rules are applied, but the class is available for future use.
    /// </summary>
    public class DeleteZoneCommandValidator: AbstractValidator<DeleteZoneCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteZoneCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation logic.</param>
        public DeleteZoneCommandValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="DeleteZoneCommand"/> by removing the specified zone from the repository.
    /// </summary>
    public class DeleteZoneCommandHandler: IRequestHandler<DeleteZoneCommand>
    {
        private readonly IUnitOfWork uow;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteZoneCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        public DeleteZoneCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Handles the command by deleting the zone with the specified Id and committing the changes.
        /// </summary>
        /// <param name="request">The command containing the Id of the zone to delete.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        public async Task Handle(DeleteZoneCommand request, CancellationToken cancellationToken)
        {
            await this.uow.ZoneRepository.Delete(request.Id);
            await this.uow.Commit();
        }
    }
}
