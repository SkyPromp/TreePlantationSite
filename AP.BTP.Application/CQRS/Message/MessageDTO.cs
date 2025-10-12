using System.ComponentModel.DataAnnotations;

namespace AP.BTP.Application.CQRS.Message
{
    public class MessageDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public required string Content { get; set; }
    }
}
