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
    }
}
