using System.Collections.Generic;
using System.Linq;
using ToDoDatabase;
using ToDoWebApi.DTOs;

namespace ToDoWebApi.Services
{
    public class ToDoService
    {
        private readonly ToDoDbContext _toDoDbContext;
        public ToDoService(ToDoDbContext toDoDbContext)
        {
            _toDoDbContext = toDoDbContext;
        }
        public List<PersonDto> GetAllPersons()
        {
            return _toDoDbContext.Persons.OrderBy(x => x.Lastname).Select(p => new PersonDto
            {
                Name = p.Firstname + " " + p.Lastname,
                Email = p.Email
            }).ToList();
        }

    }
}