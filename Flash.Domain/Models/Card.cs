namespace Flash.Domain.Models.Card
{
    public class Card
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string Matter { get; set; } = string.Empty;
        public string Urgency { get; set; } = string.Empty;
        public bool Revised { get; set; } = false;

        public string FormattedCreatedOn
        {
            get
            {
                return CreatedOn.ToString("yyyy-MM-dd"); 
            }

        }
    }
}

