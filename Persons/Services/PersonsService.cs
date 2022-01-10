using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persons.Dtos;
using System.ComponentModel.DataAnnotations;

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
        public PersonDto addPerson(PersonDto person)
        {
            int adressId = 0;
            if (db.Cities.Where(x => x.PostalCode + x.Name == person.Adress.City.PostalCode + x.Name).FirstOrDefault() != null)
            {
                Console.WriteLine("City exists");
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
                Console.WriteLine("City doesnt exist");
                db.Cities.Add(new City()
                {
                    Id = cityid,
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
            Console.WriteLine("Saved City and Adress");
            var toAdd = new Person()
            {

                AdressId = adressId,
                Born = person.Born,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                Tel = person.Tel,

            };
            db.Persons.Add(toAdd);
            db.SaveChanges();
            toAdd.Adress.CityId = db.Cities.Where(x => x.PostalCode + x.Name == person.Adress.City.PostalCode + x.Name).FirstOrDefault().Id;
            db.Persons.Update(toAdd);
            db.SaveChanges();
            return singlePerson(toAdd.Id);
        }
        public PersonDto singlePerson(long id)
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
