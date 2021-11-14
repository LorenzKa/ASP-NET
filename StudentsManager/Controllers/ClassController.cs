using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsManagerDb;
using StudentsManagerDb.Dto;

namespace StudentsManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly StudentsManagerContext db;
        public ClassController(StudentsManagerContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetClasses()
        {
            var classes = new List<ClazzDto>();
            db.Clazzs.ToList().ForEach(x => classes.Add(new ClazzDto().CopyPropertiesFrom(x)));
            return Ok(classes);
        }
        [HttpGet("{classId}")]
        public IActionResult GetStundentsFromClass(int classId)
        {
            var students = new List<StudentDto>();
            var classList = new List<ClazzDto>();
            db.Clazzs.Where(y => y.Id != classId).ToList().ForEach(x => classList.Add(new ClazzDto().CopyPropertiesFrom(x)));
            db.Students.Where(x => x.ClazzId == classId).ToList().ForEach(x => students.Add(new StudentDto()
            {
                Id = x.Id,
                Name = x.Firstname + " "+ x.Lastname,
                Age = x.Age,
                ClazzId = x.ClazzId,
                Country = x.Country,
                Email = x.Email,
                Gender = x.Gender,
                Registered = x.Registered == 1 ? true : false,
                availableClazzes = classList
            }));
            return Ok(students);
        }
    }
}
