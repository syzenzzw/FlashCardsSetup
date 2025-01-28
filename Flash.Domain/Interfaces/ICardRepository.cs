

using Flash.Domain.Models.Card;

namespace Flash.Domain.Interfaces.ICardRepository
{
    public interface ICardRepository
    {
        public Task<List<Card>> GetAll();
        public Task<Card> GetById(int id);
        public Task<Card> CreateCard(Card cardModel);
        public Task<Card> Update(Card cardModel, int id);
        public Task<Card> Delete(int id);
        public Task<ArraySegment<Card>> GetAllMatter();
    }
}
