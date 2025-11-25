namespace AP.BTP.Contracts.DTOs
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

        /// <summary>
        /// The task list id associated with this task item.
        /// </summary>
        public required int TaskListId { get; set; }

        /// <summary>
        /// The zone id associated with this task item.
        /// </summary>
        public required int ZoneId { get; set; }
    }
}
