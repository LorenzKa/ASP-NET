using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentApi.Services;
using TournamentDb;
using TournamentDb.DTO;

namespace TournamentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _service;

        public PlayerController(PlayerService service)
        {
            this._service = service;
        }
        [HttpGet]
        public IActionResult GetPlayers()
        {
            return Ok(convertPlayersToDto(_service.GetPlayers()));
        }
        private List<PlayerDto> convertPlayersToDto(List<Player> players)
        {
            List<PlayerDto> dtoPlayers = new List<PlayerDto>();
            players.ForEach(x => dtoPlayers.Add(new PlayerDto
            {
                Id = x.Id,
                Name = $"{x.Firstname} {x.Lastname}",
                Gender = x.Gender
            }));
            return dtoPlayers;
        }
    }
}
