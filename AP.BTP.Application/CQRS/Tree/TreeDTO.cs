namespace AP.BTP.Application.CQRS.Tree
{
    public class TreeDTO
    {
        /// <summary>
        /// The unique identifier of the tree.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The species of the tree.
        /// </summary>
        public required string Species { get; set; }

        /// <summary>
        /// An optional maintenance plan associated with the tree. Can be <c>null</c> if no plan exists.
        /// </summary>
        public string? MaintenancePlan { get; set; }
    }
}
