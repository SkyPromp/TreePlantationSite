
using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    public class AddPlantationSiteCommand : IRequest<PlantationSiteDTO>
    {
        public required PlantationSiteDTO PlantationSite { get; set; }
    }

    public class AddPlantationSiteCommandValidator : AbstractValidator<AddPlantationSiteCommand>
    {
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

            RuleFor(command => command.PlantationSite.GroundPlan)
                .NotEmpty()
                .WithMessage("Groundplan cannot be empty.");

            RuleFor(command => command.PlantationSite.IsDeleted)
                .Equal(false)
                .WithMessage("Plantation site cannot be created as 'deleted'."); 
        }
    }
    
    public class AddPlantationSiteCOmmandHandler: IRequestHandler<AddPlantationSiteCommand, PlantationSiteDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddPlantationSiteCOmmandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<PlantationSiteDTO> Handle(AddPlantationSiteCommand request, CancellationToken cancellationToken)
        {
            Domain.PlantationSite plantationSite = mapper.Map<Domain.PlantationSite>(request.PlantationSite);

            await uow.PlantationSiteRepository.Create(plantationSite);
            await uow.Commit();

            return mapper.Map<PlantationSiteDTO>(plantationSite);
        }
    }
}