using AP.BTP.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace AP.BTP.Domain
{
    public class User: IDeletable
    {
        public int Id { get; set; }
        public required string Auth0Id { get; set; }
        [JsonIgnore] public ICollection<PlantationSite> PlantationSites { get; set; } = new List<PlantationSite>();
        public bool IsDeleted { get; set; }
    }
}
