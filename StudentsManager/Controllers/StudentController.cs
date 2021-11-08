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
    public class StudentController : ControllerBase
    {
        private readonly StudentsManagerContext db;
        public StudentController(StudentsManagerContext db)
        {
            this.db = db;
        }

        
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = new List<StudentDto>();
            db.Students.ToList().ForEach(x => students.Add(new StudentDto().CopyPropertiesFrom(x)));
            return Ok(students);
        }
        [HttpPut ("SetClass")]
        public IActionResult SetClass([FromQuery(Name = "id")] int id, [FromQuery(Name = "classId")] int classId)
        {
            db.Students.Where(x => x.Id == id).First().ClazzId = classId;
            db.SaveChanges();
            return Ok(new StudentDto().CopyPropertiesFrom(db.Students.Where(x => id == x.Id).First()));
        }
        [HttpPut("SetAge")]
        public IActionResult SetAge([FromQuery(Name = "id")]int id, [FromQuery(Name = "age")] int age)
        {
            db.Students.Where(x => id == x.Id).First().Age = age;
            db.SaveChanges();
            return Ok(new StudentDto().CopyPropertiesFrom(db.Students.Where(x => id == x.Id).First()));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var toDelete = db.Students.Where(x => x.Id == id).First();
            if ( toDelete != null)
            {
                db.Students.Remove(toDelete);
                db.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
