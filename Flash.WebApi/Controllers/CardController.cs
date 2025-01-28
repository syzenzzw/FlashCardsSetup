using Flash.Application.Dtos;
using Flash.InfraStructure.Data;
using Flash.InfraStructure.Repositories.CardRepository;
using Microsoft.AspNetCore.Mvc;
using Flash.Application.Mappers.CardMappers;
using Flash.Domain.Interfaces.ICardRepository;

namespace Flash.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class CardController : ControllerBase
    {
        private readonly ICardRepository? _cardRepo;
        private readonly ApplicationDbContext? _context;
        
        public CardController (ICardRepository cardRepo, ApplicationDbContext context)
        {
            _cardRepo = cardRepo;
            _context = context;
        }

        [HttpGet("{id:int}")]
        
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var card = await _cardRepo!.GetById(id);

            if (card == null) return NotFound();

            return Ok(card);
        }


        [HttpPost]

        public async Task<IActionResult> CreateCard([FromBody] CreateCardDto cardDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var cardModel = cardDto.MapToCreate();

            var response = await _cardRepo!.CreateCard(cardModel);

            return CreatedAtAction(nameof(GetById), new { id = cardModel.Id }, cardModel.MapToDto());
        }
    }
}
