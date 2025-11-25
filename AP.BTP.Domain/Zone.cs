using AP.BTP.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace AP.BTP.Domain
{
    /// <summary>
    /// Represents a specific zone within a plantation site, associated with a particular tree.
    /// Implements <see cref="IDeletable"/> to support soft deletion.
    /// </summary>
    public class Zone: IDeletable
    {
        /// <summary>
        /// Gets or sets the unique identifier of the zone.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the optional name of the zone.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the optional size of the zone.
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the plantation site to which this zone belongs.
        /// </summary>
        public int PlantationSiteId { get; set; }

        /// <summary>
        /// Gets or sets the plantation site associated with this zone.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] public required PlantationSite PlantationSite { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the tree planted in this zone.
        /// </summary>
        public int TreeId { get; set; }

        /// <summary>
        /// Gets or sets the tree associated with this zone.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] public required Tree Tree { get; set; }

        /// <summary>
        /// Gets or sets the collection of task lists in this zone.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] public ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();

        /// <summary>
        /// Gets or sets a value indicating whether the zone is considered deleted (soft deletion).
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
