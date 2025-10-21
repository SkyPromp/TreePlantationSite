using AP.BTP.Domain.Interfaces;

namespace AP.BTP.Domain
{
    public class PlantationSite : IDeletable
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
        public required string City { get; set; }
        public int PostalCode { get; set; }        
        public required string Country { get; set; }
        public required string GroundPlan { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}