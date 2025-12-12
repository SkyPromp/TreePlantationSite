namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) week schedule.
    /// </summary>
    public class SubmitWeekScheduleDto
    {
        /// <summary>
        /// the task lists of the week, each one representing one day in the week.
        /// </summary>
        public List<TaskListDto> TaskLists { get; set; } = new();
    }
}
