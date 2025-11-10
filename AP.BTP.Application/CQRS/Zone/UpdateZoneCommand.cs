using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    public class UpdateZoneCommand: IRequest<ZoneDTO>
    {
        public required ZoneDTO Zone { get; set; }
    }

    public class UpdateZoneCommandValidator: AbstractValidator<UpdateZoneCommand>
    {
        public UpdateZoneCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.Zone.Id)
                .NotEqual(0)
                .WithMessage("Id should not be zero when adding a zone.");

            RuleFor(command => command.Zone.PlantationSiteId)
                .NotEqual(0)
                .WithMessage("The plantation site must already exist.");

            RuleFor(command => command.Zone.TreeId)
                .NotEqual(0)
                .WithMessage("The tree must already exist.");
        }
    }

    public class UpdateZoneCommandHandler: IRequestHandler<UpdateZoneCommand, ZoneDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public UpdateZoneCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        
        public async Task<ZoneDTO> Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
        {
            Domain.Zone zone = mapper.Map<Domain.Zone>(request.Zone);

            uow.ZoneRepository.Update(zone);
            await uow.Commit();

            return request.Zone;
        }
    }
}

