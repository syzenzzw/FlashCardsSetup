namespace Flash.Application.Dtos
{
    public class CardDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string CreatedOn { get; set; } = string.Empty;
        public string Matter { get; set; } = string.Empty;
        public string Urgency { get; set; } = string.Empty;
        public bool Revised { get; set; } = false;

    }
}