using Flash.Application.Dtos;
using Flash.Domain.Models.Card;

namespace Flash.Application.Mappers.CardMappers
{ 
    public static class MapCardDto
    {
        public static CardDto MapToDto(this Card card)
        {
            return new CardDto
            {
                Id = card.Id,
                Content = card.Content,
                CreatedOn = card.CreatedOn.ToString(),
                Matter = card.Matter,
                Urgency = card.Urgency,
                Revised = card.Revised.ToString(),
            };

        }
    }
}
