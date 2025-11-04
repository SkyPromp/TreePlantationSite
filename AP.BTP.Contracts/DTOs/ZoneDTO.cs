namespace AP.BTP.Contracts.DTOs
{
    public class ZoneDTO
    {
        public int Id { get; set; }
        public required int TreeId { get; set; }
        public required int PlantationSiteId { get; set; }
        public string? Name { get; set; }
        public int? Size { get; set; }

        public ZoneDTO Clone() => new ZoneDTO() { 
            Id = this.Id, 
            PlantationSiteId = this.PlantationSiteId,
            TreeId = this.TreeId,
            Name = this.Name,
            Size = this.Size
        };

    }
}
