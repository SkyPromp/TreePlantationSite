using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    /// <summary>
    /// Represents a command to update an existing plantation site in the system.
    /// </summary>
    public class UpdatePlantationSiteCommand : IRequest<PlantationSiteDTO>
    {
        /// <summary>
        /// The DTO containing the updated details of the plantation site.
        /// </summary>
        public required PlantationSiteDTO UpdatedSite { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="UpdatePlantationSiteCommand"/>.
    /// Ensures that all required fields are populated and have valid values.
    /// </summary>
    public class UpdatePlantationSiteCommandValidator : AbstractValidator<UpdatePlantationSiteCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatePlantationSiteCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential data validation.</param>
        public UpdatePlantationSiteCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.UpdatedSite.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.");

            RuleFor(command => command.UpdatedSite.Street)
                .NotEmpty()
                .WithMessage("Street cannot be empty.");

            RuleFor(command => command.UpdatedSite.HouseNumber)
                .NotEmpty()
                .MaximumLength(10)
                .Matches(@"^[0-9]+[a-zA-Z]?(/?[0-9]+)?(bis)?$")
                .WithMessage("Invalid house number format.");

            RuleFor(command => command.UpdatedSite.City)
                .NotEmpty()
                .WithMessage("City cannot be empty.");

            RuleFor(command => command.UpdatedSite.PostalCode)
                .InclusiveBetween(1000, 9999)
                .WithMessage("Postal code must be between 1000 and 9999.");

            RuleFor(command => command.UpdatedSite.Country)
                .NotEmpty()
                .WithMessage("Country cannot be empty.");

            RuleFor(command => command.UpdatedSite.Size)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Size must be zero or positive.");

            RuleFor(command => command.UpdatedSite)
                .Must(plantationSite => plantationSite.Size >= (plantationSite.Zones?.Sum(zone => zone.Size) ?? 0))
                .WithMessage("The sum of the area of the zones must be smaller or equal to the total size of the plantationSite");

            RuleFor(command => command.UpdatedSite.GroundPlan)
                .NotEmpty()
                .WithMessage("Groundplan cannot be empty.");
        }
    }

    /// <summary>
    /// Handles the <see cref="UpdatePlantationSiteCommand"/> by updating the plantation site in the database and returning the updated DTO.
    /// </summary>
    public class UpdatePlantationSitesQueryHandler: IRequestHandler<UpdatePlantationSiteCommand, PlantationSiteDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatePlantationSitesQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between DTOs and domain entities.</param>
        public UpdatePlantationSitesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="UpdatePlantationSiteCommand"/> by updating the plantation site in the repository and committing the changes.
        /// </summary>
        /// <param name="request">The command containing the updated plantation site details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The updated <see cref="PlantationSiteDTO"/>.</returns>
        public async Task<PlantationSiteDTO> Handle(UpdatePlantationSiteCommand request, CancellationToken cancellationToken)
        {
            Domain.PlantationSite plantationSite = mapper.Map<Domain.PlantationSite>(request.UpdatedSite);
            uow.PlantationSiteRepository.Update(plantationSite);  // If you really don't want to update is deleted (which shouldn't be in a DTO anyways) you can manually change the isDeleted value from plantationSite after the mapping
            await uow.Commit();
            
            return mapper.Map<PlantationSiteDTO>(request.UpdatedSite);
        }
    }
}

