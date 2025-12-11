using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TaskList
{
    /// <summary>
    /// Represents a command to add a new task list to the system.
    /// </summary>
    public class AddTaskListCommand: IRequest<TaskListDto>
    {
        /// <summary>
        /// The data transfer object (DTO) containing the task list details to be added.
        /// </summary>
        public required TaskListDto TaskList { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="AddTaskListCommand"/>.
    /// Ensures that required fields are present and valid before adding a task list.
    /// </summary>
    public class AddTaskListCommandValidator: AbstractValidator<AddTaskListCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTaskListCommandValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential data validation checks.</param>
        public AddTaskListCommandValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="AddTaskListCommand"/> by adding a new task list to the database and returning the resulting DTO.
    /// </summary>
    public class AddTaskListCommandHandler: IRequestHandler<AddTaskListCommand, TaskListDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTaskListCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert between DTOs and domain entities.</param>
        public AddTaskListCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="AddTaskListCommand"/> by mapping the provided DTO to a domain entity, saving it to the repository, and returning the resulting DTO.
        /// </summary>
        /// <param name="request">The command containing the task list details to add.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The <see cref="TaskListDto"/> representing the newly added task list.</returns>
        public async Task<TaskListDto> Handle(AddTaskListCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("ADD TASK LIST COMMAND");
            Domain.TaskList taskList = mapper.Map<Domain.TaskList>(request.TaskList);
            Console.WriteLine(taskList.TaskItems.Count);

            await uow.TaskListRepository.Create(taskList);
            await uow.Commit();
            Console.WriteLine(taskList.Id);

            return mapper.Map<TaskListDto>(taskList);
        }
    }
}
