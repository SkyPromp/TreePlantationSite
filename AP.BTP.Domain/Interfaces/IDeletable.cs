namespace AP.BTP.Domain.Interfaces
{
    /// <summary>
    /// Represents an entity that supports soft deletion.
    /// </summary>
    /// <remarks>
    /// Implementing this interface allows an entity to indicate whether it has been logically deleted
    /// without removing it from the data store.
    /// </remarks>
    public interface IDeletable
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is considered deleted.
        /// </summary>
        bool IsDeleted { get; set; }
    }

}
