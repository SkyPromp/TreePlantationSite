using System.Text.Json.Serialization;
using AP.BTP.Domain.Interfaces;

namespace AP.BTP.Domain
{
    /// <summary>
    /// Represents a picture associated with a tree in the domain model.
    /// </summary>
    public class TreePicture : IDeletable
    {
        /// <summary>
        /// The unique identifier of the tree picture.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The file path or URL of the tree picture.
        /// </summary>
        public required string Path { get; set; }

        /// <summary>
        /// Indicates whether this picture is marked as the favourite.
        /// </summary>
        public bool IsFavourite { get; set; }

        /// <summary>
        /// Indicates whether this entity has been soft-deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// The ID of the tree this picture is associated with.
        /// </summary>
        public int TreeId { get; set; }

        /// <summary>
        /// The tree entity that this picture belongs to.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] public required Tree Tree { get; set; }
    }   
}