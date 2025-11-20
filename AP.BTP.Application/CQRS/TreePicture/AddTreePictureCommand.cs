using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TreePicture
{
    public class AddTreePictureCommand : IRequest<TreePictureDTO>
    {
        public required TreePictureDTO TreePicture { get; set; }
    }

    public class AddTreePictureCommandValidator : AbstractValidator<AddTreePictureCommand>
    {
        public AddTreePictureCommandValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.TreePicture.Path)
                .NotEmpty().WithMessage("Picture path cannot be empty.");

            RuleFor(x => x.TreePicture.TreeId)
                .GreaterThan(0).WithMessage("Invalid TreeId.")
                .MustAsync(async (id, _) => await uow.TreeRepository.GetById(id) != null)
                .WithMessage("Tree does not exist.");

            RuleFor(x => x.TreePicture.Path)
                .Must(path =>
                {
                    string ext = Path.GetExtension(path).ToLower();
                    return new[] { ".jpg", ".jpeg", ".png", ".webp", ".bmp" }.Contains(ext);
                })
                .WithMessage("Unsupported image file type.");
        }
    }
    
    public class AddTreePictureCommandHandler : IRequestHandler<AddTreePictureCommand, TreePictureDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddTreePictureCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<TreePictureDTO> Handle(AddTreePictureCommand request, CancellationToken cancellationToken)
        {
            Domain.TreePicture treePicture = mapper.Map<Domain.TreePicture>(request.TreePicture);

            await uow.TreePictureRepository.Create(treePicture);
            await uow.Commit();

            return mapper.Map<TreePictureDTO>(treePicture);
        }
    }
}