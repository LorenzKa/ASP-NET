using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentApi.Services;
using TournamentDb.DTO;

namespace TournamentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly MatchService _service;

        public MatchController(MatchService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult GenerateRound()
        {
            return Ok(_service.GenerateMatches());
        }
        
        [HttpPost]
        public IActionResult SetWinner([FromBody] SetWinnerDto winnerDto)
        {
            return Ok(_service.SetWinner(winnerDto));
        }

    }
}
