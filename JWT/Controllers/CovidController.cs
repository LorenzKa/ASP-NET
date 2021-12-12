using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using JWT.Dto;
using JWT.Services;

namespace JWT.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        private static List<CasesDelta> casesDeltas = new List<CasesDelta>();
        private static List<CasesFederalStates> casesFederalStates = new List<CasesFederalStates>();
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetDelta()
        {
            readPublicData();
            return Ok(casesDeltas);
        }
        [HttpGet("{id}")]
        public IActionResult GetCasesForFederalState(int id)
        {
            
            return Ok(readSecretData(id));
        }
        public static void readPublicData()
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
        public static List<CasesFederalStates> readSecretData(int federalStateId)
        {
            return System.IO.File.ReadAllLines("Data/CovidFaelleFederalStates.csv")
                .Skip(1)
                .Select(line => line.Split(';'))
                .Where(line => int.Parse(line[7]) == federalStateId)
                .Select(x => new CasesFederalStates()
                {
                    Date = x[0],
                    HospitalCount = int.Parse(x[3].ToString()),
                    ICUCount = int.Parse(x[4].ToString()),
                    FederalState = x[8]
                }).ToList();
        }
    }
}
