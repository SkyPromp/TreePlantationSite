using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    public class GetAllPlantationSitesPagedQuery: IRequest<PagedResponseDTO<PlantationSiteDTO>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
        public required string Search { get; set; }
    }

    public class GetAllPlantationSitesPagedQueryHandler: IRequestHandler<GetAllPlantationSitesPagedQuery, PagedResponseDTO<PlantationSiteDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllPlantationSitesPagedQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<PagedResponseDTO<PlantationSiteDTO>> Handle(GetAllPlantationSitesPagedQuery request, CancellationToken cancellationToken)
        {
            (IEnumerable<Domain.PlantationSite> items, int totalCount) = await uow.PlantationSiteRepository.GetAllPaged(request.PageNr, request.PageSize, request.Search);

            return new PagedResponseDTO<PlantationSiteDTO>
            {
                Items = mapper.Map<IEnumerable<PlantationSiteDTO>>(items),
                PageNumber = request.PageNr,
                PageSize = request.PageSize,
                TotalItems = totalCount
            };
        }
    }
}
