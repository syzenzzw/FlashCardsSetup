using Flash.Domain.Helpers;
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

        public async Task<QueryHelpers<Card>> GetAll(int pageIndex, int pageSize)
        {
            var cards = await _context.Cards
                .OrderBy(b => b.Id)
                //Ao pular uma página ele vai contar quantos objetos ele passou
                //até estar ali
                //Ex: pag 1; (1 - 1 = 0) * 20 == 0; isso significa que ele vai ter que pular 20 objetos para estar ali
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
                
            var count = await _context.Cards.CountAsync();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new QueryHelpers<Card>(cards, pageIndex, totalPages);
        }

        public async Task<List<Card>> GetAllMatter()
        {
            var card = await _context.Cards.ToListAsync();

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

        public async Task<Card> Revised(int id)
        {
            var card = await _context.Cards!.FindAsync(id);

            if (card == null) return null!;

            card.Revised = true;

            await _context.SaveChangesAsync();

            return card;
        }

        public async Task<Card> Update(Card cardModel, int id)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);

            if (card == null) return null!;

            card.Content = cardModel.Content;

            _context.Update(card);

            await _context.SaveChangesAsync();

            return card;
        }
    }
}
