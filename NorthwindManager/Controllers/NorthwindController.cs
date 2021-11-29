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
        [HttpGet("Employees")]
        public IActionResult getEmployees()
        {
            return Ok(service.GetEmployees());
        }
        [HttpGet("Customers")]
        public IActionResult getCustomers()
        {
            return Ok(service.GetCustomers());
        }
        [HttpGet("Customers/{id}")]
        public IActionResult getOrderForCustomer(string id)
        {
            return Ok(service.GetOrdersForCustomer(id));
        }
        [HttpGet("Employees/{id}")]
        public IActionResult getOrderForEmployee(long id)
        {
            return Ok(service.GetOrdersForEmployees(id));
        }
        [HttpGet("OrderDetails/{id}")]
        public IActionResult getOrderDetails(int id)
        {
            return Ok(service.GetOrderDetails(id));
        }
    }
}
