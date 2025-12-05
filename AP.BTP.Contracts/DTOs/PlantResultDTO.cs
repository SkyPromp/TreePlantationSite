namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a flattened and simplified plant identification result,
    /// typically used for client-facing responses.
    /// </summary>    
    public record PlantResultDTO
    {
        /// <summary>
        /// Gets or sets the full scientific name of the plant species.
        /// </summary>        
        public string? ScientificName { get; set; }

        /// <summary>
        /// Gets or sets the most commonly used common names of the species.
        /// </summary>        
        public List<string> CommonNames { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the botanical family of the species.
        /// </summary>        
        public string? Family { get; set; }

        /// <summary>
        /// Gets or sets the confidence score assigned to the identification.
        /// Higher values indicate stronger confidence.
        /// </summary>        
        public double Score { get; set; }
    }
}