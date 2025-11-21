using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    /// <summary>
    /// Represents a command to add a new zone to the system.
    /// </summary>
    public class AddZoneCommand: IRequest<ZoneDTO>
    {
        /// <summary>
        /// The zone data to add.
        /// </summary>
        public required ZoneDTO Zone { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="AddZoneCommand"/>.
    /// Ensures that the zone's Id is zero, and that associated PlantationSite and Tree exist.
    /// </summary>
    public class AddZoneCommandValidator: AbstractValidator<AddZoneCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddZoneCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used to check existing entities.</param>
        public AddZoneCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.Zone.Id)
                .Equal(0)
                .WithMessage("Id should be zero when adding a zone.");

            RuleFor(command => command.Zone.PlantationSiteId)
                .NotEqual(0)
                .WithMessage("The plantation site must already exist.");

            RuleFor(command => command.Zone.TreeId)
                .NotEqual(0)
                .WithMessage("The tree must already exist.");

            RuleFor(command => command.Zone)
                .MustAsync(async (zone, cancellation) =>
                {
                    Domain.PlantationSite? plantationSite = await uow.PlantationSiteRepository.GetById(zone.PlantationSiteId);

                    if (plantationSite == null) throw new ValidationException("Plantationsite must not be null when adding a zone.");

                    return plantationSite.Zones.Count(z => z.Name == zone.Name) == 0;
                })
                .WithMessage("The zone name must be unique within a plantationsite.");
        }
    }

    /// <summary>
    /// Handles the <see cref="AddZoneCommand"/> by creating a new zone in the repository and returning it as a <see cref="ZoneDTO"/>.
    /// </summary>
    public class AddZoneCommandHandler: IRequestHandler<AddZoneCommand, ZoneDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddZoneCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between domain entities and DTOs.</param>
        public AddZoneCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="AddZoneCommand"/> by creating the specified zone in the database
        /// and returning the newly created zone as a <see cref="ZoneDTO"/>.
        /// </summary>
        /// <param name="request">The command containing the zone to add.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The newly created <see cref="ZoneDTO"/>.</returns>
        public async Task<ZoneDTO> Handle(AddZoneCommand request, CancellationToken cancellationToken)
        {
            Domain.Zone zone = mapper.Map<Domain.Zone>(request.Zone);

            await uow.ZoneRepository.Create(zone);
            await uow.Commit();

            return mapper.Map<ZoneDTO>(zone);
        }
    }
}
