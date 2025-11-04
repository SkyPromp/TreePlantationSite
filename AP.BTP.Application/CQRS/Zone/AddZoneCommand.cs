using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    public class AddZoneCommand: IRequest<ZoneDTO>
    {
        public required ZoneDTO Zone { get; set; }
    }

    public class AddZoneCommandValidator: AbstractValidator<AddZoneCommand>
    {
        public AddZoneCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.Zone.Id)
                .Equal(0)
                .WithMessage("Id should be zero when adding a zone.");

            RuleFor(command => command.Zone.PlantationSiteId)
                .NotEqual(0)
                .WithMessage("The plantation site must already exist.");

            RuleFor(command => command.Zone.TreeId)
                .NotEqual(0)
                .WithMessage("The tree must already exist.");
        }
    }

    public class AddZoneCommandHandler: IRequestHandler<AddZoneCommand, ZoneDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddZoneCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        
        public async Task<ZoneDTO> Handle(AddZoneCommand request, CancellationToken cancellationToken)
        {
            Domain.Zone zone = mapper.Map<Domain.Zone>(request.Zone);

            await uow.ZoneRepository.Create(zone);
            await uow.Commit();

            return mapper.Map<ZoneDTO>(zone);
        }
    }
}
