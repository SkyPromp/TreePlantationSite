using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TaskItem
{
    /// <summary>
    /// Represents a command to add a new task item to the system.
    /// </summary>
    public class AddTaskItemCommand: IRequest<TaskItemDto>
    {
        /// <summary>
        /// The data transfer object (DTO) containing the task item details to be added.
        /// </summary>
        public required TaskItemDto TaskItem { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="AddTaskItemCommand"/>.
    /// Ensures that required fields are present and valid before adding a task item.
    /// </summary>
    public class AddTaskItemCommandValidator: AbstractValidator<AddTaskItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTaskItemCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential data validation checks.</param>
        public AddTaskItemCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.TaskItem.Id)
                .Equal(0)
                .WithMessage("Id should be zero when adding a task item.");

            RuleFor(x => x.TaskItem.DurationInMinutes)
                .GreaterThan(0)
                .WithMessage("Duration must be greater than 0 minutes")
                .LessThanOrEqualTo(480)
                .WithMessage("Duration cannot exceed 8 hours (480 minutes)");

            RuleFor(x => x.TaskItem)
                .MustAsync(async (taskItem, cancellation) =>
                {
                    Domain.TaskList? taskList = await uow.TaskListRepository.GetById(taskItem.TaskListId);
                    if (taskList == null) return true;
                    
                    int totalMinutes = taskList.TaskItems
                        .Where(t => !t.IsDeleted && t.Id != taskItem.Id)
                        .Sum(t => t.DurationInMinutes);
                    
                    return (totalMinutes + taskItem.DurationInMinutes) <= 480;
                })
                .WithMessage("Total task duration for this day cannot exceed 8 hours (480 minutes)");                             
        }
    }

    /// <summary>
    /// Handles the <see cref="AddTaskItemCommand"/> by adding a new task item to the database and returning the resulting DTO.
    /// </summary>
    public class AddTaskItemCommandHandler: IRequestHandler<AddTaskItemCommand, TaskItemDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTaskItemCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between DTOs and domain entities.</param>
        public AddTaskItemCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="AddTaskItemCommand"/> by mapping the provided DTO to a domain entity, saving it to the repository, and returning the resulting DTO.
        /// </summary>
        /// <param name="request">The command containing the task item details to add.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The <see cref="TaskItemDto"/> representing the newly added task item.</returns>
        public async Task<TaskItemDto> Handle(AddTaskItemCommand request, CancellationToken cancellationToken)
        {
            Domain.TaskItem taskItem = mapper.Map<Domain.TaskItem>(request.TaskItem);

            await uow.TaskItemRepository.Create(taskItem);
            await uow.Commit();

            return mapper.Map<TaskItemDto>(taskItem);
        }
    }
}
