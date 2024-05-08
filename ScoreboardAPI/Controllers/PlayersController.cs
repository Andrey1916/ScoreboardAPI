using BusinessLogic.Dtos;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using ScoreboardAPI.Models;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScoreboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {

        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            var playerService = _playerService.GetAll();

            return playerService.Select(s =>
                new Player
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToList();
        }

        [HttpGet("{playerId}")]
        public ActionResult<Player> GetSportById(int sportId)
        {
            var playerService = _playerService.Get(sportId);

            if (playerService is null)
            {
                return NotFound("Player not found.");
            }

            var player = new Player
            {
                Id = playerService.Id,
                Name = playerService.Name,
            };

            return Ok(player);
        }

        [HttpPost]
        public ActionResult CreateSport([FromBody] Player newPlayer)
        {
            if (newPlayer == null)
            {
                return BadRequest("Invalid player data provided.");
            }

            if (string.IsNullOrWhiteSpace(newPlayer.Name))
            {
                return BadRequest("Invalid player name.");
            }

            int id = _playerService.Add(newPlayer.Name);

            return Created(id.ToString(), new { Id = id });
        }
      
        [HttpDelete("{playerId}")]
        public ActionResult DeleteSport(int playerId)
        {
            _playerService.Delete(playerId);

            return Ok();
        }
    }
}
