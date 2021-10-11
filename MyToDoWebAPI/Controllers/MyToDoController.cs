using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI.Controllers
{
    [Route("contacts")]
    [ApiController]
    public class MyToDoController : ControllerBase
    {
        private readonly static List<Contact> contacts = new List<Contact>
        {
            new Contact
            {
                Id = 0,
                FirstName = "Jakob",
                LastName = "Schlager",
                Email = "schlager.biz@gmail.com"
            },
            new Contact
            {
                Id = 1,
                FirstName = "Lorenz",
                LastName = "Kassewalder",
                Email = "kassewalder.biz@gmail.com"
            },
        };
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            return Ok(contacts);
        }
        
        [HttpPost]
        public IActionResult AddContact([FromBody] ContactDTO contact)
        {
            
            Contact toAdd = convertContactDto(contact);
            if (toAdd.Email != "" && toAdd.FirstName != "" && toAdd.LastName != "")
            {
                contacts.Add(toAdd);
                return Ok(contacts[contacts.IndexOf(toAdd)]);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{personId}")]
        public IActionResult DeleteContact(int personId)
        {
            
            if (contacts[personId] != null)
            {
                contacts.RemoveAt(personId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet]
        [Route("findByName")]
        public IActionResult FindByName([FromQuery] string name)
        {
            name = name.ToLower();
            List<Contact> filteredContacts = contacts.Where(x => x.LastName.ToLower().Contains(name) || x.FirstName.ToLower().Contains(name)).ToList();
            if (filteredContacts.Count > 0)
            {
                return Ok(filteredContacts);
            }
            else
            {
                return BadRequest(filteredContacts);
            }
        }
        private Contact convertContactDto(ContactDTO contact)
        {
            return new Contact { Id = contacts.Count, FirstName = contact.FirstName, LastName = contact.LastName, Email = contact.Email };
        }
    }
}
