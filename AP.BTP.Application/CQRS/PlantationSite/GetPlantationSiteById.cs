using AP.BTP.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    public class GetPlantationSiteByIdQuery: IRequest<PlantationSiteDTO>
    {
        public int Id { get; set; }
    }

    public class GetPlantationSiteByIdQueryHandler: IRequestHandler<GetPlantationSiteByIdQuery, PlantationSiteDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetPlantationSiteByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<PlantationSiteDTO> Handle(GetPlantationSiteByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.PlantationSite plantationSite = await uow.PlantationSiteRepository.GetById(request.Id);

            return mapper.Map<PlantationSiteDTO>(plantationSite);
        }
    }
}
