namespace AP.BTP.Domain
{
    public class PlantationSite
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Street { get; set; }
        public int HouseNumber { get; set; }
        public required string City { get; set; }
        public int PostalCode { get; set; }        
        public required string Country { get; set; }
        public required string GroundPlan { get; set; }
    }
}