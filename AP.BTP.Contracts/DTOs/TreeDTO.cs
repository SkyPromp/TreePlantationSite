namespace AP.BTP.Contracts.DTOs
{
    public record TreeDTO
    {
        public int Id { get; set; }
        public required string Species { get; set; }
        public string? MaintenancePlan { get; set; }
    }
}
