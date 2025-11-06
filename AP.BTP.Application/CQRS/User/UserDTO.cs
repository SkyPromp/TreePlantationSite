using AP.BTP.Application.CQRS.PlantationSite;

namespace AP.BTP.Application.CQRS.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Auth0Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<PlantationSiteDTO>? PlantationSites { get; set; }
    }
}
