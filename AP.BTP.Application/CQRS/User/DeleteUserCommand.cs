using AP.BTP.Application.Interfaces;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator(IUnitOfWork uow)
        {
        }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUnitOfWork uow;

        public DeleteUserCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await uow.UserRepository.Delete(request.Id);
            await uow.Commit();
        }
    }
}
