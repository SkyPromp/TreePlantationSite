namespace AP.BTP.Contracts.DTOs.PlantNet
{
    public record PlantNetSpeciesDTO
    {
        public string? ScientificNameWithoutAuthor { get; set; }
        public PlantNetFamilyDTO? Family { get; set; }
        public List<string> CommonNames { get; set; } = new List<string>();
    }    
}