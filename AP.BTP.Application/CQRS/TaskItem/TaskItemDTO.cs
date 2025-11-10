namespace AP.BTP.Application.CQRS.TaskItem
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a task item, including its identifier, title, and description.
    /// </summary>
    public class TaskItemDTO
    {
        /// <summary>
        /// The unique identifier of the task item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the task item.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// A detailed description of the task item.
        /// </summary>
        public required string Description { get; set; }
    }
}
