using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    /// <summary>
    /// Represents a command to create a new plantation site in the system.
    /// </summary>
    public class AddPlantationSiteCommand : IRequest<PlantationSiteDTO>
    {
        /// <summary>
        /// The data transfer object (DTO) containing the details of the plantation site to be created.
        /// </summary>
        public required PlantationSiteDTO PlantationSite { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="AddPlantationSiteCommand"/>.
    /// </summary>
    public class AddPlantationSiteCommandValidator : AbstractValidator<AddPlantationSiteCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddPlantationSiteCommandValidator"/> class.
        /// Defines validation rules for the <see cref="AddPlantationSiteCommand.PlantationSite"/> properties.
        /// </summary>
        /// <param name="uow">The unit of work used for potential data validation or lookup operations.</param>
        public AddPlantationSiteCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.PlantationSite.Id)
                .Equal(0)
                .WithMessage("Id cannot be manually assigned.");

            RuleFor(command => command.PlantationSite.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.");

            RuleFor(command => command.PlantationSite.Street)
                .NotEmpty()
                .WithMessage("Street cannot be empty.");

            RuleFor(command => command.PlantationSite.HouseNumber)
                .NotEmpty()
                .MaximumLength(10)
                .Matches(@"^[0-9]+[a-zA-Z]?(/?[0-9]+)?(bis)?$")
                .WithMessage("Invalid house number format.");

            RuleFor(command => command.PlantationSite.City)
                .NotEmpty()
                .WithMessage("City cannot be empty.");

            RuleFor(command => command.PlantationSite.PostalCode)
                .InclusiveBetween(1000, 9999)
                .WithMessage("Postal code must be between 1000 and 9999.");

            RuleFor(command => command.PlantationSite.Country)
                .NotEmpty()
                .WithMessage("Country cannot be empty.");

            RuleFor(command => command.PlantationSite.Size)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Size must be zero or positive.");

            RuleFor(command => command.PlantationSite)
                .Must(plantationSite => plantationSite.Size >= (plantationSite.Zones?.Sum(zone => zone.Size) ?? 0))
                .WithMessage("The sum of the area of the zones must be smaller or equal to the total size of the plantationSite");

            RuleFor(command => command.PlantationSite.GroundPlan)
                .NotEmpty()
                .WithMessage("Groundplan cannot be empty.");
        }
    }

    /// <summary>
    /// Handles the <see cref="AddPlantationSiteCommand"/> by creating a new plantation site and returning its corresponding DTO.
    /// </summary>
    public class AddPlantationSiteCOmmandHandler: IRequestHandler<AddPlantationSiteCommand, PlantationSiteDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddPlantationSiteCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between domain entities and DTOs.</param>
        public AddPlantationSiteCOmmandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="AddPlantationSiteCommand"/> by adding a new plantation site to the database.
        /// </summary>
        /// <param name="request">The command containing the plantation site details to be created.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="PlantationSiteDTO"/> representing the newly created plantation site.</returns>
        public async Task<PlantationSiteDTO> Handle(AddPlantationSiteCommand request, CancellationToken cancellationToken)
        {
            Domain.PlantationSite plantationSite = mapper.Map<Domain.PlantationSite>(request.PlantationSite);

            await uow.PlantationSiteRepository.Create(plantationSite);
            await uow.Commit();

            return mapper.Map<PlantationSiteDTO>(plantationSite);
        }
    }
}