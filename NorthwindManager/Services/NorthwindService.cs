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
            var employees = new List<EmployeeDto>();
            db.Employees.ToList().ForEach(x => employees.Add(new EmployeeDto()
            {
                Name = x.FirstName + " " + x.LastName,
                City = x.City,
                Country = x.Country,
                Id = x.EmployeeId
            }));
            return employees;
        }
        public List<CustomerDto> GetCustomers()
        {
            var customers = new List<CustomerDto>();
            db.Customers.ToList().ForEach(x => customers.Add(new CustomerDto()
            {
                Id = x.CustomerId,
                City = x.City,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                Country = x.Country

            }));
            return customers;
        }
    }
}
