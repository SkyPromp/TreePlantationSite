using System.ComponentModel.DataAnnotations;

namespace AP.BTP.Contracts.DTOs
{
    public class PlantationSiteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name name is required.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        public required string Street { get; set; }

        [Required(ErrorMessage = "House number is required.")]
        [StringLength(10, ErrorMessage = "House number must be at most 10 characters.")]
        [RegularExpression(@"^[0-9]+[a-zA-Z]?(/?[0-9]+)?(bis)?$", ErrorMessage = "Invalid house number format.")]
        public required string HouseNumber { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public required string City { get; set; }

        [Range(1000, 9999, ErrorMessage = "Postal code is must be between 1000 and 9999.")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required.")]

        public required string Country { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Size must be zero or positive.")]
        public double Size { get; set; }

        [Required(ErrorMessage = "Ground plan is required.")]
        public required string GroundPlan { get; set; }

        public IEnumerable<ZoneDTO>? Zones { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
