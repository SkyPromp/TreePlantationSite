using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    public class AddZonesManyCommand: IRequest<ZoneDTO>
    {
        public required IEnumerable<ZoneDTO> Zones { get; set; }
    }

    public class AddZonesManyCommandValidator: AbstractValidator<AddZonesManyCommand>
    {
        public AddZonesManyCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.Zones.All(zone => zone.Id == 0))
                .Equal(true)
                .WithMessage("All id's should be zero when adding a zone.");

            RuleFor(command => command.Zones.All(zone => zone.PlantationSiteId != 0))
                .Equal(true)
                .WithMessage("All plantation sites must already exist.");

            RuleFor(command => command.Zones.All(zone => zone.TreeId != 0))
                .Equal(true)
                .WithMessage("All trees must already exist.");
        }
    }

    public class AddZonesManyCommandHandler: IRequestHandler<AddZonesManyCommand, ZoneDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddZonesManyCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        
        public async Task<ZoneDTO> Handle(AddZonesManyCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Zone> zones = mapper.Map<IEnumerable<Domain.Zone>>(request.Zones);

            foreach (Domain.Zone zone in zones) await uow.ZoneRepository.Create(zone);

            await uow.Commit();

            return mapper.Map<ZoneDTO>(zones);
        }
    }
}
