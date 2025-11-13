using AP.BTP.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace AP.BTP.Domain
{
    /// <summary>
    /// Represents a collection of task items for a specific user on a given date.
    /// Implements <see cref="IDeletable"/> to support soft deletion.
    /// </summary>
    public class TaskList: IDeletable
    {
        /// <summary>
        /// Gets or sets the unique identifier of the task list.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date associated with the task list.
        /// </summary>
        public required DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user to whom this task list belongs.
        /// </summary>
        public required int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with this task list.
        /// </summary>
        public User User { get; set; }  // TODO make required or nullable

        /// <summary>
        /// Gets or sets the collection of task items in this task list.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

        /// <summary>
        /// Gets or sets a value indicating whether the task list is considered deleted (soft deletion).
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
