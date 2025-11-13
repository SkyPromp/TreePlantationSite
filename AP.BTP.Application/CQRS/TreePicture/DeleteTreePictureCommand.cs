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