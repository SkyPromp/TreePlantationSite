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
        /// Gets or sets the primary or most commonly used common name of the species.
        /// </summary>        
        public string? CommonName { get; set; }

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