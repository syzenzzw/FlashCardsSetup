using Flash.Application.Dtos;
using Flash.Domain.Models.Card;

namespace Flash.Application.Mappers.CardMappers
{
    public static class MapToUpdateCardDto
    {
        public static Card ToUpdateCard(this UpdateCardDto cardDto)
        {
            return new Card
            {
                Content = cardDto.Content,
            };
        }
        
    }
}
