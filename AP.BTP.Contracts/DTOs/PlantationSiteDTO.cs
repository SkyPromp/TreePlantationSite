using System.ComponentModel.DataAnnotations;

namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a plantation site, including address, size, ground plan, zones, and deletion status.
    /// </summary>
    public record PlantationSiteDto
    {
        /// <summary>
        /// The unique identifier of the plantation site.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the plantation site.
        /// </summary>
        [Required(ErrorMessage = "Naam is verplicht.")]
        public required string Name { get; set; }

        /// <summary>
        /// The street name where the plantation site is located.
        /// </summary>
        [Required(ErrorMessage = "Straat is verplicht.")]
        public required string Street { get; set; }

        /// <summary>
        /// The house number of the plantation site, including optional letter, fraction, or "bis" notation.
        /// </summary>
        [Required(ErrorMessage = "Huisnummer is verplicht.")]
        [StringLength(10, ErrorMessage = "Huisnummer mag maximum 10 tekens bevatten.")]
        [RegularExpression(@"^[0-9]+[a-zA-Z]?(/?[0-9]+)?(bis)?$", ErrorMessage = "Ongeldig formaat")]
        public required string HouseNumber { get; set; }

        /// <summary>
        /// The city where the plantation site is located.
        /// </summary>
        [Required(ErrorMessage = "Stad is verplicht.")]
        public required string City { get; set; }

        /// <summary>
        /// The postal code of the plantation site's location (must be between 1000 and 9999).
        /// </summary>
        [Range(1000, 9999, ErrorMessage = "Postcode moet een getal zijn tussen 1000 en 9999.")]
        public int PostalCode { get; set; }


        /// <summary>
        /// The country where the plantation site is located.
        /// </summary>
        [Required(ErrorMessage = "Land is verplicht.")]
        public required string Country { get; set; }

        /// <summary>
        /// The size of the plantation site in appropriate units (must be zero or positive).
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Oppervlakte kan niet een negatief getal zijn")]
        public double Size { get; set; }

        /// <summary>
        /// The ground plan of the plantation site.
        /// </summary>
        [Required(ErrorMessage = "Plattegrond is verplicht")]
        public required string GroundPlan { get; set; }

        /// <summary>
        /// The collection of zones associated with the plantation site.
        /// </summary>
        public ICollection<ZoneDto>? Zones { get; set; }
    }
}
