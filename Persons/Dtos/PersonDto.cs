

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Persons.Dtos
{
    public class PersonDto
    {

        [RegularExpression(Regex.Firstname)]
        public string? Firstname { get; set; }

        [RegularExpression(Regex.Lastname)]
        public string? Lastname { get; set; }

        [RegularExpression(Regex.Birthday)]
        public string Born { get; set; } = null!;

        [RegularExpression(Regex.Tel)]
        public string? Tel { get; set; }

        public AdressDto? Adress { get; set; } = null!;
    }
}
