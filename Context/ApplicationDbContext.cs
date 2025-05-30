using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Context
{
    public class ApplicationDbContext : DbContext
    {



        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }


       public DbSet<ToDo> ToDos { get; set; }

        public DbSet<Category> Categories { get; set; }
    }

}