using AP.BTP.Application.Interfaces;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Tree
{
    public class DeleteTreeCommand: IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTreeCommandValidator: AbstractValidator<DeleteTreeCommand>
    {
        public DeleteTreeCommandValidator(IUnitOfWork uow)
        {
        }
    }

    public class DeleteTreeCommandHandler: IRequestHandler<DeleteTreeCommand>
    {
        private readonly IUnitOfWork uow;

        public DeleteTreeCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        
        public async Task Handle(DeleteTreeCommand request, CancellationToken cancellationToken)
        {
            uow.TreeRepository.Delete(request.Id);
            await uow.Commit();
        }
    }
}
