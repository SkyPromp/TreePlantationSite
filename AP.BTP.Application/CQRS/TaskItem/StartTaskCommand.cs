using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TaskItem
{
    /// <summary>
    /// Represents a command to start the task.
    /// </summary>
    public class StartTaskCommand: IRequest<TaskItemDTO>
    {
        /// <summary>
        /// The data transfer object (DTO) containing the task item to be started.
        /// </summary>
        public required TaskItemDTO TaskItem { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="StartTaskCommand"/>.
    /// Ensures that required fields are present and valid before starting the task item.
    /// </summary>
    public class StartTaskCommandValidator: AbstractValidator<StartTaskCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartTaskCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential data validation checks.</param>
        public StartTaskCommandValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="StartTaskCommand"/> to start the task item and returning the resulting DTO.
    /// </summary>
    public class StartTaskCommandHandler: IRequestHandler<StartTaskCommand, TaskItemDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartTaskCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between DTOs and domain entities.</param>
        public StartTaskCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="StartTaskCommand"/> by mapping the provided DTO to a domain entity, saving it to the repository, and returning the resulting DTO.
        /// </summary>
        /// <param name="request">The command containing the task item to start.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The <see cref="TaskItemDTO"/> representing the newly started task item.</returns>
        public async Task<TaskItemDTO> Handle(StartTaskCommand request, CancellationToken cancellationToken)
        {
            Domain.TaskItem taskItem = mapper.Map<Domain.TaskItem>(request.TaskItem);

            if (taskItem.StartTime != null) throw new ValidationException($"The task has already been started. taskItemId={taskItem.Id}");
            if (taskItem.EndTime != null) throw new ValidationException($"Impossible state, the starttime is null and the endtime is not null. taskItemId={taskItem.Id}");

            taskItem.StartTime = DateTime.Now;

            uow.TaskItemRepository.Update(taskItem);
            await uow.Commit();

            return mapper.Map<TaskItemDTO>(taskItem);
        }
    }
}
