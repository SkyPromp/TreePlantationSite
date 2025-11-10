namespace AP.BTP.Contracts.DTOs
{
    public class TaskListDTO
    {
        public int Id { get; set; }
        public required DateTime Date { get; set; }
        public ICollection<TaskItemDTO>? TaskItems { get; set; }
    }
}
