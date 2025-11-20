namespace AP.BTP.Contracts.DTOs
{
    public record TreePictureDTO
    {
        public int Id { get; set; }
        public required string Path { get; set; }
        public bool IsFavourite { get; set; }
        public int TreeId { get; set; }
    }
}