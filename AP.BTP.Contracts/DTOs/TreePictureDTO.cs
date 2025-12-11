namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Data transfer object representing a picture associated with a tree.
    /// </summary>
    public record TreePictureDto
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
        /// The ID of the tree this picture is associated with.
        /// </summary>
        public int TreeId { get; set; }
    }
}