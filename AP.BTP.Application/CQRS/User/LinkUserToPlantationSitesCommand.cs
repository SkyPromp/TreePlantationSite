using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    /// <summary>
    /// Represents a command to link a user to one or more plantation sites.
    /// </summary>
    public class LinkUserToPlantationSitesCommand: IRequest<UserDTO>
    {
        /// <summary>
        /// The unique identifier of the user to link to plantation sites.
        /// </summary>
        public required int UserId { get; set; }

        /// <summary>
        /// The list of plantation site IDs to link the user to.
        /// Maximum of 2 plantation sites is allowed.
        /// </summary>
        public required List<int> PlantationSiteIds { get; set; }
    }

    /// <summary>
    /// Provides validation rules for <see cref="LinkUserToPlantationSitesCommand"/>.
    /// Ensures the user exists, limits the number of plantation sites to 2, prevents duplicate IDs, and checks that each plantation site exists.
    /// </summary>
    public class LinkUserToPlantationSitesCommandValidator: AbstractValidator<LinkUserToPlantationSitesCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkUserToPlantationSitesCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used to validate existence of users and plantation sites.</param>
        public LinkUserToPlantationSitesCommandValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.UserId)
                .MustAsync(async (userId, cancellation) =>
                {
                    Domain.User? user = await uow.UserRepository.GetById(userId);
                    return user != null;
                })
                .WithMessage("User with the given Id does not exist.");

            RuleFor(x => x.PlantationSiteIds)
                .Must(ids => ids.Count <= 2)
                .WithMessage("Users can only have a maximum of 2 plantation sites.");

            RuleFor(x => x.PlantationSiteIds)
                .Must(ids => ids.Distinct().Count() == ids.Count)
                .WithMessage("The 2 plantation sites cannot have the same id");

            RuleForEach(command => command.PlantationSiteIds)
                .MustAsync(async (plantationSiteId, cancellation) =>
            {
                Domain.PlantationSite? plantationSite = await uow.PlantationSiteRepository.GetById(plantationSiteId);
                return plantationSite != null;
            })
            .WithMessage((command, plantationSiteId) => $"Plantation site with id {plantationSiteId} does not exist.");
        }
    }

    /// <summary>
    /// Handles the <see cref="LinkUserToPlantationSitesCommand"/> by linking the specified user to the given plantation sites and returning the updated user as a <see cref="UserDTO"/>.
    /// </summary>
    public class LinkUserToPlantationSitesCommandHandler : IRequestHandler<LinkUserToPlantationSitesCommand, UserDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkUserToPlantationSitesCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public LinkUserToPlantationSitesCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the command by linking the user to the specified plantation sites and returning the updated user DTO.
        /// </summary>
        /// <param name="request">The command containing the user ID and the list of plantation site IDs.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The updated <see cref="UserDTO"/> with linked plantation sites.</returns>
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

