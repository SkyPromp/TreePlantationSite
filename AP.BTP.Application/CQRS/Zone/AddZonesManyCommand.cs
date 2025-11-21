using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    /// <summary>
    /// Represents a command to add multiple zones to the system at once.
    /// </summary>
    public class AddZonesManyCommand: IRequest<ZoneDTO>
    {
        /// <summary>
        /// The collection of zones to add.
        /// </summary>
        public required IEnumerable<ZoneDTO> Zones { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="AddZonesManyCommand"/>.
    /// Ensures that all zones have an Id of zero, and that associated plantation sites and trees exist.
    /// </summary>
    public class AddZonesManyCommandValidator: AbstractValidator<AddZonesManyCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddZonesManyCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation logic.</param>
        public AddZonesManyCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.Zones.All(zone => zone.Id == 0))
                .Equal(true)
                .WithMessage("All id's should be zero when adding a zone.");

            RuleFor(command => command.Zones.All(zone => zone.PlantationSiteId != 0))
                .Equal(true)
                .WithMessage("All plantation sites must already exist.");

            RuleFor(command => command.Zones.All(zone => zone.TreeId != 0))
                .Equal(true)
                .WithMessage("All trees must already exist.");

            RuleFor(command => command.Zones)
                .MustAsync(async (zones, cancellation) =>
                {
                    if (zones.GroupBy(z => z.Name).Any(zoneNames => zoneNames.Count() != 1)) return false;

                    foreach (ZoneDTO zone in zones)
                    {
                        var plantationSite = await uow.PlantationSiteRepository.GetById(zone.PlantationSiteId);

                        if (plantationSite == null) throw new ValidationException("Plantationsite must not be null when adding a zone!");
                        if(plantationSite.Zones.Count(z => z.Name == zone.Name) != 0) return false;
                    }

                    return true;
                })
                .WithMessage("The zone name must be unique within a plantationsite");

        }
    }

    /// <summary>
    /// Handles the <see cref="AddZonesManyCommand"/> by creating multiple zones in the repository and returning them as a <see cref="ZoneDTO"/>.
    /// </summary>
    public class AddZonesManyCommandHandler: IRequestHandler<AddZonesManyCommand, ZoneDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddZonesManyCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between domain entities and DTOs.</param>
        public AddZonesManyCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the command by creating each zone in the database and returning the created zones mapped as a <see cref="ZoneDTO"/>.
        /// </summary>
        /// <param name="request">The command containing the collection of zones to add.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The created zones as a <see cref="ZoneDTO"/>.</returns>
        public async Task<ZoneDTO> Handle(AddZonesManyCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Zone> zones = mapper.Map<IEnumerable<Domain.Zone>>(request.Zones);

            foreach (Domain.Zone zone in zones) await uow.ZoneRepository.Create(zone);

            await uow.Commit();

            return mapper.Map<ZoneDTO>(zones);
        }
    }
}
