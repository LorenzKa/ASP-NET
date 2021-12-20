using Persons.Dtos;

namespace Persons.Services
{
    public class PersonsService
    {
        private readonly PersonsContext db;

        public PersonsService(PersonsContext db)
        {
            this.db = db;
        }
        public List<PersonDto> allPersons()
        {
            var persons = new List<PersonDto>();
            db.Persons.Include(x => x.Adress).ThenInclude(x => x.City).ToList().ForEach(x => persons.Add(new PersonDto()
            {

                Born = x.Born,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Tel = x.Tel,
                Adress = new AdressDto()
                {
                    StreetName = x.Adress.StreetName,
                    StreetNr = x.Adress.StreetNr,
                    City = new CityDto()
                    {
                        CountryCode = x.Adress.City.CountryCode,
                        Name = x.Adress.City.Name,
                        PostalCode = x.Adress.City.PostalCode
                    }


                }
            }));
            return persons;
        }
        public Person addPerson(PersonDto person)
        {
            int adressId = 0;
            if (db.Cities.Where(x => x.PostalCode+x.Name == person.Adress.City.PostalCode+x.Name).FirstOrDefault() != null)
            {
                Console.WriteLine("wastrue");
                adressId = db.Adresses.Count() + 1;
                db.Adresses.Add(new Adress()
                {
                    Id = adressId,
                    StreetName = person.Adress.StreetName,
                    StreetNr = person.Adress.StreetNr


                });
                db.SaveChanges();
            }
            else
            {
                int cityid = db.Cities.Count() + 1;
                Console.WriteLine("wasfalse");
                db.Cities.Add(new City()
                {
                    Id =cityid,
                    Adresses = new List<Adress>(),
                    CountryCode = person.Adress.City.CountryCode,
                    Name = person.Adress.City.Name,
                    PostalCode = person.Adress.City.PostalCode
                });
                db.SaveChanges();
                Console.WriteLine("saved city");
                adressId = db.Adresses.Count() + 1;
                db.Adresses.Add(new Adress()
                {
                    Id = adressId,
                    StreetName = person.Adress.StreetName,
                    StreetNr = person.Adress.StreetNr,
                    CityId = cityid
                }); ;
                db.SaveChanges();
                Console.WriteLine("saved address");

            }
            Console.WriteLine("alsdkfjöasldjkf0");
            db.Persons.Add(new Person()
            {
                AdressId = adressId,
                Born = person.Born,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                Tel = person.Tel
            });
            
            db.SaveChanges();
            return null;
        }
        public PersonDto person(int id)
        {
            var x = db.Persons.Include(x => x.Adress).ThenInclude(x => x.City).Where(x => x.Id == id).First();

            return new PersonDto()
            {

                Born = x.Born,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Tel = x.Tel,
                Adress = new AdressDto()
                {
                    StreetName = x.Adress.StreetName,
                    StreetNr = x.Adress.StreetNr,
                    City = new CityDto()
                    {
                        CountryCode = x.Adress.City.CountryCode,
                        Name = x.Adress.City.Name,
                        PostalCode = x.Adress.City.PostalCode
                    }

                }
            };
        }
    }
}
