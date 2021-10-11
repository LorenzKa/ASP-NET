using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI.Controllers
{
    [Route("api/todo-items")]
    [ApiController]
    public class MyToDoController : ControllerBase
    {
        private readonly static List<string> items = new List<string>
        {
            "Programming",
            "More Programming",
            "A lot more Programming"
        };
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(items);
        }
        [HttpGet]
        [Route("{index}", Name = "GetSpecificItem")]
        public IActionResult GetSpecificItem(int index)
        {
            if(index < 0 || index > items.Count - 1)
            {
                return BadRequest("Invalid Index.");
            }
            else
            {
                return Ok(items[index]);
            }
        }
        [HttpPost]
        public IActionResult AddItem([FromBody] string item)
        {
            items.Add(item);
            return CreatedAtRoute("GetSpecificItem", new { index = items.IndexOf(item) }, item);
        }
        [HttpDelete]
        [Route("{index}")]
        public IActionResult DeleteItem(int index)
        {
            if (index < 0 || index > items.Count - 1)
            {
                return BadRequest("Invalid Index.");
            }
            items.RemoveAt(index);
            return NoContent();
        }
        [HttpPut]
        [Route("{index}")]
        public IActionResult UpdateItem(int index,[FromBody] string item)
        {
            if (index < 0 || index > items.Count - 1)
            {
                return BadRequest("Invalid Index.");
            }
            items[index] = item;
            return Ok();
        }
        [HttpGet] // /api/todo-items/sorted?sortOrder=asc
        [Route("sorted")]
        public IActionResult GetAllItemsSorted([FromQuery]string sortOrder)
        {
            return sortOrder switch
            {
                "desc" => Ok(items.OrderByDescending(item => item)),
                "asc" => Ok(items.OrderBy(item => item)),
                _ => BadRequest("Invalid or missing sortorder query paramter")
            };
        }
    }
}
