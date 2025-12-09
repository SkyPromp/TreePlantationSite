using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    /// <summary>
    /// Represents a query to retrieve list of plantation sites, optionally filtered by a search term.
    /// </summary>
    public class GetAllPlantationSitesQuery : IRequest<IEnumerable<PlantationSiteDTO>>
    {
        /// <summary>
        /// The search term used to filter plantation sites by name or other criteria.
        /// </summary>
        public string? Search { get; set; }
    }

    /// <summary>
    /// Handles the <see cref="GetAllPlantationSitesQuery"/> by retrieving list of plantation sites from the database.
    /// </summary>
    public class GetAllPlantationSitesQueryHandler : IRequestHandler<GetAllPlantationSitesQuery, IEnumerable<PlantationSiteDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllPlantationSitesQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for accessing the plantation site repository.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetAllPlantationSitesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="GetAllPlantationSitesQuery"/> by retrieving and mapping List of plantation sites.
        /// </summary>
        /// <param name="request">The query containing a search term.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="List{T}"/> containing the plantation sites.
        /// </returns>
        public async Task<IEnumerable<PlantationSiteDTO>> Handle(GetAllPlantationSitesQuery request, CancellationToken cancellationToken)
        {
            if (request.Search == null) request.Search = "";

            IEnumerable<Domain.PlantationSite> items = await uow.PlantationSiteRepository.GetAllSearched(request.Search);

            return mapper.Map<IEnumerable<PlantationSiteDTO>>(items);
        }
    }
}
