namespace AP.BTP.Contracts.DTOs
{
    public record PlantResultDTO
    {
        public string? ScientificName { get; set; }
        public string? CommonName { get; set; }
        public string? Family { get; set; }
        public double Score { get; set; }
    }
}