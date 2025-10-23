using System.ComponentModel.DataAnnotations;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    public class PlantationSiteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Street is required.")]
        public required string Street { get; set; }
        [Required(ErrorMessage = "House number is required.")]
        public int HouseNumber { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public required string City { get; set; }
        [Required(ErrorMessage = "Postal code is required.")]
        public int PostalCode { get; set; }        
        [Required(ErrorMessage = "Country is required.")]
        public required string Country { get; set; }
        [Required(ErrorMessage = "GroundPlan is required.")]
        public required string GroundPlan { get; set; }
    }
}
