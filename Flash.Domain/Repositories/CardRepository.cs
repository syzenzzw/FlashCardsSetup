using Flash.Domain.Interfaces.ICardRepository;
using Flash.Domain.Models.Card;

namespace Flash.Domain.Repositories.CardRepository
{
    public class CardRepository : ICardRepository
    {
        private readonly ICardRepository _cardRepo;   

        public CardRepository(ICardRepository cardRepo)
        {
            _cardRepo = cardRepo;
        }

        public async Task<Card> CreateCard(Card cardModel)
        {
            var card = new Card
            {
                Content = cardModel.Content,
                CreatedOn = cardModel.CreatedOn,
                Matter = cardModel.Matter,
                Urgency = cardModel.Urgency,
                Revised = cardModel.Revised
            };

            return await _cardRepo.CreateCard(card);
        }

        public Task<Card> Delete(int id)
        {
            return _cardRepo.Delete(id);
        }

        public async Task<List<Card>> GetAll()
        {
           return await _cardRepo.GetAll(); 
        }

        public async Task<Card> GetAllMatter(Card cardModel)
        {
            return await _cardRepo.GetAllMatter(cardModel);
        }

        public async Task<Card> GetById(int id)
        {
            return await _cardRepo.GetById(id);
        }

        public async Task<Card> Update(Card cardModel)
        {
            return await _cardRepo.Update(cardModel);
        }
    }

}