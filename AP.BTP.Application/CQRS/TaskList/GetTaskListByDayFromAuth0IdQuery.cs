using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Runtime.ExceptionServices;

namespace AP.BTP.Application.CQRS.TaskList
{
    /// <summary>
    /// Represents a query to retrieve all task lists for a specific user in a given week of a specified year.
    /// </summary>
    public class GetTaskListByDayFromAuth0IdQuery : IRequest<TaskListDTO?>
    {
        /// <summary>
        /// The unique auth0 identifier of the user whose task lists are being retrieved.
        /// </summary>
        public required string Auth0Id { get; set; }

        /// <summary>
        /// The date for which the task lists are being retrieved.
        /// </summary>
        public required DateTime Day { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="GetTaskListByDayFromAuth0IdQuery"/>.
    /// </summary>
    public class GetTaskListByDayFromAuth0IdQueryValidator : AbstractValidator<GetTaskListByDayFromAuth0IdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTaskListByDayFromAuth0IdQueryValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation checks.</param>
        public GetTaskListByDayFromAuth0IdQueryValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="GetTaskListByDayFromAuth0IdQuery"/> by retrieving the task lists for the specified user and week.
    /// </summary>
    public class GetTaskListByDayFromAuth0IdQueryHandler : IRequestHandler<GetTaskListByDayFromAuth0IdQuery, TaskListDTO?>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTaskListByDayFromAuth0IdQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for accessing the task list repository.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetTaskListByDayFromAuth0IdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="GetTaskListByDayFromAuth0IdQuery"/> by retrieving and mapping task lists for the specified user and week.
        /// </summary>
        /// <param name="request">The query containing the user ID, year, and week number.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A collection of <see cref="TaskListDTO"/> objects representing the task lists for the user and week.
        /// </returns>
        public async Task<TaskListDTO?> Handle(GetTaskListByDayFromAuth0IdQuery request, CancellationToken cancellationToken)
        {
            Domain.User? user = await uow.UserRepository.GetUserByAuth0Id(request.Auth0Id);

            if (user == null) throw new ValidationException("The user could not be found!");

            Domain.TaskList? taskList = await uow.TaskListRepository.GetAllByUserIdAndDate(userId:user.Id, date:request.Day);

            if (taskList == null) return null;

            TaskListDTO taskListDTO = mapper.Map<TaskListDTO>(taskList);

            return taskListDTO;
        }
    }
}
