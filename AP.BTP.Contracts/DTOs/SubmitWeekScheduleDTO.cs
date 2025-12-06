namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) week schedule.
    /// </summary>
    public class SubmitWeekScheduleDTO
    {
        /// <summary>
        /// the task lists of the week, each one representing one day in the week.
        /// </summary>
        public List<TaskListDTO> TaskLists { get; set; } = new();
    }
}
