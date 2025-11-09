using AP.BTP.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace AP.BTP.Domain
{
    public class User: IDeletable
    {
        public int Id { get; set; }
        public required string Auth0Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [JsonIgnore] public ICollection<PlantationSite> PlantationSites { get; set; } = new List<PlantationSite>();
        [JsonIgnore] public ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();
        public bool IsDeleted { get; set; }
    }
}
