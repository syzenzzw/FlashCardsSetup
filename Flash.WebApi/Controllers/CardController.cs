﻿using Flash.Application.Dtos;
using Flash.InfraStructure.Data;
using Microsoft.AspNetCore.Mvc;
using Flash.Application.Mappers.CardMappers;
using Flash.Domain.Interfaces.ICardRepository;
using Flash.WebApi.ModelViews;

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
            
        public async Task<IActionResult> GetAll(int pageIndex = 1, int pageSize = 20)
        {
            var cardModel = await _cardRepo!.GetAll(pageIndex, pageSize);
            var cardDto = cardModel.Select(m => m.MapToDto()).ToList();
            List<CardDto> revisedCardDtos = new List<CardDto>(cardDto);


            return Ok(cardDto);
        }

        [HttpGet("GetAllMatters")]
        
        public async Task<IActionResult> GetAllMatters()
        {
            var matter = await _cardRepo!.GetAllMatter();
            var matterDto = matter.Select(s => s.ToMapMatter()).ToList();
            var distinctMatter = 
            matterDto
            .DistinctBy(m => m.Matter)
            .ToList();

            return Ok(distinctMatter);
        }


        [HttpGet("PegarPelaId{id:int}")]
        
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var card = await _cardRepo!.GetById(id);
            var cardDto = card.MapToDto();

            if (card == null) return NotFound();

            if (cardDto.Revised == "True")
            {
                cardDto.Revised = "Yes";
            }

            else
            {
                cardDto.Revised = "No";
            }

            return Ok(cardDto);
        }


        [HttpPost("CreateCard")]

        public async Task<IActionResult> CreateCard([FromBody] CreateCardDto cardDto)
        {
            if(!ModelState.IsValid)
                return BadRequest("erro no model state");

            var cardModel = cardDto.MapToCreate();


            var response = await _cardRepo!.CreateCard(cardModel);


            return CreatedAtAction(nameof(GetById), new { id = cardModel.Id }, cardModel.MapToDto());
        }

        [HttpPut("ChangeRevised{id:int}")]

        public async Task<IActionResult> NowIsRevised([FromRoute] int id, RevisedDto revisedDto)
        {
            var revisedModel = revisedDto.ToMapRevised();
            var revisedUpdate = await _cardRepo!.Revised(id);

            return Ok(revisedUpdate);
            
        }

        [HttpPut("AtualizarConteudo{id:int}")]
        
        public async Task<IActionResult> UpdateContent([FromRoute] int id, [FromBody] UpdateCardDto cardDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            

            var cardModel = cardDto.ToUpdateCard();

            var newCard = await _cardRepo!.Update(cardModel, id);

            if (newCard == null) return NotFound();

            return Ok(new ResponseUpdateModelView("Flash-Card update with sucess! "));
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteCard([FromRoute] int id)
        {
            var cardDelete =  await _cardRepo!.Delete(id);    
            
            if (cardDelete == null) return NotFound();

            return Ok(cardDelete);
        }
    }
}
