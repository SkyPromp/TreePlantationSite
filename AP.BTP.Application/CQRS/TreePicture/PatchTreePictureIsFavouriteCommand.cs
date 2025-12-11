using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TreePicture
{
    /// <summary>
    /// Represents a command to partially update a TreePicture (e.g., updating only the IsFavourite value).
    /// </summary>
    public class PatchTreePictureCommand : IRequest<TreePictureDto>
    {
        /// <summary>
        /// The ID of the TreePicture to update.
        /// </summary>
        public int TreePictureId { get; set; }
        
        /// <summary>
        /// The favourite boolean to assign.
        /// </summary>
        public bool IsFavourite { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="PatchTreePictureCommand"/>.
    /// </summary>
    public class PatchTreePictureCommandValidator : AbstractValidator<PatchTreePictureCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatchTreePictureCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work for data validation.</param>
        public PatchTreePictureCommandValidator(IUnitOfWork uow)
        {   
            RuleFor(x => x.TreePictureId)
                .GreaterThan(0)
                .WithMessage("TreePictureId must be greater than zero.")
                .MustAsync(async (id, cancellation) =>
                {
                    bool exists = await uow.TreePictureRepository.GetById(id) != null;
                    return exists;
                })
                .WithMessage("TreePicture not found.");

            RuleFor(x => x)
                .MustAsync(async (command, cancellation) =>
                {
                    Domain.TreePicture? treePicture = await uow.TreePictureRepository.GetById(command.TreePictureId);

                    if (treePicture == null)
                        return false;

                    ICollection<Domain.TreePicture> pictures = await uow.TreePictureRepository
                        .GetAllByTreeId(treePicture.TreeId);

                    return !pictures.Any(p => p.IsFavourite && p.Id != command.TreePictureId);
                })
                .WithMessage("Only one picture per tree can be set as favourite.");
            }
    }

    /// <summary>
    /// Handles the <see cref="PatchTreePictureCommand"/> by partially updating the tree picture in the database.
    /// </summary>
    public class PatchTreePictureCommandHandler : IRequestHandler<PatchTreePictureCommand, TreePictureDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatchTreePictureCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between DTOs and domain entities.</param>
        public PatchTreePictureCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="PatchTreePictureCommand"/> by updating only the specified fields.
        /// </summary>
        /// <param name="request">The command containing the tree picture ID and fields to update.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The updated <see cref="TreePictureDto"/>.</returns>
        public async Task<TreePictureDto> Handle(PatchTreePictureCommand request, CancellationToken cancellationToken)
        {
            Domain.TreePicture? treePicture = await uow.TreePictureRepository.GetById(request.TreePictureId);
            
            if (treePicture == null)
                throw new KeyNotFoundException($"Task list with ID {request.TreePictureId} not found");

            treePicture.IsFavourite = request.IsFavourite;

            uow.TreePictureRepository.Update(treePicture);
            await uow.Commit();

            return mapper.Map<TreePictureDto>(treePicture);
        }
    }
}