namespace Flash.Application.Dtos
{
    public class CreateCardDto
    {
        public string Content { get; set; } = string.Empty;
        public string Matter { get; set; } = string.Empty;
        public string Urgency { get; set; } = string.Empty;
    }
}
