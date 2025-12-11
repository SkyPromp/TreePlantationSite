using System.Linq.Expressions;
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
    public class EditTreeCommand: IRequest<TreeDto>
    {
        /// <summary>
        /// The data transfer object (DTO) containing the updated tree details.
        /// </summary>
        public required TreeDto Tree { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="EditTreeCommand"/>.
    /// Ensures that required fields are populated and that the tree Id is valid for editing.
    /// </summary>
    public class EditTreeCommandValidator: AbstractValidator<EditTreeCommand>
    {
        /// <summary>
        /// A collection of file extensions allowed for maintenance plan documents.
        /// </summary> 
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp", ".pdf" };

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTreeCommandValidator"/> class.
        /// Configures validation rules for species, ID, and each seasonal maintenance plan.
        /// </summary>
        /// <param name="uow">The unit of work, provided for potential data-dependent validation.</param>
        public EditTreeCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.Tree.Species)
                .NotEmpty()
                .WithMessage("Species name is required.");

            RuleFor(command => command.Tree.Id)
                .NotEqual(0)
                .WithMessage("Id should not be zero when editing a tree.");

            RuleFor(command => command.Tree)
                .MustAsync(async (tree, cancellation) =>
                {
                    IEnumerable<Domain.Tree> trees = await uow.TreeRepository.GetAll();

                    if (trees == null) return true;

                    return !trees.Any(t => (t.Id != tree.Id) && (t.Species == tree.Species));
                })
                .WithMessage("The tree species must be unique.");

            ValidateMaintenancePlan(command => command.Tree.MaintenancePlanSpring, "spring");
            ValidateMaintenancePlan(command => command.Tree.MaintenancePlanSummer, "summer");
            ValidateMaintenancePlan(command => command.Tree.MaintenancePlanAutumn, "autumn");
            ValidateMaintenancePlan(command => command.Tree.MaintenancePlanWinter, "winter");                
        }

        /// <summary>
        /// Adds a validation rule for a maintenance plan field.
        /// The plan is optional; however, when provided, its file extension must be one of the allowed types.
        /// </summary>
        /// <param name="selector">An expression selecting the maintenance plan field to validate.</param>
        /// <param name="season">A string identifying the season (used in the error message).</param>
        private void ValidateMaintenancePlan(Expression<Func<EditTreeCommand, string?>> selector, string season)
        {
            RuleFor(selector)
                .Must(path =>
                {
                    if (string.IsNullOrWhiteSpace(path))
                        return true;

                    string ext = Path.GetExtension(path).ToLower();
                    return AllowedExtensions.Contains(ext);
                })
                .WithMessage($"Unsupported {season} maintenance plan file type.");
        }        
    }

    /// <summary>
    /// Handles the <see cref="EditTreeCommand"/> by updating the specified tree in the database and returning the updated DTO.
    /// </summary>
    public class EditTreeCommandHandler: IRequestHandler<EditTreeCommand, TreeDto>
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
        /// <returns>The <see cref="TreeDto"/> representing the updated tree.</returns>
        public async Task<TreeDto> Handle(EditTreeCommand request, CancellationToken cancellationToken)
        {
            Domain.Tree tree = mapper.Map<Domain.Tree>(request.Tree);

            uow.TreeRepository.Update(tree);
            await uow.Commit();

            return request.Tree;
        }
    }
}
