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
    public class SubmitWeekScheduleCommand : IRequest<IEnumerable<TaskListDto>>
    {
        public List<TaskListDto> TaskLists { get; set; } = new();
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

            RuleForEach(x => x.TaskLists)
                .MustAsync(async (tl, cancellation) => await NotEditingPastItemsAsync(tl, uow))
                .WithMessage("Taken van een dag in het verleden mogen niet gewijzigd worden.");

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
        private static bool AllSameSite(List<TaskListDto> taskLists)
        {
            List<int> siteIds = taskLists
                .Where(t => t.PlantationSiteId != null)
                .Select(t => t.PlantationSiteId!.Value)
                .Distinct()
                .ToList();

            return siteIds.Count <= 1;
        }

        private static bool MaxFiveDays(List<TaskListDto> taskLists)
        {
            int days = taskLists
                .Where(t => t.TaskItems != null && t.TaskItems.Any(i => !i.IsDeleted))
                .Select(t => t.Date.Date)
                .Distinct()
                .Count();

            return days <= 5;
        }

        private static async Task<bool> NotEditingPastItemsAsync(TaskListDto taskList, IUnitOfWork uow)
        {
            if (taskList.Date.Date >= DateTime.Today)
                return true;

            if (taskList.TaskItems == null)
                return true;

            foreach (TaskItemDto item in taskList.TaskItems)
            {
                Domain.TaskItem? existingItem = await uow.TaskItemRepository.GetById(item.Id);
                if (existingItem == null)
                    return false;

                bool edited =
                    existingItem.Title != item.Title ||
                    existingItem.Description != item.Description ||
                    existingItem.DurationInMinutes != item.DurationInMinutes ||
                    existingItem.IsDeleted != item.IsDeleted;

                if (edited)
                    return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Handles the <see cref="SubmitWeekScheduleCommand"/> by adding, updating, 
    /// and deleting the specified task lists and their items in the database, 
    /// returning the updated task lists as DTOs.
    /// </summary>
    public class SubmitWeekScheduleCommandHandler : IRequestHandler<SubmitWeekScheduleCommand, IEnumerable<TaskListDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public SubmitWeekScheduleCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Main handler method for processing the command.
        /// Iterates through the provided task lists, creates/updates/deletes them and their items.
        /// </summary>
        public async Task<IEnumerable<TaskListDto>> Handle(SubmitWeekScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = new List<TaskListDto>();

            foreach (TaskListDto taskListDto in request.TaskLists)
            {
                if (IsTaskListEmpty(taskListDto))
                    break;

                Domain.TaskList taskList = await GetOrCreateTaskList(taskListDto);

                await HandleTaskItems(taskListDto.TaskItems, taskList);

                if (!taskList.TaskItems.Any(item => !item.IsDeleted))
                {
                    uow.TaskListRepository.Delete(taskList);
                }

                result.Add(mapper.Map<TaskListDto>(taskList));
            }

            await uow.Commit();
            return result;
        }

        /// <summary>
        /// Checks if a task list has no items.
        /// </summary>
        private static bool IsTaskListEmpty(TaskListDto taskListDto)
        {
            return taskListDto.TaskItems == null || taskListDto.TaskItems.Count == 0;
        }

        /// <summary>
        /// Retrieves an existing task list by ID or creates a new one if it doesn't exist.
        /// </summary>
        private async Task<Domain.TaskList> GetOrCreateTaskList(TaskListDto taskListDto)
        {
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

            return taskList;
        }

        /// <summary>
        /// Processes each task item in a task list:
        /// deletes, creates, or updates as necessary.
        /// </summary>
        private async Task HandleTaskItems(IEnumerable<TaskItemDto>? taskItems, Domain.TaskList taskList)
        {
            if (taskItems == null) return;

            foreach (TaskItemDto itemDto in taskItems)
            {
                if (itemDto.IsDeleted)
                {
                    await MarkItemAsDeleted(itemDto);
                }
                else if (itemDto.Id == 0)
                {
                    await CreateTaskItem(itemDto, taskList);
                }
                else
                {
                    await UpdateTaskItem(itemDto);
                }
            }
        }

        /// <summary>
        /// Marks an existing task item as deleted.
        /// </summary>
        private async Task MarkItemAsDeleted(TaskItemDto itemDto)
        {
            if (itemDto.Id <= 0) return;

            Domain.TaskItem? existingItem = await uow.TaskItemRepository.GetById(itemDto.Id);
            if (existingItem != null)
            {
                existingItem.IsDeleted = true;
            }
        }

        /// <summary>
        /// Creates a new task item and associates it with the task list.
        /// </summary>
        private async Task CreateTaskItem(TaskItemDto itemDto, Domain.TaskList taskList)
        {
            Domain.TaskItem newItem = mapper.Map<Domain.TaskItem>(itemDto);
            newItem.TaskList = taskList;
            await uow.TaskItemRepository.Create(newItem);
        }

        /// <summary>
        /// Updates an existing task item with new values from the DTO.
        /// </summary>
        private async Task UpdateTaskItem(TaskItemDto itemDto)
        {
            Domain.TaskItem? existingItem = await uow.TaskItemRepository.GetById(itemDto.Id);
            if (existingItem == null) return;

            existingItem.Title = itemDto.Title;
            existingItem.Description = itemDto.Description;
            existingItem.DurationInMinutes = itemDto.DurationInMinutes;
        }
    }
}