using System.Text.Json.Serialization;
using AP.BTP.Domain.Interfaces;

namespace AP.BTP.Domain
{
    public class TreePicture : IDeletable
    {
        public int Id { get; set; }
        public required string Path { get; set; }
        public bool IsFavourite { get; set; }
        public bool IsDeleted { get; set; }
        public int TreeId { get; set; }
        [JsonIgnore] public required Tree Tree { get; set; }
    }   
}