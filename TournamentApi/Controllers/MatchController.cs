using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentApi.Services;
using TournamentDb;
using TournamentDb.DTO;
using TournamentDb.Extensions;

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
        [Route("GenerateRound")]
        public IActionResult GenerateRound()
        {
            try
            {
                return Ok(ConvertMatchesToDto(_service.GenerateMatches()));
            }
            catch (ApplicationException)
            {
                return BadRequest("Not all Matches have winners");
            }
            catch (IndexOutOfRangeException)
            {
                return BadRequest("Match numbers is not correct. Delete current tournament");
            }
            catch (AggregateException)
            {
                return BadRequest("Number of Players is not correct");
            }
        }
        [HttpPost]
        public IActionResult SetWinner([FromBody] MatchWinnerDto winnerDto)
        {
            try
            {
                var response = _service.SetWinner(winnerDto);
                return Ok(new MatchWinnerResponse()
                {
                    MatchId = response.Id,
                    Winner= (int)response.Winner
                });;
            }
            catch(IndexOutOfRangeException)
            {
                return BadRequest("Provide valid WinnerId");
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Provide valid MatchId");
            }
        }
        [HttpGet]
        [Route("WihoutWinner")]
        public IActionResult getWithoutWinner()
        {
            List<Match> matches = _service.returnWithoutWinner();
            if (matches.Count == 0)
            {
                return Ok(matches);
            }
            else
            {
                return Ok(ConvertMatchesToDto(matches));
            }
        }
        [HttpGet]
        [Route("CurrentRound")]
        public IActionResult getCurrentRound()
        {
            List<Match> matches = _service.returnCurrentRound();
            if (matches.Count == 0)
            {
                return Ok(matches);
            }
            else
            {
                return Ok(ConvertMatchesToDto(matches));
            }
        }
        [HttpGet]
        public IActionResult getAllMatches()
        {
            return Ok(_service.AllMatches());
        }
        [HttpDelete]
        public IActionResult DeleteAll()
        {
            _service.DeleteAll();
            return NoContent();
        }
        private static MatchListDto ConvertMatchesToDto(List<Match> matches)
        {
            var dto = new MatchListDto();
            dto.Matches = new List<MatchDto>();
            dto.RoundNumber = matches[0].RoundNumber;
            matches.ForEach(x => dto.Matches.Add(new MatchDto
            {
                Id = x.Id,
                Winner = x.Winner,
                Player1 = new PlayerDto
                {
                    Id = x.Player1.Id,
                    Gender = x.Player1.Gender,
                    Name = $"{x.Player1.Firstname} {x.Player1.Lastname}"
                },
                Player2 = new PlayerDto
                {
                    Id = x.Player2.Id,
                    Gender = x.Player2.Gender,
                    Name = $"{x.Player2.Firstname} {x.Player2.Lastname}"
                },

            }));
            return dto;
        }

    }
}
