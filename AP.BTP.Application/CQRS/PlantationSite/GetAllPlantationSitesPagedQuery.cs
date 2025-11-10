using AP.BTP.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    /// <summary>
    /// Represents a query to retrieve a paginated list of plantation sites, optionally filtered by a search term.
    /// </summary>
    public class GetAllPlantationSitesPagedQuery: IRequest<PagedResponse<PlantationSiteDTO>>
    {
        /// <summary>
        /// The page number to retrieve.
        /// </summary>
        public int PageNr { get; set; }

        /// <summary>
        /// The number of plantation sites to include per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The search term used to filter plantation sites by name or other criteria.
        /// </summary>
        public string? Search { get; set; }
    }

    /// <summary>
    /// Handles the <see cref="GetAllPlantationSitesPagedQuery"/> by retrieving a paginated list of plantation sites from the database.
    /// </summary>
    public class GetAllPlantationSitesPagedQueryHandler: IRequestHandler<GetAllPlantationSitesPagedQuery, PagedResponse<PlantationSiteDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllPlantationSitesPagedQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for accessing the plantation site repository.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetAllPlantationSitesPagedQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="GetAllPlantationSitesPagedQuery"/> by retrieving and mapping a paginated set of plantation sites.
        /// </summary>
        /// <param name="request">The query containing pagination parameters and a search term.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="PagedResponse{T}"/> containing the paginated plantation sites and related pagination metadata.
        /// </returns>
        public async Task<PagedResponse<PlantationSiteDTO>> Handle(GetAllPlantationSitesPagedQuery request, CancellationToken cancellationToken)
        {
            if (request.Search == null) request.Search = "";

            (IEnumerable<Domain.PlantationSite> items, int totalCount) = await uow.PlantationSiteRepository.GetAllPaged(request.PageNr, request.PageSize, request.Search);

            return new PagedResponse<PlantationSiteDTO>
            {
                Items = mapper.Map<IEnumerable<PlantationSiteDTO>>(items),
                PageNumber = request.PageNr,
                PageSize = request.PageSize,
                TotalItems = totalCount
            };
        }
    }
}
