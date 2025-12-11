using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TreePicture
{
    /// <summary>
    /// Represents a command to add a new picture for a tree in the system.
    /// </summary>
    public class AddTreePictureCommand : IRequest<TreePictureDto>
    {
        /// <summary>
        /// The data transfer object (DTO) containing the tree picture details to be added.
        /// </summary>
        public required TreePictureDto TreePicture { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="AddTreePictureCommand"/>.
    /// Ensures that required fields are present, valid, and the referenced tree exists.
    /// </summary>
    public class AddTreePictureCommandValidator : AbstractValidator<AddTreePictureCommand>
    {
        /// <summary>
        /// Defines the set of allowed image file extensions for tree pictures.
        /// Used to validate that <see cref="TreePicture.Path"/> has a supported format.
        /// </summary>
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp", ".bmp" };
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTreePictureCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, used to verify the existence of the referenced tree.</param>        
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
                    return AllowedExtensions.Contains(ext);
                })
                .WithMessage("Unsupported image file type.");
        }
    }

    /// <summary>
    /// Handles the <see cref="AddTreePictureCommand"/> by adding a new tree picture to the database and returning the resulting DTO.
    /// </summary>    
    public class AddTreePictureCommandHandler : IRequestHandler<AddTreePictureCommand, TreePictureDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTreePictureCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between DTOs and domain entities.</param>
        public AddTreePictureCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="AddTreePictureCommand"/> by mapping the provided DTO to a domain entity,
        /// saving it to the repository, and returning the resulting DTO.
        /// </summary>
        /// <param name="request">The command containing the tree picture details to add.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The <see cref="TreePictureDto"/> representing the newly added tree picture.</returns>
        public async Task<TreePictureDto> Handle(AddTreePictureCommand request, CancellationToken cancellationToken)
        {
            Domain.TreePicture treePicture = mapper.Map<Domain.TreePicture>(request.TreePicture);

            await uow.TreePictureRepository.Create(treePicture);
            await uow.Commit();

            return mapper.Map<TreePictureDto>(treePicture);
        }
    }
}