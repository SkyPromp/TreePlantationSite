using System.Linq.Expressions;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Tree
{
    /// <summary>
    /// Represents a command to add a new tree to the system.
    /// </summary>
    public class AddTreeCommand: IRequest<TreeDTO>
    {
        /// <summary>
        /// The data transfer object (DTO) containing the tree details to be added.
        /// </summary>
        public required TreeDTO Tree { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="AddTreeCommand"/>.
    /// Ensures that required fields are present and valid before adding a tree.
    /// </summary>
    public class AddTreeCommandValidator: AbstractValidator<AddTreeCommand>
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
        public AddTreeCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.Tree.Species)
                .NotEmpty()
                .WithMessage("Species name is required.");

            RuleFor(command => command.Tree.Id)
                .Equal(0)
                .WithMessage("Id should be zero when adding a tree.");

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
        private void ValidateMaintenancePlan(Expression<Func<AddTreeCommand, string?>> selector, string season)
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
    /// Handles the <see cref="AddTreeCommand"/> by adding a new tree to the database and returning the resulting DTO.
    /// </summary>
    public class AddTreeCommandHandler: IRequestHandler<AddTreeCommand, TreeDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTreeCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between DTOs and domain entities.</param>
        public AddTreeCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="AddTreeCommand"/> by mapping the provided DTO to a domain entity, saving it to the repository, and returning the resulting DTO.
        /// </summary>
        /// <param name="request">The command containing the tree details to add.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The <see cref="TreeDTO"/> representing the newly added tree.</returns>
        public async Task<TreeDTO> Handle(AddTreeCommand request, CancellationToken cancellationToken)
        {
            Domain.Tree tree = mapper.Map<Domain.Tree>(request.Tree);

            await uow.TreeRepository.Create(tree);
            await uow.Commit();

            return mapper.Map<TreeDTO>(tree);
        }
    }
}
