using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Tree
{
    /// <summary>
    /// Represents a command to edit an existing tree in the system.
    /// </summary>
    public class EditTreeCommand: IRequest<TreeDTO>
    {
        /// <summary>
        /// The data transfer object (DTO) containing the updated tree details.
        /// </summary>
        public required TreeDTO Tree { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="EditTreeCommand"/>.
    /// Ensures that required fields are populated and that the tree Id is valid for editing.
    /// </summary>
    public class EditTreeCommandValidator: AbstractValidator<EditTreeCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditTreeCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential data validation checks.</param>
        public EditTreeCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.Tree.Species)
                .NotEmpty()
                .WithMessage("Species name is required.");

            RuleFor(command => command.Tree.Id)
                .NotEqual(0)
                .WithMessage("Id should not be zero when editing a tree.");
        }
    }

    /// <summary>
    /// Handles the <see cref="EditTreeCommand"/> by updating the specified tree in the database and returning the updated DTO.
    /// </summary>
    public class EditTreeCommandHandler: IRequestHandler<EditTreeCommand, TreeDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditTreeCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between DTOs and domain entities.</param>
        public EditTreeCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="EditTreeCommand"/> by mapping the provided DTO to a domain entity, updating it in the repository, committing the change, and returning the updated DTO.
        /// </summary>
        /// <param name="request">The command containing the updated tree details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The <see cref="TreeDTO"/> representing the updated tree.</returns>
        public async Task<TreeDTO> Handle(EditTreeCommand request, CancellationToken cancellationToken)
        {
            Domain.Tree tree = mapper.Map<Domain.Tree>(request.Tree);

            uow.TreeRepository.Update(tree);
            await uow.Commit();

            return request.Tree;
        }
    }
}
