namespace AP.BTP.Contracts.DTOs.PlantNet
{
    /// <summary>
    /// Represents a single identification result returned by the PlantNet service.
    /// </summary>    
    public record PlantNetResultDto
    {
        /// <summary>
        /// Gets or sets the confidence score of the identification.
        /// </summary>        
        public double Score { get; set; }

        /// <summary>
        /// Gets or sets the species information associated with this result.
        /// May be null if the service could not determine a species.
        /// </summary>        
        public PlantNetSpeciesDto? Species { get; set; }
    }
}