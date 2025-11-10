using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TaskList
{
    public class GetAllTaskListsByUserIdAndWeekQuery : IRequest<IEnumerable<TaskListDTO>>
    {
        public int UserId { get; set; }
        public int Year { get; set; }
        public int WeekNumber { get; set; }
    }

    public class GetAllTaskListsByUserIdAndWeekQueryValidator : AbstractValidator<GetAllTaskListsByUserIdAndWeekQuery>
    {
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

    public class GetAllTaskListsByUserIdAndWeekQueryHandler : IRequestHandler<GetAllTaskListsByUserIdAndWeekQuery, IEnumerable<TaskListDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllTaskListsByUserIdAndWeekQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TaskListDTO>> Handle(GetAllTaskListsByUserIdAndWeekQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.TaskList> taskLists = await uow.TaskListRepository.GetAllByUserIdAndWeek(request.UserId, request.Year, request.WeekNumber);

            IEnumerable<TaskListDTO> taskListsDTOs = mapper.Map<IEnumerable<TaskListDTO>>(taskLists);

            return taskListsDTOs;
        }
    }
}
