using Flash.Domain.Interfaces.ICardRepository;
using Flash.Domain.Models.Card;
using Flash.InfraStructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Flash.InfraStructure.Repositories.CardRepository
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;
        public CardRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<Card> CreateCard(Card cardModel)
        {
            await _context.Cards.AddAsync(cardModel);
            await _context.SaveChangesAsync();
            return cardModel;
        }

        public async Task<Card> Delete(int id)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);

            if (card == null) return null!;


            _context.Remove(card);
            await _context.SaveChangesAsync();
            return card!;
        }

        public async Task<List<Card>> GetAll()
        {
            var cards = await _context.Cards.ToListAsync(); 
            return cards;
        }

        public async Task<ArraySegment<Card>> GetAllMatter()
        {
            var card = await _context.Cards.ToArrayAsync();

            if (card == null)
            {
                return null!;
            }


            return card;
        }

        public async Task<Card> GetById(int id)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);
            
            if(card == null) return null!;

            return card!;
        }

        public async Task<Card> Update(Card cardModel, int id)
        {
            var card = await _context.Cards.FindAsync(id);

            if (card == null) return null!;

            card.Content = cardModel.Content;

            _context.Update(card);

            await _context.SaveChangesAsync();

            return card;
        }
    }
}
