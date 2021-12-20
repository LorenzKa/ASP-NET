

namespace Persons.Dtos
{
    public class PersonDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string Born { get; set; } = null!;
        public string? Tel { get; set; }

        public AdressDto? Adress { get; set; } = null!;
    }
}
