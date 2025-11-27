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
    public class EndTaskCommand: IRequest<TaskItemDTO>
    {
        /// <summary>
        /// The data transfer object (DTO) containing the task item to be ended.
        /// </summary>
        public required TaskItemDTO TaskItem { get; set; }
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
    public class EndTaskCommandHandler: IRequestHandler<EndTaskCommand, TaskItemDTO>
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
        /// <returns>The <see cref="TaskItemDTO"/> representing the newly ended task item.</returns>
        public async Task<TaskItemDTO> Handle(EndTaskCommand request, CancellationToken cancellationToken)
        {
            Domain.TaskItem taskItem = mapper.Map<Domain.TaskItem>(request.TaskItem);

            if (taskItem.EndTime != null) throw new Exception("The task has already been ended.");
            if (taskItem.StartTime > DateTime.Now) throw new Exception("The task start time is after the end time.");

            taskItem.EndTime = DateTime.Now;

            uow.TaskItemRepository.Update(taskItem);
            await uow.Commit();

            return mapper.Map<TaskItemDTO>(taskItem);
        }
    }
}
