namespace AP.BTP.Contracts.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Auth0Id { get; set; }
        public ICollection<PlantationSiteDTO>? PlantationSites { get; set; }
    }
}
