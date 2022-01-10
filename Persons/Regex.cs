using Newtonsoft.Json;

namespace Persons
{
    public static class Regex
    {
        public const string Firstname = @"^[A-Z][a-z]{2,}$";
        public const string Lastname = @"^[A-Z]{1,}\w*$";
        public const string Birthday = @"^[0-3]\d.[0-3]\d.[12]\d{3}$";
        public const string Tel = @"^\+\d{1,3} \(\d\d\) \d*$";
        public const string Address = @"^[A-Z]-\d{4,5} [A-Z]\w*, [A-Z]\w* \d*$";
        public const string AddressStreetname = @"^\w{2,}$";
        public const string AdressStreetNr = @"^\d*$";
        public const string CityCountryCode = @"^[A-Z]$";
        public const string CityPostalCode = @"^\d{4,5}$";
        public const string CityStreetName = @"^[A-Z]\w*$";

    }
}
