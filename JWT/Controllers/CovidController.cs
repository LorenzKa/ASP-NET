using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using JWT.Dto;

namespace JWT.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class CovidController : ControllerBase
    {

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetDelta()
        {
            readData();
            return Ok(casesDeltas);
        }

        static List<CasesDelta> casesDeltas = new List<CasesDelta>();
        public static void readData()
        {
            if (casesDeltas.Count == 0)
            {
                casesDeltas.AddRange(System.IO.File.ReadAllLines("Data/CovidFaelleDelta.csv")
                    .Skip(1)
                    .Select(line => line.Split(';'))
                    .Select(x => new CasesDelta()
                    {
                        Date = x[0].Split(" ")[0],
                        Cases = int.Parse(x[1].ToString()),
                        Healed = int.Parse(x[2].ToString()),
                        Deaths = int.Parse(x[3].ToString()),
                        Active = int.Parse(x[4].ToString()),
                        Tests = int.Parse(x[5].ToString())
                    }).ToList());
            }
        }
    }
}
