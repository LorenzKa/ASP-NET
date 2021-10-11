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
            return null;
        }
    }
}
