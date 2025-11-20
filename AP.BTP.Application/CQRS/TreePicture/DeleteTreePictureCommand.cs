using AP.BTP.Application.Interfaces;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TreePicture
{
    public class DeleteTreePictureCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTreePictureCommandValidator : AbstractValidator<DeleteTreePictureCommand>
    {
        public DeleteTreePictureCommandValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Invalid picture Id.")
                .MustAsync(async (id, _) => 
                    await uow.TreePictureRepository.GetById(id) != null
                )
                .WithMessage("Tree picture does not exist.");
        }
    }

    public class DeleteTreePictureCommandHandler : IRequestHandler<DeleteTreePictureCommand>
    {
        private readonly IUnitOfWork uow;

        public DeleteTreePictureCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task Handle(DeleteTreePictureCommand request, CancellationToken cancellationToken)
        {
            Domain.TreePicture? treePicture = await uow.TreePictureRepository.GetById(request.Id);

            if (treePicture != null)
            {
                uow.TreePictureRepository.Delete(treePicture);
            }

            await uow.Commit();
        }
    }
}