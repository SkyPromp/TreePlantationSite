namespace AP.BTP.Contracts.DTOs.PlantNet
{
    /// <summary>
    /// Represents the full response returned by the PlantNet service,
    /// containing a collection of identification results.
    /// </summary>    
    public record PlantNetResponseDTO
    {
        /// <summary>
        /// Gets or sets the list of identification results returned by the service.
        /// This collection is initialized to an empty list.
        /// </summary>        
        public List<PlantNetResultDTO> Results { get; set; } = new List<PlantNetResultDTO>();
    }
}