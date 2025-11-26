using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TaskList
{
    /// <summary>
    /// Represents a command to partially update a task list (e.g., updating only the PlantationSiteId).
    /// </summary>
    public class PatchTaskListSiteCommand : IRequest<TaskListDTO>
    {
        /// <summary>
        /// The ID of the task list to update.
        /// </summary>
        public int TaskListId { get; set; }
        
        /// <summary>
        /// The plantation site ID to assign. Null to clear the assignment.
        /// </summary>
        public int? PlantationSiteId { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="PatchTaskListSiteCommand"/>.
    /// </summary>
    public class PatchTaskListSiteCommandValidator : AbstractValidator<PatchTaskListSiteCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatchTaskListSiteCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work for data validation.</param>
        public PatchTaskListSiteCommandValidator(IUnitOfWork uow)
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

            When(x => x.PlantationSiteId.HasValue, () =>
            {
                RuleFor(x => x.PlantationSiteId.Value)
                    .GreaterThan(0)
                    .WithMessage("Plantation site ID must be greater than 0 when specified")
                    .MustAsync(async (siteId, cancellation) => 
                    {
                        Domain.PlantationSite? site = await uow.PlantationSiteRepository.GetById(siteId);
                        return site != null && !site.IsDeleted;
                    })
                    .WithMessage("Plantation site does not exist or has been deleted");
            });
        }
    }

    /// <summary>
    /// Handles the <see cref="PatchTaskListSiteCommand"/> by partially updating the task list in the database.
    /// </summary>
    public class PatchTaskListSiteCommandHandler : IRequestHandler<PatchTaskListSiteCommand, TaskListDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatchTaskListSiteCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between DTOs and domain entities.</param>
        public PatchTaskListSiteCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="PatchTaskListSiteCommand"/> by updating only the specified fields.
        /// </summary>
        /// <param name="request">The command containing the task list ID and fields to update.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The updated <see cref="TaskListDTO"/>.</returns>
        public async Task<TaskListDTO> Handle(PatchTaskListSiteCommand request, CancellationToken cancellationToken)
        {
            Domain.TaskList? taskList = await uow.TaskListRepository.GetById(request.TaskListId);
            
            if (taskList == null)
                throw new KeyNotFoundException($"Task list with ID {request.TaskListId} not found");

            taskList.PlantationSiteId = request.PlantationSiteId;
            taskList.Zone = null;
            taskList.ZoneId = null;

            uow.TaskListRepository.Update(taskList);
            await uow.Commit();

            return mapper.Map<TaskListDTO>(taskList);
        }
    }
}