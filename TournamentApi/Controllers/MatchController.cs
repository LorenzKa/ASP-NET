using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentApi.Services;

namespace TournamentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly MatchService db;

        public MatchController(MatchService db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult generateRound()
        {
            return Ok(db.GenerateMatches());
        }
    }
}
