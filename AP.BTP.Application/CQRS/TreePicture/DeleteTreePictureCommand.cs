using AP.BTP.Application.Interfaces;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TreePicture
{
    /// <summary>
    /// Represents a command to delete a tree picture from the system.
    /// </summary>    
    public class DeleteTreePictureCommand : IRequest
    {
        /// <summary>
        /// The ID of the tree picture to delete.
        /// </summary>        
        public int Id { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="DeleteTreePictureCommand"/>.
    /// Ensures that the ID is valid and that the picture exists.
    /// </summary>
    public class DeleteTreePictureCommandValidator : AbstractValidator<DeleteTreePictureCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTreePictureCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, used to check if the tree picture exists.</param>
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

    /// <summary>
    /// Handles the <see cref="DeleteTreePictureCommand"/> by removing the specified tree picture from the repository.
    /// </summary>
    public class DeleteTreePictureCommandHandler : IRequestHandler<DeleteTreePictureCommand>
    {
        private readonly IUnitOfWork uow;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTreePictureCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for repository operations.</param>
        public DeleteTreePictureCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Handles the command by deleting the tree picture if it exists and committing the changes.
        /// </summary>
        /// <param name="request">The command containing the ID of the picture to delete.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
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