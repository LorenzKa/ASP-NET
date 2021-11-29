using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindManager.Dtos;

namespace NorthwindManager.Services
{

    public class NorthwindService
    {
        private readonly NorthwindManagerContext db;

        

        public NorthwindService(NorthwindManagerContext db)
        {
            this.db = db;
        }
        public NorthwindService()
        {
        }
        public List<EmployeeDto> GetEmployees()
        {
            return db.Employees.ToList().Select(x => new EmployeeDto()
            {
                Name = x.FirstName + " " + x.LastName,
                City = x.City,
                Country = x.Country,
                Id = x.EmployeeId
            }).ToList();
        }
        public List<CustomerDto> GetCustomers()
        {
            
            return db.Customers.ToList().Select(x => new CustomerDto()
            {
                Id = x.CustomerId,
                City = x.City,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                Country = x.Country

            }).ToList();
        }
        public List<OrderDto> GetOrdersForCustomer(string id)
        {
            return db.Customers.Where(x => x.CustomerId == id).Include(x => x.Orders).ThenInclude(x => x.OrderDetails).FirstOrDefault().Orders.Select(x => new OrderDto()
            {

                Id = x.OrderId,
                NrOrderDetails = x.OrderDetails.Count,
                OrderDate = x.OrderDate,
                RequiredDate = x.RequiredDate,
                ShippedDate = x.ShippedDate,
            }).ToList();
        }
        public List<OrderDto> GetOrdersForEmployees(long id)
        {
            return db.Employees.Where(x => x.EmployeeId == id).Include(x => x.Orders).ThenInclude(x => x.OrderDetails).FirstOrDefault().Orders.Select(x => new OrderDto()
            {

                Id = x.OrderId,
                NrOrderDetails = x.OrderDetails.Count,
                OrderDate = x.OrderDate,
                RequiredDate = x.RequiredDate,
                ShippedDate = x.ShippedDate,
            }).ToList();
        }
        public List<OrderDetailsDto> GetOrderDetails (int id)
        {
            return db.Orders.Where(x => x.OrderId == id).Include(x => x.OrderDetails).ThenInclude(x => x.Product).FirstOrDefault().OrderDetails.Select(x => new OrderDetailsDto()
            {
                OrderId = x.OrderId,
                ProductName = x.Product.ProductName,
                Quantity = x.Quantity,
                UnitPrice = (double)x.UnitPrice
            }).ToList();
        }
    }
}
