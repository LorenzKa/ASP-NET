using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Persons.Dtos
{
    public class CityDto
    {
        [RegularExpression(Regex.CityCountryCode)]
        public string? CountryCode { get; set; }
        [RegularExpression(Regex.CityPostalCode)]
        public long PostalCode { get; set; }
        [RegularExpression(Regex.CityStreetName)]
        public string? Name { get; set; }

    }
}
