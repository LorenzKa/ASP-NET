using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class Person
    {
        private readonly string firstname;
        private readonly string lastname;
        private readonly int age;
        private readonly string phone;
        private readonly string address;

        public string Firstname => firstname;
        public string Lastname => lastname;
        public int Age => age;
        public string Phone => phone;
        public string Address => address;
        public override string? ToString() => $"{firstname} {lastname} {age} {phone} {address}";

        private Person(Builder builder)
        {
            this.firstname = builder.firstname;
            this.lastname = builder.lastname;
            this.age = builder.age;
            this.phone = builder.phone;
            this.address = builder.address;
        }
        public class Builder
        {
            internal readonly string firstname;
            internal readonly string lastname;
            internal int age;
            internal string phone;
            internal string address;
            public Builder(string firstname, string lastname)
            {
                this.firstname = firstname;
                this.lastname = lastname;
            }
            public Builder Age(int age)
            {
                this.age = age;
                return this;
            }
            public Builder Phone(string phone)
            {
                this.phone = phone;
                return this;
            }
            public Builder Address(string address)
            {
                this.address = address;
                return this;
            }
            public Person Build()
            {
                var person = new Person(this);
                if(person.Age > 115 || person.Firstname.Length < 3)
                {
                    throw new InvalidDataException();
                }
                return person;
            }
        }
    }

}
