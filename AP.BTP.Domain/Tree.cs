using AP.BTP.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace AP.BTP.Domain
{
    public class Tree: IDeletable
    {
        public int Id { get; set; }
        public required String Species { get; set; }
        [JsonIgnore] public IEnumerable<Zone>? Zones { get; set; }
        public bool IsDeleted { get; set; }
    }
}
