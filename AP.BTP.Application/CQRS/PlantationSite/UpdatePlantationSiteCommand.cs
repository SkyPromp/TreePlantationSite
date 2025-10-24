using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    public class UpdatePlantationSiteCommand : IRequest<PlantationSiteDTO>
    {
        public required PlantationSiteDTO UpdatedSite { get; set; }
    }
    
    public class UpdatePlantationSiteCommandValidator : AbstractValidator<UpdatePlantationSiteCommand>
    {
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

            RuleFor(command => command.UpdatedSite.GroundPlan)
                .NotEmpty()
                .WithMessage("Groundplan cannot be empty.");

            RuleFor(command => command.UpdatedSite.IsDeleted)
                .Equal(false)
                .WithMessage("Plantation site cannot be updated as 'deleted'."); 
        }
    }    

    public class UpdatePlantationSitesQueryHandler: IRequestHandler<UpdatePlantationSiteCommand, PlantationSiteDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public UpdatePlantationSitesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<PlantationSiteDTO> Handle(UpdatePlantationSiteCommand request, CancellationToken cancellationToken)
        {
            Domain.PlantationSite existingSite = await uow.PlantationSiteRepository.GetById(request.UpdatedSite.Id);

            existingSite.Name = request.UpdatedSite.Name;
            existingSite.Street = request.UpdatedSite.Street;
            existingSite.HouseNumber = request.UpdatedSite.HouseNumber;
            existingSite.City = request.UpdatedSite.City;
            existingSite.PostalCode = request.UpdatedSite.PostalCode;
            existingSite.Country = request.UpdatedSite.Country;
            existingSite.Size = request.UpdatedSite.Size;
            existingSite.GroundPlan = request.UpdatedSite.GroundPlan;

            uow.PlantationSiteRepository.Update(existingSite);
            await uow.Commit();
            
            return mapper.Map<PlantationSiteDTO>(existingSite);
        }
    }
}
