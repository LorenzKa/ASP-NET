using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindManager.Services;

namespace NorthwindManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly NorthwindService service;

        public NorthwindController(NorthwindService service)
        {
            this.service = service;
        }
        [HttpGet("GetEmployees")]
        public IActionResult getEmployees()
        {
            return Ok(service.GetEmployees());
        }
        [HttpGet("GetCustomers")]
        public IActionResult getCustomers()
        {
            return Ok(service.GetCustomers());
        }
    }
}
