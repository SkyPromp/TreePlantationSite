using AP.BTP.Application.CQRS.TaskItem;

namespace AP.BTP.Application.CQRS.TaskList
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a task list, including its identifier, date, and associated task items.
    /// </summary>
    public class TaskListDTO
    {
        /// <summary>
        /// The unique identifier of the task list.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date for which the task list is scheduled.
        /// </summary>
        public required DateTime Date { get; set; }

        /// <summary>
        /// The collection of task items associated with this task list.
        /// May be <c>null</c> if there are no tasks.
        /// </summary>
        public ICollection<TaskItemDTO>? TaskItems { get; set; }
    }
}
