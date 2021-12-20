using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PersonsDb
{
    public partial class PersonsContext : DbContext
    {
        public PersonsContext()
        {
        }

        public PersonsContext(DbContextOptions<PersonsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adress> Adresses { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<RegexData> RegexDatas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("data source=c:\\Users\\eugen\\Unterricht\\Tools\\net6\\Persons\\PersonsDb\\Persons.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adress>(entity =>
            {
                entity.HasIndex(e => e.CityId, "IX_Adresses_CityId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Adresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.AdressId, "IX_Persons_AdressId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Adress)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.AdressId);
            });

            modelBuilder.Entity<RegexData>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
