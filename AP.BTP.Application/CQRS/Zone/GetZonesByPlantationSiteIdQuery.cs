using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    public class GetAllZonesByPlantationSiteIdQuery: IRequest<IEnumerable<ZoneDTO>>
    {
        public int PlantationSiteId { get; set; }
    }

    public class GetAllZonesQueryValidator: AbstractValidator<GetAllZonesByPlantationSiteIdQuery>
    {
        public GetAllZonesQueryValidator(IUnitOfWork uow)
        {
        }
    }

    public class GetAllZonesQueryHandler: IRequestHandler<GetAllZonesByPlantationSiteIdQuery, IEnumerable<ZoneDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllZonesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        
        public async Task<IEnumerable<ZoneDTO>> Handle(GetAllZonesByPlantationSiteIdQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Zone> zones = await uow.ZoneRepository.GetAllByPlantationSiteId(request.PlantationSiteId);

            IEnumerable<ZoneDTO> zoneDTOs = mapper.Map<IEnumerable<ZoneDTO>>(zones);

            return zoneDTOs;
        }
    }
}
