using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Persons.Dtos
{
    
    public class AdressDto
    {
        public string? StreetName { get; set; }
        public long StreetNr { get; set; }

        public CityDto? City { get; set; }
    }
}
