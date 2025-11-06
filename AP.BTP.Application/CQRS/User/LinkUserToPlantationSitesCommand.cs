using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    public class LinkUserToPlantationSitesCommand : IRequest<UserDTO>
    {
        public required int UserId { get; set; }
        public required List<int> PlantationSiteIds { get; set; }
    }

    public class LinkUserToPlantationSitesCommandValidator : AbstractValidator<LinkUserToPlantationSitesCommand>
    {
        public LinkUserToPlantationSitesCommandValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.UserId)
                .MustAsync(async (userId, cancellation) => {
                    Domain.User? user = await uow.UserRepository.GetById(userId);
                    return user != null;
                })
                .WithMessage("User with the given Id does not exist.");

            RuleFor(x => x.PlantationSiteIds)
              .Must(list => list.Count <= 2)
              .WithMessage("Users can only have a maximum of 2 plantation sites.");

            RuleForEach(command => command.PlantationSiteIds)
                .MustAsync(async (plantationSiteId, cancellation) =>
            {
                Domain.PlantationSite? plantationSite = await uow.PlantationSiteRepository.GetById(plantationSiteId);
                return plantationSite != null;
            })
            .WithMessage((command, plantationSiteId) => $"Plantation site with id {plantationSiteId} does not exist.");
        }
    }

    public class LinkUserToPlantationSitesCommandHandler : IRequestHandler<LinkUserToPlantationSitesCommand, UserDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public LinkUserToPlantationSitesCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<UserDTO> Handle(LinkUserToPlantationSitesCommand request, CancellationToken cancellationToken)
        {
            Domain.User? user = await uow.UserRepository.GetById(request.UserId);

            user.PlantationSites.Clear();

            foreach (int id in request.PlantationSiteIds)
            {
                Domain.PlantationSite? site = await uow.PlantationSiteRepository.GetById(id);
                if (site != null)
                {
                    user.PlantationSites.Add(site);
                }
            }
            await uow.Commit();
            return mapper.Map<UserDTO>(user);
        }
    }
}

