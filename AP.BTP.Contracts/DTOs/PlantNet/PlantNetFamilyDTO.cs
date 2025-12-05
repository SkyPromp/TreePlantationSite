namespace AP.BTP.Contracts.DTOs.PlantNet
{
    /// <summary>
    /// Represents botanical family information returned by the PlantNet service.
    /// </summary>    
    public record PlantNetFamilyDTO
    {
        /// <summary>
        /// Gets or sets the scientific family name without the author citation.
        /// </summary>        
        public string? ScientificNameWithoutAuthor { get; set; }
    }
}