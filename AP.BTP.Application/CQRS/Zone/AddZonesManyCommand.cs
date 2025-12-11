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
    public class AddZonesManyCommand: IRequest<ZoneDto>
    {
        /// <summary>
        /// The collection of zones to add.
        /// </summary>
        public required IEnumerable<ZoneDto> Zones { get; set; }
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

            RuleFor(command => command.Zones.Any(zone => string.IsNullOrWhiteSpace(zone.Name)))
                .Equal(false)
                .WithMessage("The zone name cannot be empty");

            RuleFor(command => command.Zones.Any(zone => zone.Size == null))
                .Equal(false)
                .WithMessage("The zone size cannot be null");

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

                    foreach (ZoneDto zone in zones)
                    {
                        Domain.PlantationSite? plantationSite = await uow.PlantationSiteRepository.GetById(zone.PlantationSiteId);

                        if (plantationSite == null) throw new ValidationException("Plantationsite must not be null when adding a zone.");
                        if(plantationSite.Zones.Any(z => z.Name == zone.Name)) return false;
                    }

                    return true;
                })
                .WithMessage("The zone name must be unique within a plantationsite.");

            RuleFor(command => command.Zones)
                .MustAsync(async (zones, cancellation) =>
                {
                    Dictionary<int, double> remainingAreaOfPlantationSite = new Dictionary<int, double>();

                    foreach (ZoneDto zone in zones)
                    {
                        if (!remainingAreaOfPlantationSite.Keys.Contains(zone.PlantationSiteId))
                        {
                            Domain.PlantationSite? plantationSite = await uow.PlantationSiteRepository.GetById(zone.PlantationSiteId);

                            if (plantationSite == null) throw new ValidationException("Plantationsite must not be null when adding a zone.");

                            remainingAreaOfPlantationSite.Add(zone.PlantationSiteId, plantationSite.Size);

                            foreach (Domain.Zone existingZone in plantationSite.Zones) remainingAreaOfPlantationSite[zone.PlantationSiteId] -= existingZone.Size ?? 0;
                        }

                        remainingAreaOfPlantationSite[zone.PlantationSiteId] -= zone.Size ?? 0;
                    }

                    return remainingAreaOfPlantationSite.Values.All(area => area >= 0);
                })
                .WithMessage("The sum of all the zone sizes must be smaller than the total plantationsite area.");
        }
    }

    /// <summary>
    /// Handles the <see cref="AddZonesManyCommand"/> by creating multiple zones in the repository and returning them as a <see cref="ZoneDto"/>.
    /// </summary>
    public class AddZonesManyCommandHandler: IRequestHandler<AddZonesManyCommand, ZoneDto>
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
        /// Handles the command by creating each zone in the database and returning the created zones mapped as a <see cref="ZoneDto"/>.
        /// </summary>
        /// <param name="request">The command containing the collection of zones to add.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The created zones as a <see cref="ZoneDto"/>.</returns>
        public async Task<ZoneDto> Handle(AddZonesManyCommand request, CancellationToken cancellationToken)
        {
            foreach(ZoneDto zone in request.Zones) if(zone.Name != null) zone.Name = zone.Name.Trim();  // Name cannot be null because of validator, but doesn't hurt to make sure
            
            IEnumerable<Domain.Zone> zones = mapper.Map<IEnumerable<Domain.Zone>>(request.Zones);

            foreach (Domain.Zone zone in zones) await uow.ZoneRepository.Create(zone);

            await uow.Commit();

            return mapper.Map<ZoneDto>(zones);
        }
    }
}
