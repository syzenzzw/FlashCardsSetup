using Flash.Application.Dtos;
using Flash.InfraStructure.Data;
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

        [HttpGet("GetAllCards")]
            
        public async Task<IActionResult> GetAll()
        {
            var card = await _cardRepo!.GetAll();
            var cardDto = card.Select(s => s.MapToDto());
            
            if(card == null) return NotFound();

            return Ok(card);
        }

        [HttpGet("GetAllMatters")]
        
        public async Task<IActionResult> GetAllMatters()
        {
            var matter = await _cardRepo!.GetAllMatter();
            var matterDto = matter.Select(s => s.ToMapMatter());
            int count = 0;

            foreach (var item in matterDto)
            {

                if (item == item)
                {
                    count++;
                }
            }

            var result = new
            {
                Matters = matterDto,
                Count = count
            };

            return Ok(result);
        }


        [HttpGet("{id:int}")]
        
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var card = await _cardRepo!.GetById(id);

            if (card == null) return NotFound();

            return Ok(card);
        }


        [HttpPost("CreateCard")]

        public async Task<IActionResult> CreateCard([FromBody] CreateCardDto cardDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var cardModel = cardDto.MapToCreate();

            var response = await _cardRepo!.CreateCard(cardModel);

            return CreatedAtAction(nameof(GetById), new { id = cardModel.Id }, cardModel.MapToDto());
        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> NowIsRevised([FromRoute] int id, RevisedDto revisedDto)
        {
            var revisedModel = revisedDto.ToMapRevised();
            var revisedUpdate = await _cardRepo!.Revised(id);

            return Ok(revisedUpdate);
            
        }


    }
}
