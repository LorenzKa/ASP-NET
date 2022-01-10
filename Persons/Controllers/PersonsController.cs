using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persons.Dtos;
using Persons.Services;

namespace Persons.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonsService service;

        public PersonsController(PersonsService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult persons()
        {
            return Ok(service.allPersons());
        }
        [HttpGet("{id}")]
        public IActionResult person(long id)
        {
            return Ok(service.singlePerson(id));
        }
        [HttpPost]
        public IActionResult person(PersonDto person)
        {
            return Ok(service.addPerson(person));
        }
        [HttpGet]
        public IActionResult regex()
        {

            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(new { firstname = Regex.Firstname, lastname = Regex.Lastname, birthday = Regex.Birthday, tel = Regex.Tel, address = Regex.Address, adressStreetname = Regex.AddressStreetname, adressStreetNr = Regex.AdressStreetNr, cityCountryCode = Regex.CityCountryCode, cityPostalCode = Regex.CityPostalCode, cityStreetName = Regex.CityStreetName }));
        }
    }
}
