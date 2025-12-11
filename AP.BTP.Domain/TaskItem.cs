using AP.BTP.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace AP.BTP.Domain
{
    /// <summary>
    /// Represents an individual task item belonging to a task list.
    /// Implements <see cref="IDeletable"/> to support soft deletion.
    /// </summary>
    public class TaskItem: IDeletable
    {
        /// <summary>
        /// Gets or sets the unique identifier of the task item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the task item.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the task item.
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Duration of the task in minutes.
        /// </summary>
        public int DurationInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the task list that this task item belongs to.
        /// </summary>
        public required int TaskListId { get; set; }

        /// <summary>
        /// Gets or sets the task list associated with this task list.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] public TaskList? TaskList { get; set; }  // Not required because of seeding
        // TODO see if we can make it also nullable

        /// <summary>
        /// The time when a task is started, if this is null the task has not yet been started.
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// The time when a task is ended, if this is null the task has not yet been ended.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the task item is considered deleted (soft deletion).
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
