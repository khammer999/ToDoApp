using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class Context:DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDoCategory> ToDoCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Name = "Home" },
                new Category() { Name = "Business" }
                );
            modelBuilder.Entity<ToDo>().HasData(
                new ToDo() { Id = 1, Description = "Learn To Use this ToDo App", DueDate = DateTime.Now }
                );

            base.OnModelCreating(modelBuilder);
        }

             






        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=KHToDos;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
