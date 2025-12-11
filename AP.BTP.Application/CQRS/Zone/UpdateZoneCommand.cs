using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    /// <summary>
    /// Represents a command to update an existing zone in the system.
    /// </summary>
    public class UpdateZoneCommand: IRequest<ZoneDto>
    {
        /// <summary>
        /// The zone data to update.
        /// </summary>
        public required ZoneDto Zone { get; set; }
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
                .WithMessage("Id should not be zero when updating a zone.");

            RuleFor(command => string.IsNullOrWhiteSpace(command.Zone.Name))
                .Equal(false)
                .WithMessage("The zone name cannot be empty");

            RuleFor(command => command.Zone.Size)
                .NotNull()
                .WithMessage("The zone size cannot be null");

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

                    if (plantationSite == null) throw new ValidationException("Plantationsite must not be null when adding a zone!");

                    return !plantationSite.Zones.Any(z => (z.Id != zone.Id) && (z.Name == zone.Name));
                })
                .WithMessage("The zone name must be unique within a plantationsite");

            RuleFor(command => command.Zone)
                .MustAsync(async (zone, cancellation) =>
                {
                    Domain.PlantationSite? plantationSite = await uow.PlantationSiteRepository.GetById(zone.PlantationSiteId);

                    if (plantationSite == null) throw new ValidationException("Plantationsite must not be null when adding a zone.");

                    return plantationSite.Size >= plantationSite.Zones.Where(z => z.Id != zone.Id).Sum(z => z.Size) + zone.Size;
                })
                .WithMessage("The sum of all the zone sizes must be smaller than the total plantationsite area.");
        }
    }

    /// <summary>
    /// Handles the <see cref="UpdateZoneCommand"/> by updating the specified zone in the repository
    /// and returning the updated zone as a <see cref="ZoneDto"/>.
    /// </summary>
    public class UpdateZoneCommandHandler: IRequestHandler<UpdateZoneCommand, ZoneDto>
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
        /// <returns>The updated <see cref="ZoneDto"/>.</returns>
        public async Task<ZoneDto> Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
        {
            if(request.Zone.Name != null) request.Zone.Name = request.Zone.Name.Trim();  // Name cannot be null because of validator, but doesn't hurt to make sure

            Domain.Zone zone = mapper.Map<Domain.Zone>(request.Zone);

            uow.ZoneRepository.Update(zone);
            await uow.Commit();

            return request.Zone;
        }
    }
}

