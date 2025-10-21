using AP.BTP.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    public class GetAllPlantationSitesPagedQuery: IRequest<PagedResponse<PlantationSiteDTO>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
        public required string Search { get; set; }
    }

    public class GetAllPlantationSitesPagedQueryHandler: IRequestHandler<GetAllPlantationSitesPagedQuery, PagedResponse<PlantationSiteDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllPlantationSitesPagedQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<PagedResponse<PlantationSiteDTO>> Handle(GetAllPlantationSitesPagedQuery request, CancellationToken cancellationToken)
        {
            var (items, totalCount) = await uow.PlantationSiteRepository.GetAllPaged(request.PageNr, request.PageSize, request.Search);

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
