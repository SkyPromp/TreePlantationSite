using System.ComponentModel.DataAnnotations;

namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a plantation site, including address, size, ground plan, zones, and deletion status.
    /// </summary>
    public class PlantationSiteDTO
    {
        /// <summary>
        /// The unique identifier of the plantation site.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the plantation site.
        /// </summary>
        [Required(ErrorMessage = "Name name is required.")]
        public required string Name { get; set; }

        /// <summary>
        /// The street name where the plantation site is located.
        /// </summary>
        [Required(ErrorMessage = "Street is required.")]
        public required string Street { get; set; }

        /// <summary>
        /// The house number of the plantation site, including optional letter, fraction, or "bis" notation.
        /// </summary>
        [Required(ErrorMessage = "House number is required.")]
        [StringLength(10, ErrorMessage = "House number must be at most 10 characters.")]
        [RegularExpression(@"^[0-9]+[a-zA-Z]?(/?[0-9]+)?(bis)?$", ErrorMessage = "Invalid house number format.")]
        public required string HouseNumber { get; set; }

        /// <summary>
        /// The city where the plantation site is located.
        /// </summary>
        [Required(ErrorMessage = "City is required.")]
        public required string City { get; set; }

        /// <summary>
        /// The postal code of the plantation site's location (must be between 1000 and 9999).
        /// </summary>
        [Range(1000, 9999, ErrorMessage = "Postal code is must be between 1000 and 9999.")]
        public int PostalCode { get; set; }


        /// <summary>
        /// The country where the plantation site is located.
        /// </summary>
        [Required(ErrorMessage = "Country is required.")]
        public required string Country { get; set; }

        /// <summary>
        /// The size of the plantation site in appropriate units (must be zero or positive).
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Size must be zero or positive.")]
        public double Size { get; set; }

        /// <summary>
        /// The ground plan of the plantation site.
        /// </summary>
        [Required(ErrorMessage = "Ground plan is required.")]
        public required string GroundPlan { get; set; }

        /// <summary>
        /// The collection of zones associated with the plantation site.
        /// </summary>
        public ICollection<ZoneDTO>? Zones { get; set; }
    }
}
