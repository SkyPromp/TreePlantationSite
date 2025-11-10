using AP.BTP.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace AP.BTP.Domain
{
    public class TaskList : IDeletable
    {
        public int Id { get; set; }
        public required DateTime Date { get; set; }
        public required int UserId { get; set; }
        public User User { get; set; }
        [JsonIgnore] public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
        public bool IsDeleted { get; set; }
    }
}
