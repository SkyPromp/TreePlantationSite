namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) representing a zone within a plantation site.
    /// </summary>
    public record ZoneDTO
    {
        /// <summary>
        /// The unique identifier of the zone.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The unique identifier of the tree associated with this zone.
        /// </summary>
        public required int TreeId { get; set; }

        /// <summary>
        /// The unique identifier of the plantation site to which this zone belongs.
        /// </summary>
        public required int PlantationSiteId { get; set; }

        /// <summary>
        /// Optional name of the zone.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Optional size of the zone, typically in square meters or relevant unit.
        /// </summary>
        public int? Size { get; set; }
    }
}
