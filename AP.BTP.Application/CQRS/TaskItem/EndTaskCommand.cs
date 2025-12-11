using AP.BTP.Application.Exceptions;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TaskItem
{
    /// <summary>
    /// Represents a command to end the task.
    /// </summary>
    public class EndTaskCommand: IRequest<TaskItemDto>
    {
        /// <summary>
        /// The data transfer object (DTO) containing the task item to be ended.
        /// </summary>
        public required TaskItemDto TaskItem { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="EndTaskCommand"/>.
    /// Ensures that required fields are present and valid before ending the task item.
    /// </summary>
    public class EndTaskCommandValidator: AbstractValidator<EndTaskCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndTaskCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential data validation checks.</param>
        public EndTaskCommandValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="EndTaskCommand"/> to end the task item and returning the resulting DTO.
    /// </summary>
    public class EndTaskCommandHandler: IRequestHandler<EndTaskCommand, TaskItemDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndTaskCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between DTOs and domain entities.</param>
        public EndTaskCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="EndTaskCommand"/> by mapping the provided DTO to a domain entity, saving it to the repository, and returning the resulting DTO.
        /// </summary>
        /// <param name="request">The command containing the task item to end.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The <see cref="TaskItemDto"/> representing the newly ended task item.</returns>
        public async Task<TaskItemDto> Handle(EndTaskCommand request, CancellationToken cancellationToken)
        {
            Domain.TaskItem taskItem = mapper.Map<Domain.TaskItem>(request.TaskItem);

            if (taskItem.StartTime == null)
                throw new StartStopTaskFailedException(
                    $"Deze taak is nog niet gestart. taskItemId={taskItem.Id}",
                    "TASK_NOT_STARTED"
                );

            if (taskItem.EndTime != null)
                throw new StartStopTaskFailedException(
                    $"Deze taak is al beëindigd. taskItemId={taskItem.Id}",
                    "TASK_ALREADY_ENDED"
                );

            if (taskItem.StartTime > DateTime.Now)
                throw new StartStopTaskFailedException(
                    $"De starttijd van de taak ligt in de toekomst. taskItemId={taskItem.Id}",
                    "TASK_INVALID_TIME"
                );


            Domain.TaskList? taskList = await uow.TaskListRepository.GetByIdUntracked(request.TaskItem.TaskListId);

            if (taskList == null)
                throw new NotFoundException(
                    $"TaskList niet gevonden voor taskItemId={request.TaskItem.Id}, taskListId={request.TaskItem.TaskListId}"
                );

            if (taskList.Date.Date != DateTime.Now.Date)
                throw new StartStopTaskFailedException(
                    "Taken kunnen alleen gestopt worden op de huidige datum.",
                    "TASK_END_INVALID_DATE"
                );

            taskItem.EndTime = DateTime.Now;

            uow.TaskItemRepository.Update(taskItem);
            await uow.Commit();

            return mapper.Map<TaskItemDto>(taskItem);
        }
    }
}
