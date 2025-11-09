namespace AP.BTP.Application.CQRS.TaskItem
{
    public class TaskItemDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
