using Flash.Application.Dtos;
using Flash.Domain.Models.Card;

namespace Flash.Application.Mappers.CardMappers
{
    public static class MapToCardMatterDto
    {
        public static CardMatterDto ToMapMatter(this Card cardModel)
        {
            return new CardMatterDto
            {
                Id = cardModel.Id,
                Matter = cardModel.Matter,
            };
        }
    }
}
