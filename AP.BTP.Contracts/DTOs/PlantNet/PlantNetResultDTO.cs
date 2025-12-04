namespace AP.BTP.Contracts.DTOs.PlantNet
{
    public record PlantNetResultDTO
    {
        public double Score { get; set; }
        public PlantNetSpeciesDTO? Species { get; set; }
    }
}