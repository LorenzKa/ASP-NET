using System;
using System.Collections.Generic;

#nullable disable

namespace StudentsManagerDb.Dto
{
    public class StudentDto
    {
        public long Id { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public long Age { get; set; }
        public long Registered { get; set; }
        public long? ClazzId { get; set; }

    }
}
