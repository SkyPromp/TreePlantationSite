namespace AP.BTP.Contracts.DTOs.PlantNet
{
    /// <summary>
    /// Represents a species returned by the PlantNet service.
    /// </summary>    
    public record PlantNetSpeciesDto
    {
        /// <summary>
        /// Gets or sets the scientific name of the species without the author citation..
        /// </summary>        
        public string? ScientificNameWithoutAuthor { get; set; }

        /// <summary>
        /// Gets or sets the botanical family information associated with the species.
        /// </summary>        
        public PlantNetFamilyDto? Family { get; set; }

        /// <summary>
        /// Gets or sets the list of common names for the species.
        /// This collection is initialized to an empty list.
        /// </summary>        
        public List<string> CommonNames { get; set; } = new List<string>();
    }    
}