using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    public class LinkUserToPlantationSitesCommand : IRequest<Unit>
    {
        public required string Auth0Id { get; set; }
        public required List<int> PlantationSiteIds { get; set; }
    }

    public class LinkUserToPlantationSitesCommandValidator : AbstractValidator<LinkUserToPlantationSitesCommand>
    {
        public LinkUserToPlantationSitesCommandValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.Auth0Id)
                .MustAsync(async (auth0Id, cancellation) => {
                    Domain.User? user = await uow.UserRepository.GetUserByAuth0Id(auth0Id);
                    return user != null;
                })
                .WithMessage("User with the given Auth0Id does not exist.");

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

    public class LinkUserToPlantationSitesCommandHandler : IRequestHandler<LinkUserToPlantationSitesCommand, Unit>
    {
        private readonly IUnitOfWork uow;

        public LinkUserToPlantationSitesCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<Unit> Handle(LinkUserToPlantationSitesCommand request, CancellationToken cancellationToken)
        {
            Domain.User? user = await uow.UserRepository.GetUserByAuth0Id(request.Auth0Id);

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
            return Unit.Value;
        }
    }
}

