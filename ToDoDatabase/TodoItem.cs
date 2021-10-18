using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDatabase
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime? DueTo { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
    public class ToDoEntityTypeConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(50);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.ToDoItems)
                .HasForeignKey(x => x.PersonId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
