using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.CQRS.Tree;

namespace AP.BTP.Application.CQRS.Zone
{
    public class ZoneDTO
    {
        public int Id { get; set; }
        //public required TreeDTO Tree { get; set; }
        //public required PlantationSiteDTO PlantationSite { get; set; }
        public required int TreeId { get; set; }
        public required int PlantationSiteId { get; set; }
    }
}
