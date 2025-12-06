using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TaskList
{
    /// <summary>
    /// Command to submit multiple task lists and task items in a single call.
    /// </summary>
    public class SubmitWeekScheduleCommand : IRequest<IEnumerable<TaskListDTO>>
    {
        public List<TaskListDTO> TaskLists { get; set; } = new();
    }

    /// <summary>
    /// Provides validation rules for the <see cref="SubmitWeekScheduleCommand"/>.
    /// Ensures that required fields are present and valid before adding/changing a task list/item.
    /// </summary>
    public class SubmitWeekScheduleCommandValidator : AbstractValidator<SubmitWeekScheduleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubmitWeekScheduleCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential data validation checks.</param>
        public SubmitWeekScheduleCommandValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.TaskLists)
                .NotEmpty()
                .WithMessage("De week moet minstens één takenlijst bevatten.");

            RuleFor(x => x.TaskLists)
                .Must(AllSameSite)
                .WithMessage("Een medewerker moet de volledige week in dezelfde site werken.");

            RuleFor(x => x.TaskLists)
                .Must(MaxFiveDays)
                .WithMessage("Een medewerker mag maximaal 5 dagen per week werken.");

            RuleForEach(x => x.TaskLists)
                .Must(tl => tl.TaskItems == null || tl.TaskItems.Count(i => !i.IsDeleted) <= 4)
                .WithMessage("Een medewerker mag maximaal 4 taken per dag hebben.");

            RuleForEach(x => x.TaskLists)
                .Must(tl =>
                {
                    int totalMinutes = tl.TaskItems?
                        .Where(i => !i.IsDeleted)
                        .Sum(i => i.DurationInMinutes) ?? 0;

                    return totalMinutes <= 480;
                })
                .WithMessage("Een takenlijst mag maximaal 8 uur bevatten.");
        }
        private bool AllSameSite(List<TaskListDTO> taskLists)
        {
            List<int> siteIds = taskLists
                .Where(t => t.PlantationSiteId != null)
                .Select(t => t.PlantationSiteId!.Value)
                .Distinct()
                .ToList();

            return siteIds.Count <= 1;
        }
        private bool MaxFiveDays(List<TaskListDTO> taskLists)
        {
            int days = taskLists
                .Where(t => t.TaskItems != null && t.TaskItems.Count(i => !i.IsDeleted) > 0)
                .Select(t => t.Date.Date)
                .Distinct()
                .Count();

            return days <= 5;
        }
    }

    /// <summary>
    /// Handles the <see cref="SubmitWeekScheduleCommand"/> by adding, updating and deleting the specified task lists and items in the database and returning the updated tasklists.
    /// </summary>
    public class SubmitWeekScheduleCommandHandler : IRequestHandler<SubmitWeekScheduleCommand, IEnumerable<TaskListDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public SubmitWeekScheduleCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TaskListDTO>> Handle(SubmitWeekScheduleCommand request, CancellationToken cancellationToken)
        {
            List<TaskListDTO> result = new List<TaskListDTO>();

            foreach (TaskListDTO taskListDto in request.TaskLists)
            {
                if (taskListDto.TaskItems == null || taskListDto.TaskItems.Count() == 0)
                {
                    break;
                }
                Domain.TaskList? taskList = null;

                if (taskListDto.Id > 0)
                {
                    taskList = await uow.TaskListRepository.GetById(taskListDto.Id);
                }

                if (taskList == null)
                {
                    taskList = mapper.Map<Domain.TaskList>(taskListDto);
                    taskList.TaskItems.Clear();
                    await uow.TaskListRepository.Create(taskList);
                }
                else
                {
                    uow.TaskListRepository.Update(mapper.Map<Domain.TaskList>(taskListDto));
                }

                foreach (TaskItemDTO itemDto in taskListDto.TaskItems ?? new List<TaskItemDTO>())
                {
                    if (itemDto.IsDeleted)
                    {
                        if (itemDto.Id > 0)
                        {
                            Domain.TaskItem? existingItem = await uow.TaskItemRepository.GetById(itemDto.Id);
                            if (existingItem != null)
                                existingItem.IsDeleted = true;
                        }
                    }
                    else if (itemDto.Id == 0)
                    {
                        Domain.TaskItem newItem = mapper.Map<Domain.TaskItem>(itemDto);
                        newItem.TaskList = taskList;
                        await uow.TaskItemRepository.Create(newItem);
                    }
                    else
                    {
                        Domain.TaskItem? existingItem = await uow.TaskItemRepository.GetById(itemDto.Id);
                        if (existingItem != null)
                        {
                            existingItem.Title = itemDto.Title;
                            existingItem.Description = itemDto.Description;
                            existingItem.DurationInMinutes = itemDto.DurationInMinutes;
                        }
                    }
                }
                if (taskList.TaskItems.Where(item => item.IsDeleted == false).Count() == 0)
                {
                    uow.TaskListRepository.Delete(taskList);
                }

                result.Add(mapper.Map<TaskListDTO>(taskList));
            }

            await uow.Commit();
            return result;
        }
    }
}
