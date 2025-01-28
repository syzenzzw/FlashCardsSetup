using System.ComponentModel.DataAnnotations;

namespace Flash.Application.Dtos
{
    public class UpdateCardDto
    {
        [Required]
        [MinLength(1)]
        public string Content { get; set; } = string.Empty;

        public bool Revised { get; set; } = false;
    }
}
