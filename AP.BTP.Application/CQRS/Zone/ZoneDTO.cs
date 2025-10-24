using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.CQRS.Tree;

namespace AP.BTP.Application.CQRS.Zone
{
    public class ZoneDTO
    {
        public int Id { get; set; }
        public required int TreeId { get; set; }
        public required int PlantationSiteId { get; set; }

        public ZoneDTO Clone() => new ZoneDTO() { Id = this.Id, PlantationSiteId = this.PlantationSiteId, TreeId = this.TreeId };

    }
}
