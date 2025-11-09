using AP.BTP.Application.CQRS.TaskItem;

namespace AP.BTP.Application.CQRS.TaskList
{
    public class TaskListDTO
    {
        public int Id { get; set; }
        public required DateTime Date { get; set; }
        public ICollection<TaskItemDTO>? TaskItems { get; set; }
    }
}
