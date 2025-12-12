using System.ComponentModel.DataAnnotations;

namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) representing a zone within a plantation site.
    /// </summary>
    public record ZoneDto
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
        [Required(ErrorMessage = "Name is verplicht.")]
        public string? Name { get; set; }

        /// <summary>
        /// Optional size of the zone, typically in square meters or relevant unit.
        /// </summary>
        [Required(ErrorMessage = "Oppervlakte is verplicht.")]
        public int? Size { get; set; }
    }
}
