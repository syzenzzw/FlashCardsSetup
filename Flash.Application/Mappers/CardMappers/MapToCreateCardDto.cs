using Flash.Application.Dtos;
using Flash.Domain.Models.Card;

namespace Flash.Application.Mappers.CardMappers 
{
    public static class MapToCreateCardDto
    {
        public static Card MapToCreate(CreateCardDto cardDto) => new Card
        {
            Content = cardDto.Content,
            Matter = cardDto.Matter,
            Urgency = cardDto.Urgency
        };
    }
}