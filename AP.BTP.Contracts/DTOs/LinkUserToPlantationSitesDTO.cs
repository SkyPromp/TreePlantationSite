namespace AP.BTP.Contracts.DTOs 
{
    /// <summary>
    /// Data transfer object (DTO) used to specify plantation sites to link to a user.
    /// </summary>
    public class LinkUserToPlantationSitesDto
    {
        /// <summary>
        /// The list of plantation site IDs to link to the user.
        /// </summary>
        public required List<int> PlantationSiteIds { get; set; }
    }
}
