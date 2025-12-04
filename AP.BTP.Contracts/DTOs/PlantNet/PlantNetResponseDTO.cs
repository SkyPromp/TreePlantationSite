namespace AP.BTP.Contracts.DTOs.PlantNet
{
    public record PlantNetResponseDTO
    {
        public List<PlantNetResultDTO> Results { get; set; } = new List<PlantNetResultDTO>();
    }
}