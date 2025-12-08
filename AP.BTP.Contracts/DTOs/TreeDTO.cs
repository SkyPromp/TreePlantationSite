namespace AP.BTP.Contracts.DTOs
{
    public record TreeDTO
    {
        /// <summary>
        /// The unique identifier of the tree.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The species of the tree.
        /// </summary>
        public required string Species { get; set; }

        public string? Description { get; set; }

        /// <summary>
        /// An optional spring maintenance plan associated with the tree. Can be <c>null</c> if no plan exists.
        /// </summary>
        public string? MaintenancePlanSpring { get; set; }

        /// <summary>
        /// An optional summer maintenance plan associated with the tree. Can be <c>null</c> if no plan exists.
        /// </summary>
        public string? MaintenancePlanSummer { get; set; }

        /// <summary>
        /// An optional autumn maintenance plan associated with the tree. Can be <c>null</c> if no plan exists.
        /// </summary>
        public string? MaintenancePlanAutumn { get; set; }

        /// <summary>
        /// An optional winter maintenance plan associated with the tree. Can be <c>null</c> if no plan exists.
        /// </summary>
        public string? MaintenancePlanWinter { get; set; }                        
    }
}
