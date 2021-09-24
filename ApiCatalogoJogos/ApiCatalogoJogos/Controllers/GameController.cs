using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Services;
using ApiCatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

             

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> Get([FromQuery, Range(1, int.MaxValue)] int page = 1, [FromQuery, Range(1, 50)] int quantity = 5)
        {
            var game = await _gameService.Get(page, quantity);
            if (game.Count() == 0)
                return NoContent();

            return Ok(game);

        }
        [Route("idGame:guid")]
        [HttpGet]
        public async Task<ActionResult<GameViewModel>> GetById([FromRoute] Guid idGame)
        {
            var game = await _gameService.GetById(idGame);

            if (game == null)
                return NoContent();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> Insert([FromBody]GameInputModel gameInputModel)
        {
            try
            {
                var game = await _gameService.Insert(gameInputModel);

                return Ok(game);
            }
            catch (GameAlreadyRegisteredException ex)
            
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
            
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid idGame, [FromBody] GameInputModel gameInputModel)
        {
            try
            {
                await _gameService.Update(idGame, gameInputModel);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
            
        }

        [HttpPatch("{idJogo:guid}/price/{price:double}")]
        public async Task<ActionResult> Update([FromRoute] Guid idGame, [FromRoute] double price)
        {
            try
            {
                await _gameService.Update(idGame, price);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        [HttpDelete("{idGame:guid}")]
        public async Task<AcceptedResult> Delete([FromRoute] Guid idGame)
        {
            try
            {
                await _gameService.Remove(idGame);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
            
        }

    }
}
