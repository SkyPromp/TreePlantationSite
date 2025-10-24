using AP.BTP.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace AP.BTP.Domain
{
    public class Zone: IDeletable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Size { get; set; }

        public int PlantationSiteId { get; set; }
        [JsonIgnore] public required PlantationSite PlantationSite { get; set; }

        public int TreeId { get; set; }
        [JsonIgnore] public required Tree Tree { get; set; }

        public bool IsDeleted { get; set; }
    }
}
