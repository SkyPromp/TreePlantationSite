using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TaskList
{
    /// <summary>
    /// Represents a query to retrieve all task lists for a specific user in a given week of a specified year.
    /// </summary>
    public class GetAllTaskListsByUserIdAndWeekQuery : IRequest<IEnumerable<TaskListDTO>>
    {
        /// <summary>
        /// The unique identifier of the user whose task lists are being retrieved.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The year for which the task lists are being retrieved.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The ISO week number (1–53) for which the task lists are being retrieved.
        /// </summary>
        public int WeekNumber { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="GetAllTaskListsByUserIdAndWeekQuery"/>.
    /// Ensures that the user ID, year, and week number are valid.
    /// </summary>
    public class GetAllTaskListsByUserIdAndWeekQueryValidator : AbstractValidator<GetAllTaskListsByUserIdAndWeekQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTaskListsByUserIdAndWeekQueryValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation checks.</param>
        public GetAllTaskListsByUserIdAndWeekQueryValidator(IUnitOfWork uow)
        {
            RuleFor(q => q.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");

            RuleFor(q => q.Year)
                .InclusiveBetween(2000, 2100).WithMessage("Year must be between 2000 and 2100.");

            RuleFor(q => q.WeekNumber)
                .InclusiveBetween(1, 53).WithMessage("WeekNumber must be between 1 and 53.");
        }
    }

    /// <summary>
    /// Handles the <see cref="GetAllTaskListsByUserIdAndWeekQuery"/> by retrieving the task lists for the specified user and week.
    /// </summary>
    public class GetAllTaskListsByUserIdAndWeekQueryHandler : IRequestHandler<GetAllTaskListsByUserIdAndWeekQuery, IEnumerable<TaskListDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTaskListsByUserIdAndWeekQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for accessing the task list repository.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetAllTaskListsByUserIdAndWeekQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="GetAllTaskListsByUserIdAndWeekQuery"/> by retrieving and mapping task lists for the specified user and week.
        /// </summary>
        /// <param name="request">The query containing the user ID, year, and week number.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A collection of <see cref="TaskListDTO"/> objects representing the task lists for the user and week.
        /// </returns>
        public async Task<IEnumerable<TaskListDTO>> Handle(GetAllTaskListsByUserIdAndWeekQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.TaskList> taskLists = await uow.TaskListRepository.GetAllByUserIdAndWeek(request.UserId, request.Year, request.WeekNumber);

            IEnumerable<TaskListDTO> taskListsDTOs = mapper.Map<IEnumerable<TaskListDTO>>(taskLists);

            return taskListsDTOs;
        }
    }
}
