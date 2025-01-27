

using Flash.Domain.Models.Card;

namespace Flash.Domain.Interfaces.ICardRepository
{
    public interface ICardRepository
    {
        Task<List<Card>> GetAll();
        Task<Card> GetById(int id);
        Task<Card> CreateCard(Card cardModel);
        Task<Card> Update(Card cardModel);
        Task<Card> Delete(int id);
        Task<Card> GetAllMatter(Card cardModel);
    }
}
