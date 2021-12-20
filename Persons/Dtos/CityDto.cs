using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Persons.Dtos
{
    public class CityDto
    {
        public string? CountryCode { get; set; }
        public long PostalCode { get; set; }
        public string? Name { get; set; }

    }
}
