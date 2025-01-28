using Flash.Application.Dtos;
using Flash.Domain.Models.Card;

namespace Flash.Application.Mappers.CardMappers
{
    public static class MapToRevisedDto
    {
        public static Card ToMapRevised(this RevisedDto cardDto)
        {
            return new Card
            {
                Revised = cardDto.Revised,
            };
        }
    }
}
