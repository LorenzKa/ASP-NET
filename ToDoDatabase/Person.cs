using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace ToDoDatabase
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        virtual public List<TodoItem> ToDoItems { get; set; } = new();
    }
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Firstname).HasMaxLength(30);
            builder.Property(p => p.Lastname).HasMaxLength(30);
            builder.Property(p => p.Email).HasMaxLength(100);

            builder.HasIndex(p => p.Email).IsUnique();

            builder.HasData(new Person
            {
                Id = 1,
                Firstname = "Lorenz",
                Lastname = "Kassewalder",
                Email = "lorenz@grieskirchen.at"
            });
            builder.HasData(new Person
            {
                Id = 2,
                Firstname = "Hannes",
                Lastname = "Kassewalder",
                Email = "hannes@grieskirchen.at"
            });
        }
    }
}
