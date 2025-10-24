using AP.BTP.Application.Interfaces;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    public class DeleteZoneCommand: IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteZoneCommandValidator: AbstractValidator<DeleteZoneCommand>
    {
        public DeleteZoneCommandValidator(IUnitOfWork uow)
        {
        }
    }

    public class DeleteZoneCommandHandler: IRequestHandler<DeleteZoneCommand>
    {
        private readonly IUnitOfWork uow;

        public DeleteZoneCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        
        public async Task Handle(DeleteZoneCommand request, CancellationToken cancellationToken)
        {
            this.uow.ZoneRepository.Delete(request.Id);
            await this.uow.Commit();
        }
    }
}
