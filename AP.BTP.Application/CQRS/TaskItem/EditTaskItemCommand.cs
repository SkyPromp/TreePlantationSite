using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TaskItem
{
    /// <summary>
    /// Represents a command to edit an existing task item in the system.
    /// </summary>
    public class EditTaskItemCommand: IRequest<TaskItemDTO>
    {
        /// <summary>
        /// The data transfer object (DTO) containing the updated task item details.
        /// </summary>
        public required TaskItemDTO TaskItem { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="EditTaskItemCommand"/>.
    /// Ensures that required fields are populated and that the task item Id is valid for editing.
    /// </summary>
    public class EditTaskItemCommandValidator: AbstractValidator<EditTaskItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditTaskItemCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential data validation checks.</param>
        public EditTaskItemCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.TaskItem.Id)
                .NotEqual(0)
                .WithMessage("Id should not be zero when editing a task item.");
        }
    }

    /// <summary>
    /// Handles the <see cref="EditTaskItemCommand"/> by updating the specified task item in the database and returning the updated DTO.
    /// </summary>
    public class EditTaskItemCommandHandler: IRequestHandler<EditTaskItemCommand, TaskItemDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditTaskItemCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between DTOs and domain entities.</param>
        public EditTaskItemCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="EditTaskItemCommand"/> by mapping the provided DTO to a domain entity, updating it in the repository, committing the change, and returning the updated DTO.
        /// </summary>
        /// <param name="request">The command containing the updated task item details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The <see cref="TaskItemDTO"/> representing the updated task item.</returns>
        public async Task<TaskItemDTO> Handle(EditTaskItemCommand request, CancellationToken cancellationToken)
        {
            Domain.TaskItem taskItem = mapper.Map<Domain.TaskItem>(request.TaskItem);

            uow.TaskItemRepository.Update(taskItem);
            await uow.Commit();

            return request.TaskItem;
        }
    }
}

