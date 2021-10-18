using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDatabase
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options):base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
    class ToDoDbContextFactory : IDesignTimeDbContextFactory<ToDoDbContext>
    {
        public ToDoDbContext CreateDbContext(string[]? args = null)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<ToDoDbContext>();
            optionsBuilder.UseSqlite(configuration["ConnectionStrings:DefaultConnection"]);

            return new ToDoDbContext(optionsBuilder.Options);
        }
    }

}
