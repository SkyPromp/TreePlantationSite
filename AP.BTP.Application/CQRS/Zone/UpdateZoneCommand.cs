using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    /// <summary>
    /// Represents a command to update an existing zone in the system.
    /// </summary>
    public class UpdateZoneCommand: IRequest<ZoneDTO>
    {
        /// <summary>
        /// The zone data to update.
        /// </summary>
        public required ZoneDTO Zone { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="UpdateZoneCommand"/>.
    /// Ensures that the zone has a valid Id and that the associated plantation site and tree exist.
    /// </summary>
    public class UpdateZoneCommandValidator: AbstractValidator<UpdateZoneCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateZoneCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for potential validation logic.</param>
        public UpdateZoneCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.Zone.Id)
                .NotEqual(0)
                .WithMessage("Id should not be zero when adding a zone.");

            RuleFor(command => command.Zone.PlantationSiteId)
                .NotEqual(0)
                .WithMessage("The plantation site must already exist.");

            RuleFor(command => command.Zone.TreeId)
                .NotEqual(0)
                .WithMessage("The tree must already exist.");
        }
    }

    /// <summary>
    /// Handles the <see cref="UpdateZoneCommand"/> by updating the specified zone in the repository
    /// and returning the updated zone as a <see cref="ZoneDTO"/>.
    /// </summary>
    public class UpdateZoneCommandHandler: IRequestHandler<UpdateZoneCommand, ZoneDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateZoneCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between domain entities and DTOs.</param>
        public UpdateZoneCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the command by updating the zone in the database and committing the changes.
        /// </summary>
        /// <param name="request">The command containing the zone to update.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The updated <see cref="ZoneDTO"/>.</returns>
        public async Task<ZoneDTO> Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
        {
            Domain.Zone zone = mapper.Map<Domain.Zone>(request.Zone);

            uow.ZoneRepository.Update(zone);
            await uow.Commit();

            return request.Zone;
        }
    }
}

