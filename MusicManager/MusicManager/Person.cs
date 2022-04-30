using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager
{
    public class Person
    {

        private readonly string firstname;
        private readonly string lastname;
        private readonly int age;

        public string Firstname => firstname;
        public string Lastname => lastname;
        public int Age => age;

        public Person(PersonBuilder p)
        {
            this.firstname = p.firstname;
            this.lastname = p.lastname;
            this.age = p.age;
        }

        public class PersonBuilder
        {
            internal readonly string firstname;
            internal readonly string lastname;
            internal int age;

            public PersonBuilder(string firstname, string lastname)
            {
                this.firstname = firstname;
                this.lastname = lastname;
            }

            public PersonBuilder Age(int age)
            {
                this.age = age;
                return this;
            }
            public Person Build()
            {
                var p = new Person(this);
                return p;
            }
        }
    }
}
