using AP.BTP.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace AP.BTP.Domain
{
    /// <summary>
    /// Represents a tree entity with its species, maintenance plan, and associated zones.
    /// Implements <see cref="IDeletable"/> to support soft deletion.
    /// </summary>
    public class Tree: IDeletable
    {
        /// <summary>
        /// Gets or sets the unique identifier of the tree.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the species of the tree.
        /// </summary>
        public required string Species { get; set; }

        /// <summary>
        /// Gets or sets the collection of zones where this tree is planted.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] public ICollection<Zone> Zones { get; set; } = new List<Zone>();

        /// <summary>
        /// Gets or sets the maintenance plan associated with the tree, if any.
        /// </summary>
        public string? MaintenancePlan { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tree is considered deleted (soft deletion).
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the collection of tree pictures for the tree.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] public ICollection<TreePicture> TreePictures = new List<TreePicture>();
    }
}
