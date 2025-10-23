using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    public class GetZoneByIdQuery: IRequest<ZoneDTO>
    {
        public int Id { get; set; }
    }

    public class GetZoneByIdQueryValidator: AbstractValidator<GetZoneByIdQuery>
    {
        public GetZoneByIdQueryValidator(IUnitOfWork uow)
        {
        }
    }

    public class GetZoneByIdQueryHandler: IRequestHandler<GetZoneByIdQuery, ZoneDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetZoneByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<ZoneDTO> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Zone? zone = await uow.ZoneRepository.GetById(id:request.Id);
            ZoneDTO zoneDTO = mapper.Map<ZoneDTO>(zone);

            return zoneDTO;
        }
    }
}
