using System.ComponentModel.DataAnnotations;

namespace Flash.Application.Dtos
{
    public class CreateCardDto
    {
        [Required]
        [MinLength(1)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public string Matter { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public string Urgency { get; set; } = string.Empty;
    }
}
