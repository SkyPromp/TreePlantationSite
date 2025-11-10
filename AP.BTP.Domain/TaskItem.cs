using AP.BTP.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace AP.BTP.Domain
{
    public class TaskItem : IDeletable
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int TaskListId { get; set; }
        [JsonIgnore] public TaskList TaskList { get; set; }
        public bool IsDeleted { get; set; }
    }
}
