namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a task list, including its identifier, date, and associated task items.
    /// </summary>
    public record TaskListDTO
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
        /// The plantation site id associated with this task list.
        /// </summary>
        public int? PlantationSiteId { get; set; }

        /// <summary>
        /// The collection of task items associated with this task list.
        /// May be <c>null</c> if there are no tasks.
        /// </summary>
        public ICollection<TaskItemDTO>? TaskItems { get; set; }

        /// <summary>
        /// The ID of the user associated with this task list.
        /// </summary>
        public required int UserId { get; set; }

        /// <summary>
        /// The zone id associated with this task list.
        /// </summary>
        public int? ZoneId { get; set; }
    }
}
