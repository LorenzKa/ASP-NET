using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Persons.Dtos
{
    
    public class AdressDto
    {
        [RegularExpression(Regex.AddressStreetname)]
        public string? StreetName { get; set; }
        [RegularExpression(Regex.AdressStreetNr)]
        public long StreetNr { get; set; }

        public CityDto? City { get; set; }
    }
}
