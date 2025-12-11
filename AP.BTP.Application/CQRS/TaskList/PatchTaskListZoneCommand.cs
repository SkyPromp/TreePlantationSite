using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TaskList
{
    /// <summary>
    /// Represents a command to partially update a task list (e.g., updating only the ZoneId).
    /// </summary>
    public class PatchTaskListZoneCommand : IRequest<TaskListDto>
    {
        /// <summary>
        /// The ID of the task list to update.
        /// </summary>
        public int TaskListId { get; set; }
        
        /// <summary>
        /// The plantation site ID to assign. Null to clear the assignment.
        /// </summary>
        public int? ZoneId { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="PatchTaskListZoneCommand"/>.
    /// </summary>
    public class PatchTaskListZoneCommandValidator : AbstractValidator<PatchTaskListZoneCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatchTaskListZoneCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work for data validation.</param>
        public PatchTaskListZoneCommandValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.TaskListId)
                .GreaterThan(0)
                .WithMessage("Task list ID must be greater than 0")
                .MustAsync(async (id, cancellation) => 
                {
                    Domain.TaskList? taskList = await uow.TaskListRepository.GetById(id);
                    return taskList != null && !taskList.IsDeleted;
                })
                .WithMessage("Task list does not exist or has been deleted");

            When(x => x.ZoneId.HasValue, () =>
            {
                RuleFor(x => x.ZoneId.Value)
                    .GreaterThan(0)
                    .WithMessage("Zone ID must be greater than 0 when specified")
                    .MustAsync(async (zoneId, cancellation) => 
                    {
                        Domain.Zone? zone = await uow.ZoneRepository.GetById(zoneId);
                        return zone != null && !zone.IsDeleted;
                    })
                    .WithMessage("Zone does not exist or has been deleted");
            });
        }
    }

    /// <summary>
    /// Handles the <see cref="PatchTaskListZoneCommand"/> by partially updating the task list in the database.
    /// </summary>
    public class PatchTaskListZoneCommandHandler : IRequestHandler<PatchTaskListZoneCommand, TaskListDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatchTaskListZoneCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between DTOs and domain entities.</param>
        public PatchTaskListZoneCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="PatchTaskListZoneCommand"/> by updating only the specified fields.
        /// </summary>
        /// <param name="request">The command containing the task list ID and fields to update.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The updated <see cref="TaskListDto"/>.</returns>
        public async Task<TaskListDto> Handle(PatchTaskListZoneCommand request, CancellationToken cancellationToken)
        {
            Domain.TaskList? taskList = await uow.TaskListRepository.GetById(request.TaskListId);
            
            if (taskList == null)
                throw new KeyNotFoundException($"Task list with ID {request.TaskListId} not found");

            taskList.ZoneId = request.ZoneId;

            uow.TaskListRepository.Update(taskList);
            await uow.Commit();

            return mapper.Map<TaskListDto>(taskList);
        }
    }
}