using AP.BTP.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    public class GetAllPlantationSitesQuery: IRequest<IEnumerable<PlantationSiteDTO>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllPlantationSitesQueryHandler: IRequestHandler<GetAllPlantationSitesQuery, IEnumerable<PlantationSiteDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllPlantationSitesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PlantationSiteDTO>> Handle(GetAllPlantationSitesQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<PlantationSiteDTO>>(await uow.PlantationSiteRepository.GetAll(request.PageNr, request.PageSize));
        }
    }
}
